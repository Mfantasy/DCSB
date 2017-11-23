using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCSB
{
    public partial class HomePage : UserControl
    {
        //当PoorSigna>200 时，状态栏提示：没有正确配戴设备！请检查！
        //暂定算法如下（后续根据试验会更改）。
        //当 Attention>60且Meditation>40时，单词会变成绿色，添加到已熟悉单词库；
        //当Attention>60且Meditation>60时,单词会变成红色，添加到生词库；
        //当Attention、 Meditation、其他值时,单词会变成橙色，添加到模糊生词库；

        List<DCDataModel> totalck = new List<DCDataModel>();
        List<DCDataModel> scck = new List<DCDataModel>();
        List<DCDataModel> mhck = new List<DCDataModel>();
        List<DCDataModel> sxck = new List<DCDataModel>();
        public HomePage()
        {
            InitializeComponent();
            string db = "nbdata.db";
            string selectSql = "SELECT * FROM T_NBData";
            this.Load += (S, E) =>
            {
                DataTable dt = SqlLiteHelper.ExecuteReader(selectSql);
                foreach (DataRow row in dt.Rows)
                {
                    DCDataModel dc = new DCDataModel();
                    dc.CK = Convert.ToInt32(row["CK"]);
                    dc.English = row["Chn"].ToString();
                    dc.Chinese = row["Eng"].ToString();
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
            if (CurrentCK != null)
            {
                int index = CurrentCK.IndexOf(CurrentDC);
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
        
        internal void LoadDC(List<DCDataModel> dlist)
        {
            CurrentCK = dlist;
            CurrentDC = CurrentCK[0];
            label3.Visible = false;
            panel1.Visible = false;
            label1.Visible = true;
            button1.Visible = true;   
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
        }
        public void MoveNext()
        {
            
        }
        public void MovePre()
        {
            //如果存在,则更新.整体逻辑不会改变
        }
        public void SaveDC()
        {
            if (totalck.Exists(c => c.English == currentDC.English))
            {

            }
            else
            {
                totalck.Add(currentDC);
                switch (currentDC.CK)
                {
                    case 1:
                        mhck.Add(currentDC);
                        break;
                    case 2:
                        scck.Add(currentDC);
                        break;
                    case 3:
                        sxck.Add(currentDC);
                        break;
                }
                DAL.SaveDC(currentDC);
            }
        }
        public List<NBDataModel> CurrentNBList = new List<NBDataModel>();

    }
}
