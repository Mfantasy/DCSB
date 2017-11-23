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
        public NBDataView()
        {
            InitializeComponent();
            this.Load += (S, E) =>
            {
                dt = SqlLiteHelper.ExecuteReader(selectSql);                                
            };
        }
    }
}
