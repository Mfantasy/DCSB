using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
          
            this.Load += (S, E) =>
              {
              
              };
        }
    }
}
/*
 * wb.GetSheet("");
  for (int i = 0; i < iSheet.LastRowNum; i++)            
                IRow r = iSheet.GetRow(i);
                string sv = r.GetCell(0).StringCellValue;                              
     */
