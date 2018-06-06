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
    public partial class add_anchors : Form
    {
        public Dictionary<String, Int32> all_anch_list;

        public String id, x, y;

        public add_anchors()
        {
            InitializeComponent();
        }

        private void add_anchors_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<String, Int32> item in all_anch_list.OrderByDescending(i => i.Value))
            {
                 comboBox1.Items.Add(item.Key + "\t" + item.Value);
            }

            xPosition.Text = x;
            yPosition.Text = y;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            id = comboBox1.Text.Split('\t')[0];
            if (id.Length == 6)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Please select anchor!");

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        
    }
}
