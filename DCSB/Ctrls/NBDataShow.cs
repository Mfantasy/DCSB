using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IM.Ctrls
{
    public partial class NBDataShow : UserControl
    {        
        string selectSql = "SELECT * FROM T_NBData";
        DataTable dt;
        public List<NBDataModel> nlist;
        public NBDataShow()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Load += (S, E) =>
            {
                GetData();   
            };
        }

        public void GetData()
        {
            dt = SqlLiteHelper.ExecuteReader(selectSql);
            nlist = new List<NBDataModel>();
            foreach (DataRow r in dt.Rows)
            {
                NBDataModel nbd = new NBDataModel();
                if (r["PoorSignal"] is DBNull)
                {
                    continue;
                }
                if (!(r["PoorSignal"] is DBNull))
                {
                    if (string.IsNullOrWhiteSpace(r["PoorSignal"].ToString()) || int.Parse(r["PoorSignal"].ToString()) > 50)
                    {
                        continue;
                    }
                }
                nlist.Add(nbd);
                if (!(r["DateTime"] is DBNull))
                {
                    nbd.DateTime = r["DateTime"].ToString();
                }             
                if (!(r["Attention"] is DBNull))
                {
                    nbd.Attention = r["Attention"].ToString();
                }
                if (!(r["Meditation"] is DBNull))
                {
                    nbd.Meditation = r["Meditation"].ToString();
                }
                if (!(r["BlinkStrength"] is DBNull))
                {
                    nbd.BlinkStrength = r["BlinkStrength"].ToString();
                }
                if (!(r["TaskFamiliarity"] is DBNull))
                {
                    nbd.TaskFamiliarity = r["TaskFamiliarity"].ToString();
                }
                if (!(r["Zone"] is DBNull))
                {
                    nbd.Zone = r["Zone"].ToString();
                }
                //if (!(r["MentalEffort"] is DBNull))
                //{
                //    nbd.MentalEffort = r["MentalEffort"].ToString();
                //}                              
            }

            dataGridView1.DataSource = null;            
            dataGridView1.DataSource = nlist;
            string[] displayCols = { "DateTime", "Attention", "Meditation", "BlinkStrength", "TaskFamiliarity", "Zone" };
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (!displayCols.Contains(col.Name))
                {
                    col.Visible = false;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //导出报表            
            if (dt != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "保存模板";
                save.Filter = "Excel文件(*.xls)|*.xls";
                save.RestoreDirectory = true;
                save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Utils.ExportToXls(save.FileName,dt);
                    MessageBox.Show("保存成功");
                }                
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //刷新查询
            GetData();
        }
    }
}
