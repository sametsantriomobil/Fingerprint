using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TrioMobil;
using System.Net;
using RestSharp;
using TinyJson;

namespace FingerPrint
{
    public partial class Token : Form
    {
        String api_url = "https://api.triomobil.com/facility/dev/auth";
        Dictionary<String, String> post_data;
        Dictionary<String, String> give_data;
        public String token_id;

        public Token()
        {
            InitializeComponent();
        }

        private void Token_Load(object sender, EventArgs e)
        {
            post_data = new  Dictionary<String, String>();
            give_data = new Dictionary<String, String>();
            if (token_id != "")
            {
                groupBox1.Hide();
                groupBox2.Show();
                authorization_id.Text = token_id;
            }
            else
            {
                groupBox2.Hide();
                groupBox1.Show();
            }
          
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Connect.RunWorkerAsync();
        }

        private void Connect_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                var client = new RestClient(api_url);
                var request = new RestRequest(Method.POST);

                post_data.Clear();
                post_data.Add("username", TxBxUsername.Text);
                post_data.Add("password", TxBxPassword.Text);

                request.AddParameter("application/json; charset=utf-8", post_data.ToJson(), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    byte[] data = response.RawBytes;
                    String json = Encoding.UTF8.GetString(data);
                    give_data = json.FromJson<Dictionary<String, String>>();
                    token_id = give_data["token"];
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Login is successfuly");
                    this.Close();
                }
                else
                    MessageBox.Show("Username or Password is false!");


            }
            catch (WebException k)
            {
                MessageBox.Show(k.Message);
            }
            button1.Enabled = true;

            if (Connect.CancellationPending) e.Cancel = true;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            Connect.WorkerSupportsCancellation = true;
            Connect.CancelAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.token_id = "";
            this.Close();
        }

       
    }
}
