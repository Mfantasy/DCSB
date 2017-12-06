using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM
{
    public partial class SerialPortConfigForm : Form
    {
        public SerialPortConfigForm()
        {
            InitializeComponent();
            this.Load += (S,E)=> {
                comboBox2.SelectedItem = "57600";
                comboBox3.SelectedItem = "none";
                comboBox4.SelectedItem = "1";
                comboBox5.SelectedItem = "none";
                comboBox6.SelectedItem = "8";
            };
        }
   
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = radioButton1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
