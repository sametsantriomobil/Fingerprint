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
using SanLib;
using System.Globalization;

namespace FingerPrint
{
    public partial class Send : Form
    {
        public DataTable fp_table;
        public String customerID;
        public String floorPlanID;
        public String Authorization;
        public char tag;
        public int field;
        public Dictionary<string, object> post_data;
        public Dictionary<String, object> post_anchs;
        public Dictionary<String, Double> coordinates;
        public List<object> measurument;
        public string api_url = "https://api.triomobil.com/facility/dev/fingerprints";
        Background bg;

        public Send()
        {
            InitializeComponent();
        }

        private void Send_Load(object sender, EventArgs e)
        {

            post_data = new Dictionary<string, object>();
            coordinates = new Dictionary<string, Double>();
            measurument = new List<object>();
            bg = new Background();

            field = fp_table.Rows.Count;
            richTextBox1.SelectionFont = new Font("Verdana", 8, FontStyle.Bold);
            richTextBox1.AppendText("Send Data Count : " + field.ToString());
            richTextBox1.AppendText("Auth : " + Authorization.ToString());
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            bgsend.WorkerSupportsCancellation = true;
            bgsend.CancelAsync();
            base.OnFormClosing(e);
        }



        public HttpStatusCode send_to_server(String post)
        {

            try
            {

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                var client = new RestClient(api_url);
                var request = new RestRequest(Method.POST);


                request.AddHeader("Authorization", Authorization);

                request.AddParameter("application/json; charset=utf-8", post, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                return response.StatusCode;
                /*  if (response.ErrorMessage != null)
                    //  ShowMessageBox(response.ErrorMessage + "\n" + post);
                  if (response.StatusDescription != null)
                     // ShowMessageBox(response.StatusDescription + "\n" + post);*/
            }
            catch (WebException e)
            {
               MessageBox.Show (e.ToString());
                return 0;
            }

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgsend.RunWorkerAsync();
            
        }

        private void bgsend_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Int32 d = 100 / field;
                Int32 succes = 0;
                Int32 fail = 0;

                progressBar1.Value = 0;

                for (int i = 0; i < fp_table.Rows.Count; i++)
                {
                    DataRow row = fp_table.Rows[i];
                    if (!(bool)row["send"] )
                    {
                        String data = row["json"].ToString();
                        richTextBox1.AppendText(Environment.NewLine + "| Sending... > " + data);
                        HttpStatusCode code = send_to_server(data);
                        richTextBox1.AppendText(Environment.NewLine + "[" + code.ToString() + "]");
                        progressBar1.Value += d;

                        if (code == HttpStatusCode.Created)
                        {
                            succes++;
                            row["send"] = true;
                        }
                        else
                            fail++;
                    }
                }

                String text = "[Total Sending : " + succes + fail + " | Succesfuly Sending : " + succes.ToString() + " | Fail Sending : " + fail.ToString() + "]";
                if(fail>0)
                    text += Environment.NewLine + "If you want to send fail data,Press 'SEND' button.";

                progressBar1.Value = 100;
                MessageBox.Show(text,"Result");
               

            }catch(Exception c){
                Console.WriteLine(c.ToString());
            }

            if (bgsend.CancellationPending) e.Cancel = true;

        }


    }
}
