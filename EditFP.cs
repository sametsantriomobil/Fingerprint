using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FingerPrint
{
    public partial class EditFP : Form
    {
        public string data;

        public EditFP()
        {
            InitializeComponent();
        }

        private void EditFP_Load(object sender, EventArgs e)
        {
            textBox1.Text = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.data = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
