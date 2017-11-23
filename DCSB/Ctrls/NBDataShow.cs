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

namespace DCSB.Ctrls
{
    public partial class NBDataShow : UserControl
    {        
        string selectSql = "SELECT * FROM T_NBData";
        DataTable dt;
        public NBDataShow()
        {
            InitializeComponent();
            this.Load += (S, E) =>
            {
                dt = SqlLiteHelper.ExecuteReader(selectSql);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;                
            };
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
            dt = SqlLiteHelper.ExecuteReader(selectSql);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }
    }
}
