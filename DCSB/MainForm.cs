using DCSB.Ctrls;
using NeuroSky.ThinkGear;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCSB
{
    public partial class MainForm : Form
    {
        static Connector connector;

        bool golfZoneDemo = false;
        double task_famil_baseline, task_famil_cur, task_famil_change;
        bool task_famil_first;
        double mental_eff_baseline, mental_eff_cur, mental_eff_change;
        bool mental_eff_first;
        //string db = Path.Combine(Utils.GetUserPath(), "nbdata.db");
        
           
        public MainForm()
        {
            InitializeComponent();
            Init();
            this.FormClosing += (S, E) => { if (connector != null) connector.Close(); };
                  
            Thread th = new Thread(() => {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            if (assembly != null)
            {
                object[] customAttribute1 = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if ((customAttribute1 != null) && (customAttribute1.Length > 0))
                    Console.WriteLine(((AssemblyTitleAttribute)customAttribute1[0]).Title);
                object[] customAttribute2 = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if ((customAttribute2 != null) && (customAttribute2.Length > 0))
                    Console.WriteLine(((AssemblyCompanyAttribute)customAttribute2[0]).Company);
                Console.WriteLine(assembly.GetName().Version.ToString());
            }
            AppDomain MyDomain = AppDomain.CurrentDomain;
            Assembly[] AssembliesLoaded = MyDomain.GetAssemblies();

            foreach (Assembly MyAssembly in AssembliesLoaded)
            {
                if (MyAssembly.FullName.Contains("ThinkGear"))
                    Console.WriteLine(MyAssembly.FullName);
            }


            Console.WriteLine("----------");
            if (golfZoneDemo) Console.WriteLine("Hello Golfer!");
            else Console.WriteLine("Hello EEG!");
            Console.WriteLine("----------");

            // Initialize a new Connector and add event handlers
            connector = new Connector();
            connector.DeviceConnected += new EventHandler(OnDeviceConnected);
            connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
            connector.DeviceValidating += new EventHandler(OnDeviceValidating);

            // Scan for devices
            // add this one to scan 1st
            //connector.ConnectScan("COM40");
            connector.ConnectScan("COM17");

            //start the mental effort and task familiarity calculations
            if (golfZoneDemo)
            {
                connector.setMentalEffortEnable(false);
                connector.setTaskFamiliarityEnable(false);
                connector.setBlinkDetectionEnabled(false);
            }
            else
            {
                connector.enableTaskDifficulty(); //depricated
                connector.enableTaskFamiliarity(); //depricated

                connector.setMentalEffortRunContinuous(true);
                connector.setMentalEffortEnable(true);
                connector.setTaskFamiliarityRunContinuous(true);
                connector.setTaskFamiliarityEnable(true);

                connector.setBlinkDetectionEnabled(true);
            }
            task_famil_baseline = task_famil_cur = task_famil_change = 0.0;
            task_famil_first = true;
            mental_eff_baseline = mental_eff_cur = mental_eff_change = 0.0;
            mental_eff_first = true;


            Thread.Sleep(8 * 60 * 1000); // time to live for this program (8 min * 60 sec * 1000 ms)

            Console.WriteLine("----------");
            if (golfZoneDemo) Console.WriteLine("Time is up. Goodbye from Golf Zone sample program!");
            else
            {
                Console.WriteLine("Time is up. Goodbye from EEG sample program!");
                this.Invoke(new Action(()=>{
                    tLabel1.Text = "已超时";
                }));
                }
                Console.WriteLine("----------");
            });
            th.IsBackground = true;
            th.Start();                                      
        }
 
        void OnDeviceConnected(object sender, EventArgs e)
        {
            Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;

            Console.WriteLine("Device found on: " + de.Device.PortName);
            tLabel1.Text = string.Format("已连接:{0}",de.Device.PortName);
            de.Device.DataReceived += new EventHandler(OnDataReceived);
        }

        /**
         * Called when scanning fails
         */
        void OnDeviceFail(object sender, EventArgs e)
        {
            Console.WriteLine("No devices found! :(");
            tLabel1.Text = "未找到设备！";
        }

        /**
         * Called when each port is being validated
         */
        void OnDeviceValidating(object sender, EventArgs e)
        {
            Console.WriteLine("Validating: ");
        }

        byte rcv_poorSignal_last = 255; // start with impossible value
        byte rcv_poorSignal;
        byte rcv_poorSig_cnt = 0;

        /**
         * Called when data is received from a device
         */
        void OnDataReceived(object sender, EventArgs e)
        {
            //Device d = (Device)sender;
            Device.DataEventArgs de = (Device.DataEventArgs)e;
            NeuroSky.ThinkGear.DataRow[] tempDataRowArray = de.DataRowArray;

            TGParser tgParser = new TGParser();
            tgParser.Read(de.DataRowArray);
            NBDataModel dm = new NBDataModel();
            dm.DateTime = DateTime.Now.ToString();
            /* Loop through new parsed data */
            for (int i = 0; i < tgParser.ParsedData.Length; i++)
            {
                if (tgParser.ParsedData[i].ContainsKey("MSG_MODEL_IDENTIFIED"))
                {                    
                    connector.setMentalEffortRunContinuous(true);
                    connector.setMentalEffortEnable(true);
                    connector.setTaskFamiliarityRunContinuous(true);
                    connector.setTaskFamiliarityEnable(true);
                    connector.setPositivityEnable(false);                                                                                                    
                }
                if (tgParser.ParsedData[i].ContainsKey("TimeStamp"))
                {
                    dm.TimeStamp = tgParser.ParsedData[i]["TimeStamp"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("MSG_ERR_CFG_OVERRIDE"))
                {                 
                    dm.MSG_ERR_CFG_OVERRIDE = tgParser.ParsedData[i]["MSG_ERR_CFG_OVERRIDE"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("MSG_ERR_NOT_PROVISIONED"))
                {                    
                    dm.MSG_ERR_NOT_PROVISIONED = tgParser.ParsedData[i]["MSG_ERR_NOT_PROVISIONED"].ToString();
                }               
                if (tgParser.ParsedData[i].ContainsKey("Raw"))
                {
                    dm.Raw = tgParser.ParsedData[i]["Raw"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("Zone"))
                {
                    dm.Zone = tgParser.ParsedData[i]["Zone"].ToString();
                }
                //不等于0?       
                if (tgParser.ParsedData[i].ContainsKey("Attention"))
                {  
                                                              
                   dm.Attention = tgParser.ParsedData[i]["Attention"].ToString();                 
                }
                if (tgParser.ParsedData[i].ContainsKey("Meditation"))
                {                                                            
                   dm.Meditation = tgParser.ParsedData[i]["Meditation"].ToString();                    
                }
                if (tgParser.ParsedData[i].ContainsKey("BlinkStrength"))
                {
                    dm.BlinkStrength = tgParser.ParsedData[i]["BlinkStrength"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("EegPowerDelta"))
                {
                    dm.EegPowerDelta = tgParser.ParsedData[i]["EegPowerDelta"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("EegPowerTheta"))
                {
                    dm.EegPowerTheta = tgParser.ParsedData[i]["EegPowerTheta"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha1"))
                {
                    dm.EegPowerAlpha1 = tgParser.ParsedData[i]["EegPowerAlpha1"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("EegPowerAlpha2"))
                {
                    dm.EegPowerAlpha2 = tgParser.ParsedData[i]["EegPowerAlpha2"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("EegPowerBeta1"))
                {
                    dm.EegPowerBeta1 = tgParser.ParsedData[i]["EegPowerBeta1"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("EegPowerBeta2"))
                {
                    dm.EegPowerBeta2 = tgParser.ParsedData[i]["EegPowerBeta2"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma1"))
                {
                    dm.EegPowerGamma1 = tgParser.ParsedData[i]["EegPowerGamma1"].ToString();
                }
                if (tgParser.ParsedData[i].ContainsKey("EegPowerGamma2"))
                {
                    dm.EegPowerGamma2 = tgParser.ParsedData[i]["EegPowerGamma2"].ToString();
                }
                //特殊处理
                if (tgParser.ParsedData[i].ContainsKey("PoorSignal"))
                {
                    // NOTE: this doesn't work well with BMD sensors Dual Headband or CardioChip

                    rcv_poorSignal = (byte)tgParser.ParsedData[i]["PoorSignal"];
                    dm.PoorSignal = tgParser.ParsedData[i]["PoorSignal"].ToString();
                    if (rcv_poorSignal != rcv_poorSignal_last || rcv_poorSig_cnt >= 30)
                    {
                        // when there is a change of state OR every 30 reports
                        rcv_poorSig_cnt = 0; // reset counter
                        rcv_poorSignal_last = rcv_poorSignal;
                        if (rcv_poorSignal == 0)
                        {
                            // signal is good, we are connected to a subject
                            Console.WriteLine("SIGNAL: we have good contact with the subject");
                        }
                        else
                        {
                            Console.WriteLine("SIGNAL: is POOR: " + rcv_poorSignal);
                        }
                    }
                    else rcv_poorSig_cnt++;
                }

                if (tgParser.ParsedData[i].ContainsKey("MentalEffort"))
                {
                    mental_eff_cur = (Double)tgParser.ParsedData[i]["MentalEffort"];
                    //dm.MentalEffort = tgParser.ParsedData[i]["MentalEffort"].ToString();
                    if (mental_eff_first)
                    {
                        mental_eff_first = false;
                    }
                    else
                    {
                        /*
                         * calculate the percentage change from the previous sample
                         */
                        mental_eff_change = calcPercentChange(mental_eff_baseline, mental_eff_cur);
                        if (mental_eff_change > 500.0 || mental_eff_change < -500.0)
                        {
                            Console.WriteLine("\t\tMental Effort: excessive range");
                        }
                        else
                        {
                            Console.WriteLine("\t\tMental Effort: " + mental_eff_change + " %");
                            dm.MentalEffort = mental_eff_change.ToString() + " %";
                        }
                    }
                    mental_eff_baseline = mental_eff_cur;
                }

                if (tgParser.ParsedData[i].ContainsKey("TaskFamiliarity"))
                {
                    task_famil_cur = (Double)tgParser.ParsedData[i]["TaskFamiliarity"];
                    if (task_famil_first)
                    {
                        task_famil_first = false;
                    }
                    else
                    {
                        /*
                         * calculate the percentage change from the previous sample
                         */
                        task_famil_change = calcPercentChange(task_famil_baseline, task_famil_cur);
                        if (task_famil_change > 500.0 || task_famil_change < -500.0)
                        {
                            Console.WriteLine("\t\tTask Familiarity: excessive range");
                        }
                        else
                        {
                            Console.WriteLine("\t\tTask Familiarity: " + task_famil_change + " %");
                            dm.TaskFamiliarity = task_famil_change.ToString() + " %";
                        }
                    }
                    task_famil_baseline = task_famil_cur;
                }
           
            
             
               
                
               

                 
                                                
            }
            
            DAL.SaveData(dm);
        }

        double calcPercentChange(double baseline, double current)
        {
            double change;

            if (baseline == 0.0) baseline = 1.0; //don't allow divide by zero
            /*
             * calculate the percentage change
             */
            change = current - baseline;
            change = (change / baseline) * 1000.0 + 0.5;
            change = Math.Floor(change) / 10.0;
            return (change);
        }

        void Init()
        {
            //检查是否存在数据表
            string nbSqlExist = "SELECT COUNT(*) FROM sqlite_master where type = 'table' and name = 'T_NBData'";
            object nbObjExist = SqlLiteHelper.ExecuteScalar(nbSqlExist);
            if (Convert.ToInt32(nbObjExist) == 0)
            {
                string createSql = @"CREATE TABLE T_NBData(DateTime varchar(50),  PoorSignal varchar(50),Attention varchar(50),Meditation varchar(50),MentalEffort varchar(50),TaskFamiliarity varchar(50),Zone varchar(50),
                     BlinkStrength varchar(50),Raw varchar(50), MSG_ERR_CFG_OVERRIDE varchar(50),MSG_ERR_NOT_PROVISIONED varchar(50),
                     EegPowerDelta varchar(50),EegPowerTheta varchar(50),EegPowerAlpha1 varchar(50),EegPowerAlpha2 varchar(50),EegPowerBeta1 varchar(50),EegPowerBeta2 varchar(50),EegPowerGamma1 varchar(50),EegPowerGamma2 varchar(50))";
                int res = SqlLiteHelper.ExecuteNonQuery(createSql);
            }
            string dcSqlExist = "SELECT COUNT(*) FROM sqlite_master where type = 'table' and name = 'T_DCData'";
            object dcObjExist = SqlLiteHelper.ExecuteScalar(dcSqlExist);
            if (Convert.ToInt32(dcObjExist) == 0)
            {
                string createSql = @"CREATE TABLE T_DCData(CK varchar(50),Eng varchar(50), Chn varchar(50))";
                int res = SqlLiteHelper.ExecuteNonQuery(db, createSql);
            }
            home = new HomePage();
            datashow = new NBDataShow();
            home.Parent = this;
            datashow.Parent = this;
            home.Dock = DockStyle.Fill;
            datashow.Dock = DockStyle.Fill;
            home.Visible = true;
            datashow.Visible = true;

            home.BringToFront();            
        }

        HomePage home;
        NBDataShow datashow;
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //单词识别
            home.BringToFront();
        }

        private void 导入词库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //导入词库
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "导入词库";
            open.Filter = "Excel文件(*.xls;xlsx)|*.xls;*.xlsx";
            open.RestoreDirectory = true;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //open.FileName
                List<DCDataModel> dlist = DAL.GetDList(open.FileName);
                MessageBox.Show(string.Format("导入成功!已导入记录{0}条",dlist.Count));
                if (dlist.Count > 0)
                {
                    home.LoadDC(dlist);
                }
            }
            
        }

        private void 模糊词库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List<DCDataModel> dlist = DAL.GetMHDList();
        }

        private void 生词词库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List<DCDataModel> dlist = DAL.GetSCDList();
        }

        private void 熟悉词库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List<DCDataModel> dlist = DAL.GetSXDList();
        }

        private void 串口配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SerialPortConfigForm().Show();
        }

        private void mindviewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //曲线图
            //new NBDataModel() {  Attention="", DateTime="", PoorSignal="", Meditation="",   TaskFamiliarity="", MentalEffort=""}

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //记忆曲线,预留
        }
    
        private void minddataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //记录数据表
            datashow.BringToFront();

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fname = ConfigurationManager.AppSettings["helper"];
            if (!string.IsNullOrWhiteSpace(fname))
            {
                Process.Start(fname);
            }
            else
            {
                MessageBox.Show("暂无");
            }
        }

    }
}
/*
 * wb.GetSheet("");
  for (int i = 0; i < iSheet.LastRowNum; i++)            
                IRow r = iSheet.GetRow(i);
                string sv = r.GetCell(0).StringCellValue;                              
     */
