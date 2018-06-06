using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using TinyJson;

namespace FingerPrint
{
    public partial class add_fingerprint : Form
    {

       public DataTable anchor_list;
       public Double selectedX, selectedY;
       public String json;
       public Dictionary<String, Int32> anchor_table_result;
       public Dictionary<String,Int32> anchor_table_rssi;
       private Dictionary<String, Double> anchor_table_distance;
       private bool process_state=true;
       public String customerID, floorPlanID;

       public char tag;
       public Dictionary<string, object> post_data;
       public Dictionary<String, Double> coordinates;
       public List<object> measurument;
       public new Dictionary<string, object> post_anchs;

        public add_fingerprint()
        {
            InitializeComponent();
        }


        private void add_fingerprint_Load(object sender, EventArgs e)
        {
            anchor_table_rssi = new Dictionary<String, Int32>();
            anchor_table_distance = new Dictionary<String, Double>();
            anchor_table_result = new Dictionary<string, int>();

            post_data = new Dictionary<string, object>();
            coordinates = new Dictionary<string, Double>();
            measurument = new List<object>();

            backgroundWorker1.RunWorkerAsync();

        }
          



        public String make_json_data()
        {

            post_data["customerId"] = customerID;
            post_data["floorPlanId"] = floorPlanID;

            coordinates["x"] = Double.Parse(selectedX.ToString(), CultureInfo.CreateSpecificCulture("fr-FR"));
            coordinates["y"] = Double.Parse(selectedY.ToString(), CultureInfo.CreateSpecificCulture("fr-FR"));

            foreach (KeyValuePair<String, Int32> item in anchor_table_result)
            {
                    post_anchs = new Dictionary<string, object>();
                    post_anchs.Add("addr", item.Key);
                    post_anchs.Add("rssi", item.Value);
                    measurument.Add(post_anchs);

            }


            post_data["measurement"] = measurument;
            post_data["coordinates"] = coordinates;


            return post_data.ToJson();

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (!backgroundWorker1.CancellationPending)
                {
                 
                    Thread.Sleep(100);
                    foreach (DataRow item in anchor_list.Rows)
                    {
                        String addr = item["addr"].ToString();
                        Int32 rssi = Convert.ToInt32(item["rssi"]);
                        Int32 x = Convert.ToInt32(item["x"]);
                        Int32 y = Convert.ToInt32(item["y"]);
                        Double distance = Math.Sqrt(Math.Pow(Math.Abs(x - selectedX), 2) + Math.Pow(Math.Abs(y - selectedY), 2));

                        if (anchor_table_rssi.ContainsKey(addr))
                        {
                            anchor_table_distance[addr] = distance;
                            if (rssi > anchor_table_rssi[addr])
                                anchor_table_rssi[addr] = rssi;
                        }
                        else
                        {
                            anchor_table_rssi.Add(addr, rssi);
                            anchor_table_distance.Add(addr, distance);
                        }       

                    }

                    listView1.Items.Clear();
                    anchor_table_result.Clear();
                    int j = 0;
                    foreach (KeyValuePair<String,Int32> item in anchor_table_rssi.OrderByDescending(i => i.Value))
                    {
                        j++;
                        if (j > 6) break;

                        ListViewItem ert = new ListViewItem(item.Key.ToString());
                        ert.SubItems.Add(item.Value.ToString());
                        ert.SubItems.Add(anchor_table_distance[item.Key].ToString());

                        ListViewItem listResult = listView1.Items.Add(ert);
                        anchor_table_result.Add(item.Key.ToString(), item.Value);

                        if (anchor_table_distance.Count > 2)
                            foreach (KeyValuePair<String, Double> tt in anchor_table_distance.OrderBy(i => i.Value).Take(3))
                            {
                                if (item.Key == tt.Key.ToString())
                                    listResult.BackColor = Color.GreenYellow;

                            }

                    }

                    if (!process_state)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }

                if (backgroundWorker1.CancellationPending) e.Cancel=true;

            }catch(DataException g){
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            json= make_json_data();
            process_state = false;

        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.CancelAsync();
            
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }



    }
}
