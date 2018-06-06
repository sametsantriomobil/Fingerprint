using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using RestSharp;
using TinyJson;

namespace FingerPrint
{
    public partial class FormFloorPlan : Form
    {
        String api_url = "https://api.triomobil.com/facility/dev/floorPlans";
        Dictionary<object, object> floorplan;
        List< object> give_data;
        public String token_id;

        public String floorplanID;
        public String customerID;
        public String map_url;
        public Int32 map_scale;
        public String label;

        public FormFloorPlan()
        {
            InitializeComponent();
        }

        private void FormFloorPlan_Load(object sender, EventArgs e)
        {
            map_scale = 1;
            give_data = new List< object>();
            floorplan = new Dictionary<object, object>();

            request();

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        public void request()
        {

            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                var client = new RestClient(api_url);
                var request = new RestRequest(Method.GET);

                request.AddHeader("Authorization", token_id);
               
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Please Log in");
                    this.Close();
                }else if (response.StatusCode == HttpStatusCode.OK)
                {
                    byte[] data = response.RawBytes;
                    String json = Encoding.UTF8.GetString(data);
                    give_data = json.FromJson<List< object>>();
                  
                    foreach (Dictionary<String, object> asd in give_data)
                    {
                       Dictionary<String, object> image = asd["image"] as Dictionary<String,object>;
                        dataGridView1.Rows.Add(asd["_id"], asd["customerId"], asd["label"],image["url"],image["scale"]);

                    }

                }
                else
                    MessageBox.Show(response.StatusDescription);


            }
            catch (WebException k)
            {
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                 floorplanID= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                 customerID = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                 label = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                 map_url = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                 map_scale = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value);

                 this.DialogResult = DialogResult.OK;
            }

        }

    }
}
