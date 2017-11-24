using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DCSB
{
    public partial class HomePage : UserControl
    {
        //当PoorSigna>30 时，状态栏提示：没有正确配戴设备！请检查！        
  
        List<DCDataModel> totalck = new List<DCDataModel>();
        List<DCDataModel> scck = new List<DCDataModel>();
        List<DCDataModel> mhck = new List<DCDataModel>();
        List<DCDataModel> sxck = new List<DCDataModel>();
        public HomePage()
        {
            InitializeComponent();
            
            string selectSql = "SELECT * FROM T_DCData";
            this.Load += (S, E) =>
            {
                DataTable dt = SqlLiteHelper.ExecuteReader(selectSql);
                foreach (DataRow row in dt.Rows)
                {
                    DCDataModel dc = new DCDataModel();
                    dc.CK = Convert.ToInt32(row["CK"]);
                    dc.English = row["Eng"].ToString();
                    dc.Chinese = row["Chn"].ToString();
                    totalck.Add(dc);
                    switch (dc.CK)
                    {
                        case 1:
                            mhck.Add(dc);
                            break;
                        case 2:
                            scck.Add(dc);
                            break;
                        case 3:
                            sxck.Add(dc);
                            break;                     
                    }
                }
            };
        }
            
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //下一个
            panel1.Visible = false;
            MoveNext();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //上一个
            panel1.Visible = false;
            if (CurrentCK != null)
            {
                int index = CurrentCK.IndexOf(CurrentDC);
                if (index >= 1)
                {
                    //上一个
                    CurrentDC = CurrentCK[index - 1];
                }
                else
                {
                    MessageBox.Show("已经是第一个!");                                            
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
        
        internal void LoadCK(List<DCDataModel> dlist)
        {
            if (dlist.Count > 0)
            {
                CurrentCK = dlist;
                CurrentDC = CurrentCK[0];
                label3.Visible = false;
                panel1.Visible = false;
                label1.Visible = true;
                button1.Visible = true;
            }
            else
            {
                MessageBox.Show("暂无数据!");
            }
        }

        public List<DCDataModel> CurrentCK { get; set; }
        private DCDataModel currentDC;

        public DCDataModel CurrentDC
        {
            get { return currentDC; }
            set { currentDC = value;
                label1.ForeColor = Color.Black;
                label1.Text = currentDC.English;
                label2.Text = currentDC.Chinese;
            }
        }

        /// <summary>
        /// Attention>60且Meditation>40 sx 3
        /// Attention>60且Meditation>60 sc 2   else mh 1
        /// </summary>        
        public int JudgeCK()
        {
            if (CurrentNBList.Count > 0)
            {
                int ttAttention = 0;
                int ttMeditation = 0;
                int calcount = CurrentNBList.Count;
                foreach (var nb in CurrentNBList)
                {
                    int ate = 0;
                    int med = 0;
                    if (int.TryParse(nb.Attention,out ate) && int.TryParse(nb.Meditation,out med))
                    {
                        ttAttention += ate;
                        ttMeditation += med;
                    }
                    else
                    {
                        calcount--;
                        continue;
                    }
                }
                
                if ((ttAttention / calcount) > 60)
                {
                    if ((ttMeditation / calcount) > 60)
                    {
                        CurrentNBList.Clear();
                        return 2;
                    }
                    if ((ttMeditation / calcount) > 40)
                    {
                        CurrentNBList.Clear();
                        return 3;
                    }
                }                
            }
            CurrentNBList.Clear();
            return 1;
            
        }

        /// <summary>
        /// 1模糊2生词3熟悉
        /// </summary>        
        public void SetDCCK(int ck)
        {
            switch (ck)
            {
                case 0:
                    label1.ForeColor = Color.Black;
                    break;
                case 1:
                    label1.ForeColor = Color.Orange;
                    break;
                case 2:
                    label1.ForeColor = Color.Red;
                    break;
                case 3:
                    label1.ForeColor = Color.Green;
                    break;
            }
            label1.Update();
            Thread.Sleep(1000);
        }
        public void MoveNext()
        {
            if (CurrentCK != null)
            {
                int index = CurrentCK.IndexOf(CurrentDC);
                CurrentDC.CK = JudgeCK();
                SetDCCK(CurrentDC.CK);
                SaveDC();
                if (index < CurrentCK.Count - 1)
                {
                    //下一个                    
                    CurrentDC = CurrentCK[index + 1];                    
                }
                else
                {                    
                    if (MessageBox.Show("导入的词库已经学习完毕, 是否重新浏览该词库 ?", "提醒", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {                     
                        CurrentDC = CurrentCK[0];
                    }
                }
            }
        }

        public void ShowMH()
        {
            LoadCK(mhck);
        }
        public void ShowSX()
        {
            LoadCK(sxck);
        }
        public void ShowSC()
        {
            LoadCK(scck);
        }

        public void SaveDC()
        {
            DCDataModel dc = totalck.Find(c => c.English == CurrentDC.English);
            if (dc != null)
            {
                if (dc.CK != CurrentDC.CK)
                {
                    dc.CK = CurrentDC.CK;
                    DAL.UpdateDC(dc);
                }
            }
            else
            {
                totalck.Add(CurrentDC);
                switch (CurrentDC.CK)
                {
                    case 1:
                        mhck.Add(CurrentDC);
                        break;
                    case 2:
                        scck.Add(CurrentDC);
                        break;
                    case 3:
                        sxck.Add(CurrentDC);
                        break;
                }
                DAL.SaveDC(CurrentDC);
            }
        }
        public List<NBDataModel> CurrentNBList = new List<NBDataModel>();

    }
}
