using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCSB
{
    public partial class SerialPortConfigForm : Form
    {
        public SerialPortConfigForm()
        {
            InitializeComponent();
        }
   
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = radioButton1.Checked;
        }
    }
}
