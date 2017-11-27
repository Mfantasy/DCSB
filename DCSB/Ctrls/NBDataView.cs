using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCSB.Ctrls
{
    public partial class NBDataView : UserControl
    {
        string db = "nbdata.db";
        string selectSql = "SELECT * FROM T_NBData";
        DataTable dt;
        public List<NBDataModel> nlist;
        public NBDataView()
        {
            InitializeComponent();
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
                nlist.Add(nbd);
                if (!(r["DateTime"] is DBNull))
                {
                    nbd.DateTime = r["DateTime"].ToString();
                }
                if (!(r["PoorSignal"] is DBNull))
                {
                    nbd.PoorSignal = r["PoorSignal"].ToString();
                }
                if (!(r["Attention"] is DBNull))
                {
                    nbd.Attention = r["Attention"].ToString();
                }
                if (!(r["Meditation"] is DBNull))
                {
                    nbd.Meditation = r["Meditation"].ToString();
                }
                if (!(r["MentalEffort"] is DBNull))
                {
                    nbd.MentalEffort = r["MentalEffort"].ToString();
                }
                if (!(r["TaskFamiliarity"] is DBNull))
                {
                    nbd.TaskFamiliarity = r["TaskFamiliarity"].ToString();
                }
            }
            chart1.Series[0].Points.DataBind(nlist, "DateTime", "PoorSignal", "");
            chart1.Series[1].Points.DataBind(nlist, "DateTime", "Attention", "");
            chart1.Series[2].Points.DataBind(nlist, "DateTime", "Meditation", "");
            
            chart2.Series[0].Points.DataBind(nlist, "DateTime", "MentalEffort", "");
            chart2.Series[1].Points.DataBind(nlist, "DateTime", "TaskFamiliarity", "");

            chart1.ChartAreas[0].RecalculateAxesScale();
            chart2.ChartAreas[0].RecalculateAxesScale();
        }
        
    }
   
}
