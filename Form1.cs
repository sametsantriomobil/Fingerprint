using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Services;
using System.Net;
using System.IO; 
using TinyJson;
using System.IO.Ports;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Specialized;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using RestSharp;
using TrioMobil;
using SanLib;
using System.Globalization;

namespace FingerPrint
{
   
    public partial class Form1 : Form
    {
        public String project_name = "FingerPrint";
        public String file_extension = "triofp";
        public Int32 default_map_width = 1024;

        public TrioPath trio_folder;
        public char tag='\t';
        public string api_url = "https://api.triomobil.com/facility/dev/fingerprints";

        public String authorization="";//= "91c8eb87-02d3-46d1-b4e7-19fab6d31ef1";

        public String FloorPlan_CustomerID;
        public String FloorPlan_ID;
        public String FloorPlan_Label;
        public Int32 FloorPlan_Scale=1;
        public String FloorPlan_URL;
        public Int32 SelectedAnchorIndex=-1, SelectedFingerprintIndex=-1;

        public DataTable anchor_table;
        public DataTable all_anchor_table;
        public DataTable fp_table;
        public Int32 fp_table_id = 0;

        public Dictionary<String,Int32> anch_list;
        public Dictionary<String, Int32> all_anch_list;
        public Dictionary<String, object> post_anchs;

        Int32[] baudrates = { 9600, 115200 };
        SerialPort port;
        String[] ports;
        bool connectingState;
        String serialPortname;
        Int32 serialBaudrate;
  
        Color color = Color.Red;
        Bitmap img,img2;
        Location SelectedLocation,MouseLocation,CalcLocation;
      

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.KeyPreview = true;
            
            anch_list = new Dictionary<string, Int32>();
            all_anch_list = new Dictionary<string, Int32>();


            this.WindowState = FormWindowState.Maximized;

            config_init();
            portInit();
            baudrateInit();
            listView2.Items.Clear();
            listView1.Items.Clear();
            listView3.Items.Clear();
            anchor_table_init();
            fp_table_init();
            new_map();



            CalcLocation = new Location(map.Width, map.Height, FloorPlan_Scale);
            MouseLocation = new Location(map.Width, map.Height, FloorPlan_Scale);
            SelectedLocation = new Location(map.Width, map.Height, FloorPlan_Scale);


            serial_reader.WorkerSupportsCancellation = true;
            map_refresher.WorkerSupportsCancellation = true;
            serial_reader.RunWorkerAsync();
            map_refresher.RunWorkerAsync();

            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            serial_reader.WorkerSupportsCancellation = true;
            map_refresher.WorkerSupportsCancellation = true;
            serial_reader.CancelAsync();
            map_refresher.CancelAsync();
            base.OnFormClosing(e);
        }


        private void new_map()
        {
            int width = 400;
            int height = 400;
            img = new Bitmap(width,height);
            img2 = new Bitmap(img);
           
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                    img.SetPixel(i,j,Color.White);
            }

            map.Width = width;
            map.Height = height;
            map.Image = img;
        }

       
        private void config_init(){
            trio_folder = new TrioPath(project_name);
            authorization = trio_folder.config_read("token");
        }


        private void anchor_table_init()
        {
            anchor_table = new DataTable();
            anchor_table.Columns.Add("addr", typeof(String));
            anchor_table.Columns.Add("rssi", typeof(Int32));
            anchor_table.Columns.Add("x", typeof(Double));
            anchor_table.Columns.Add("y", typeof(Double));
        }


        private void fp_table_init()
        {
            fp_table = new DataTable();
            fp_table.Columns.Add("id", typeof(Int32));
            fp_table.Columns.Add("x", typeof(Double));
            fp_table.Columns.Add("y", typeof(Double));
            fp_table.Columns.Add("json", typeof(String));
            fp_table.Columns.Add("send", typeof(bool));
        }

        public void baudrateInit()
        {
            int i = 0;
            while (i < baudrates.Length)
            {

                baudrateList.Items.Add(baudrates[i].ToString());
                i++;
            }

            baudrateList.Text = baudrates[1].ToString();
        }

        private void portInit()
        {
            portList.Items.Clear();
            ports = SerialPort.GetPortNames();

            portList.Items.AddRange(ports);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Send form = new Send();
            form.fp_table = fp_table;
            form.customerID = FloorPlan_CustomerID;
            form.floorPlanID = FloorPlan_ID;
            form.Authorization = authorization;
            form.tag = tag;
            form.api_url = api_url;
            form.Show();
        }

      
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Connect();
        }


        private void read_serialport(){
            try
            {
                if (connectingState)
                {

                    port.Open();

                    for (int i = 0; i < 50; i++)
                    {
                        String d = "";
                        if (port.IsOpen)
                            d = port.ReadLine();
                        d = d.Split('\r')[0];

                        if (d.Contains(','))
                        {
                            String[] s = d.Split(',');
                            Int32 rssi;

                            if (Int32.TryParse(s[1], out rssi) && s[0].Length == 6)
                            {
                                String key = s[0];
                                rssi = -1 * Int32.Parse(s[1], System.Globalization.NumberStyles.HexNumber);

                                if (all_anch_list.ContainsKey(key))
                                    all_anch_list[key] = (all_anch_list[key] + rssi) / 2;
                                else
                                    all_anch_list.Add(key, rssi);


                                /*
                                    listBox2.Items.Clear();
                                    foreach (KeyValuePair<String, Int32> item in all_anch_list.OrderByDescending(i => i.Value))
                                        listBox2.Items.Add(item.Key + tag + item.Value);
                                */
                            }


                        }
                    }



                    port.Close();

                }
            }catch(Exception e){
                port_disconnect();
                MessageBox.Show(e.Message);
            }
        }

        private void port_disconnect()
        {
            connectingState = false;
            buttonConnect.Text = "Connect";
            statusBar.Text = "Disconnect is succesfuly.";
        }

        private void port_connect()
        {
            port = new SerialPort(serialPortname, serialBaudrate);
            connectingState = true;
            buttonConnect.Text = "Disconnect";
            statusBar.Text = "Connect is succesfuly.";

        }

        private void ShowMessageBox(String mesaj, String title = "Result")
        {
            Background b = new Background();
            b.ShowMessageBox(mesaj,title);
        }

        private void Connect()
        {

                if (connectingState == false)
                {
                    if (portList.SelectedIndex > -1)
                        serialPortname = portList.SelectedItem.ToString();
                    else
                    {
                        ShowMessageBox("Please select port!");
                        return;
                    }

                    if (baudrateList.SelectedIndex > -1)
                        serialBaudrate = Convert.ToInt32(baudrateList.SelectedItem.ToString());
                    else
                    {
                        ShowMessageBox("Please select baudrate!");
                        return;
                    }

                    port_connect();
                }
                else
                {
                    port_disconnect();
                   
                }

        }

      

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormFloorPlan form = new FormFloorPlan();
            form.token_id = authorization;
            DialogResult d = form.ShowDialog();

            if(d == DialogResult.OK)
            {
                FloorPlan_CustomerID = form.customerID;
                FloorPlan_ID = form.floorplanID;
                FloorPlan_Label = form.label;
                FloorPlan_URL = form.map_url;
                FloorPlan_Scale = form.map_scale;
                open_flooplan();

            }
        }

       
        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation.fromImage(e.Location.X, e.Location.Y);

            statusText.Text = " Map[x:" + MouseLocation.map_x.ToString() + " y:" + MouseLocation.map_y.ToString() + "] - Real[x:" + MouseLocation.real_x.ToString() + " y:" + MouseLocation.real_y.ToString() + "] - Image[x:" + MouseLocation.image_x.ToString() + " y:" + MouseLocation.image_y.ToString() + "]";
        }

    
        private void map_Click(object sender, EventArgs e)
        {
          
            SelectedLocation.fromImage( MouseLocation.image_x,MouseLocation.image_y );

            statusText2.Text = " || Map[x:" + SelectedLocation.map_x.ToString() + " y:" + SelectedLocation.map_y.ToString() + "] - Real[x:" + SelectedLocation.real_x.ToString() + " y:" + SelectedLocation.real_y.ToString() + "] - Image[x:" + SelectedLocation.image_x.ToString() + " y:" + SelectedLocation.image_y.ToString() + "]";


            map_refresh();
              
        }


        private void portList_Click(object sender, EventArgs e)
        {
            portInit();
        }

      

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            Token form = new Token();
            form.token_id = authorization;
            if (form.ShowDialog() == DialogResult.OK)
            {
                authorization = form.token_id;
                trio_folder.config_write("token", form.token_id);
            }


        }

     
        
        private void map_refresh()
        {
            try
            {
                listView1.Items.Clear();

                if(all_anch_list.Count >0)
                foreach (KeyValuePair<String, Int32> item in all_anch_list.OrderByDescending(i => i.Value))
                {
                    String[] im = { item.Key, item.Value.ToString() };

                    ListViewItem a = listView1.Items.Add(new ListViewItem(im));

                    foreach (DataRow row in anchor_table.Rows)
                    {

                         if (row["addr"].ToString() == item.Key.ToString())
                            row["rssi"] = item.Value;

                    }
                }

                listView2.Items.Clear();

                if (anchor_table.Rows.Count > 0)
                    for (int i = 0; i < anchor_table.Rows.Count;i++ )
                    {
                        DataRow row = anchor_table.Rows[i];
                        String[] im = { row["addr"].ToString(), row["rssi"].ToString(), row["x"].ToString(), row["y"].ToString() };
                       ListViewItem s = listView2.Items.Add(new ListViewItem(im));
                  
                        
                         if (s.Index == SelectedAnchorIndex)
                         {
                             s.Focused = true;
                             s.Selected = true;
                         }
                    }

               

                Graphics grp = Graphics.FromImage(img2);
                Bitmap red = new Bitmap(redLoc.Image, new Size(18, 26));
                Bitmap blue = new Bitmap(blueLoc.Image, new Size(18, 26));
                Bitmap green = new Bitmap(greenLoc.Image, new Size(18, 26));

                grp.DrawImage(img, 0, 0);
                Brush bg = new SolidBrush(Color.WhiteSmoke);
                Brush sbg = new SolidBrush(Color.Red);
                Brush br = new SolidBrush(Color.Black);
                Pen border = new Pen(br, 1);


                grp.DrawImage(red, SelectedLocation.image_x - 9, SelectedLocation.image_y - 26);

                foreach (DataRow row in anchor_table.Rows)
                {
                    Double x = row.Field<Double>(2);
                    Double y = row.Field<Double>(3);

                    CalcLocation.fromReal(x, y);

                    grp.DrawImage(blue, CalcLocation.image_x - 9, CalcLocation.image_y - 26);

                    RectangleF rectf = new RectangleF(CalcLocation.image_x + 1, CalcLocation.image_y + 1, 90, 50);
                    grp.DrawRectangle(border, CalcLocation.image_x - 1, CalcLocation.image_y - 1, 62, 42);
                    grp.FillRectangle(bg, CalcLocation.image_x, CalcLocation.image_y, 60, 40);
                    grp.DrawString(row.Field<String>(0) + "\n" + row.Field<Int32>(1).ToString(), new Font("Tahoma", 11), Brushes.Black, rectf);
                    grp.Flush();

                }

                foreach (DataRow row in fp_table.Rows)
                {
                    Double x = row.Field<Double>(1);
                    Double y = row.Field<Double>(2);
                    Int32 id = row.Field<Int32>(0);
                    CalcLocation.fromReal(x, y);
                    grp.DrawImage(green, CalcLocation.image_x - 9, CalcLocation.image_y - 26);
                    RectangleF rectf = new RectangleF(CalcLocation.image_x, CalcLocation.image_y, 90, 20);
                    grp.DrawRectangle(border, CalcLocation.image_x - 1, CalcLocation.image_y - 1, 32, 22);
                   
                        if (SelectedFingerprintIndex > -1 && listView3.Items[SelectedFingerprintIndex].SubItems[0].Text == id.ToString())
                        {
                            grp.FillRectangle(sbg, CalcLocation.image_x, CalcLocation.image_y, 30, 20);
                            grp.DrawString(id.ToString(), new Font("Tahoma", 11), Brushes.White, rectf);
                        }
                    else
                    {
                        grp.FillRectangle(bg, CalcLocation.image_x, CalcLocation.image_y, 30, 20);
                        grp.DrawString(id.ToString(), new Font("Tahoma", 11), Brushes.Black, rectf);
                    }
                    grp.Flush();
                }


                map.Image = img2;
            }catch(DataException n){

            }
        }


        private void map_refresher_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {

                    this.Invoke((MethodInvoker)delegate()
                       {
                           map_refresh();
                       });
                    Thread.Sleep(100);

                }
            }catch(Exception m){
            }
        }

        private void serial_reader_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                    read_serialport();
                    
            }
        }


        private void Add_Anchor()
        {

            add_anchors form = new add_anchors();
            form.all_anch_list = all_anch_list;
            form.x = SelectedLocation.real_x.ToString();
            form.y = SelectedLocation.real_y.ToString();

            if (form.ShowDialog() == DialogResult.OK)
            {
                String exp = "addr='" + form.id + "'";
                DataRow[] h = anchor_table.Select(exp);

                if (h.Length == 0)
                {
                    DataRow d = anchor_table.Rows.Add(form.id, -255, SelectedLocation.real_x, SelectedLocation.real_y);
                    listView2.Items.Add(new ListViewItem(form.id, "-255"));

                    if (d.ItemArray[0].ToString() == form.id)
                        ShowMessageBox("Anchor is added");
                    else
                        ShowMessageBox("Error");
                }
                else
                    MessageBox.Show("Anchor is already add");

            }
        }
        private void btnAnchAdd_Click(object sender, EventArgs e)
        {
            Add_Anchor();
        }

        private void Delete_Anchor()
        {
            if (listView2.SelectedItems.Count > 0)
            {
                String key = listView2.Items[SelectedAnchorIndex].Text.Trim();
                for (int i = 0; i < anchor_table.Rows.Count; i++)
                {
                    if (anchor_table.Rows[i]["addr"].ToString() == key)
                        anchor_table.Rows[i].Delete();
                }

                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    if (listView2.Items[i].Selected)
                    {
                        listView2.Items[i].Remove();
                        i--;
                    }
                }


            }
            else
                ShowMessageBox("Please select item!");

        }

        private void btnAnchDel_Click(object sender, EventArgs e)
        {
            Delete_Anchor();
        }

        private void Add_FingerPrint()
        {

            if (anchor_table.Rows.Count > 0)
            {

                add_fingerprint form = new add_fingerprint();
                form.anchor_list = anchor_table;
                form.selectedX = SelectedLocation.real_x;
                form.selectedY = SelectedLocation.real_y;
                form.customerID = FloorPlan_CustomerID;
                form.floorPlanID = FloorPlan_ID;

                if (form.ShowDialog() == DialogResult.OK)
                {

                    Int32 id = fp_table_id++;

                    DataRow d = fp_table.Rows.Add(id, SelectedLocation.real_x, SelectedLocation.real_y, form.json, false);
                    ListViewItem asd = new ListViewItem(id.ToString());
                    asd.SubItems.Add(SelectedLocation.real_x.ToString());
                    asd.SubItems.Add(SelectedLocation.real_y.ToString());
                    asd.SubItems.Add(form.json);

                    listView3.Items.Add(asd);

                    if (d.ItemArray[0].ToString() == id.ToString())
                        ShowMessageBox("FingerPrint is added");
                    else
                        ShowMessageBox("Error");


                }

            }
            else
                ShowMessageBox("Please add anchors");
            
        }

        private void btnFpAdd_Click(object sender, EventArgs e)
        {
            Add_FingerPrint();
        }

        private void btnFpDel_Click(object sender, EventArgs e)
        {
            Delete_FingerPrint();
        }
        private void Delete_FingerPrint()
        {
            if (listView3.SelectedItems.Count > 0)
            {
               
                for (int i = 0; i < listView3.Items.Count; i++)
                {
                    if (listView3.Items[i].Selected)
                    {
                        String id = listView3.Items[i].SubItems[0].Text.Trim();

                        for (int j = 0; j < fp_table.Rows.Count; j++)
                        {
                            if (fp_table.Rows[j]["id"].ToString() == id.ToString())
                                fp_table.Rows[j].Delete();
                        }

                        listView3.Items[i].Remove();
                        i--;
                    }
                }


            }
            else
                ShowMessageBox("Please select item!");
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            DialogResult c = new DialogResult();
            c=MessageBox.Show("Are you sure to open a new project? You will lose existing project.","Warning!",MessageBoxButtons.YesNo);
            if (c == DialogResult.Yes)
            {

                fp_table.Clear();
                anchor_table.Clear();
                listView2.Items.Clear();
                listView1.Items.Clear();
                listView3.Items.Clear();
                new_map();
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Trio Fingerprint Files (*." + file_extension + "*)|*." + file_extension + "*";
            fd.DefaultExt = file_extension;
            fd.AddExtension = true;

            if (fd.ShowDialog() == DialogResult.OK)
            {

                StreamWriter file = new StreamWriter(fd.FileName);

                file.WriteLine("[floorplan_label]");
                file.WriteLine(FloorPlan_Label);
                file.WriteLine("[/floorplan_label]");

                file.WriteLine("[floorplan_url]");
                file.WriteLine(FloorPlan_URL);
                file.WriteLine("[/floorplan_url]");

                file.WriteLine("[floorplan_scale]");
                file.WriteLine(FloorPlan_Scale);
                file.WriteLine("[/floorplan_scale]");

                file.WriteLine("[floorplan_id]");
                file.WriteLine(FloorPlan_ID);
                file.WriteLine("[/floorplan_id]");

                file.WriteLine("[floorplan_customerid]");
                file.WriteLine(FloorPlan_CustomerID);
                file.WriteLine("[/floorplan_customerid]");


                file.WriteLine("[anchors]" );
                for (int i = 0; i < anchor_table.Rows.Count; i++)
                    file.WriteLine(
                        anchor_table.Rows[i]["addr"].ToString() +tag+
                        anchor_table.Rows[i]["rssi"].ToString() + tag +
                        anchor_table.Rows[i]["x"].ToString() + tag +
                        anchor_table.Rows[i]["y"].ToString() );
                file.WriteLine("[/anchors]");

                file.WriteLine("[fingerprints]");
                for (int i = 0; i < fp_table.Rows.Count; i++)
                    file.WriteLine(
                        fp_table.Rows[i]["id"].ToString() + tag +
                        fp_table.Rows[i]["x"].ToString() + tag +
                        fp_table.Rows[i]["y"].ToString() + tag +
                        fp_table.Rows[i]["json"].ToString() + tag +
                        fp_table.Rows[i]["send"].ToString()  );
                file.WriteLine("[/fingerprints]");

                file.Close();
                MessageBox.Show("Saved project!");
            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            anchor_table.Clear();
            fp_table.Clear();

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Trio Fingerprint Files (*." + file_extension + "*)|*." + file_extension + "*";
            fd.DefaultExt = file_extension;
            fd.AddExtension = true;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(fd.FileName))
                {
                    MessageBox.Show("File is not found!");
                    return;
                }
                    
                StreamReader fp = new StreamReader(fd.FileName);

                while(!fp.EndOfStream){
                    String st = fp.ReadLine();

                    switch(st){
                        case "[floorplan_label]":
                            FloorPlan_Label = fp.ReadLine();
                            break;
                        case "[floorplan_url]":
                            FloorPlan_URL = fp.ReadLine();
                            break;
                        case "[floorplan_scale]":
                            FloorPlan_Scale =Convert.ToInt32(fp.ReadLine());
                            break;
                        case "[floorplan_id]":
                            FloorPlan_ID = fp.ReadLine();
                            break;
                        case "[floorplan_customerid]":
                            FloorPlan_CustomerID = fp.ReadLine();
                            break;

                        case "[anchors]":
                            
                            while (!fp.EndOfStream)
                            {
                                String fs = fp.ReadLine();
                                if (fs == "[/anchors]") break;
                                else
                                {
                                    String[] sf = fs.Split(tag);
                                    anchor_table.Rows.Add(sf[0], Convert.ToInt32(sf[1]), Convert.ToDouble(sf[2]), Convert.ToDouble(sf[3]));
                                    listView2.Items.Add(new ListViewItem(sf[0], sf[1]));
                                }
                           }
                            break;

                        case "[fingerprints]":
                            
                            while (!fp.EndOfStream)
                            {
                                String fs = fp.ReadLine();
                                if (fs == "[/fingerprints]") break;
                                else
                                {
                                    String[] sf = fs.Split(tag);
                                    bool snd;
                                    if (sf[4] == "False")
                                        snd = false;
                                    else
                                        snd = true;
                                    fp_table.Rows.Add(Convert.ToInt32(sf[0]), Convert.ToDouble(sf[1]), Convert.ToDouble(sf[2]), sf[3], snd);
                                    ListViewItem asd = new ListViewItem(sf[0]);
                                    asd.SubItems.Add(sf[1]);
                                    asd.SubItems.Add(sf[2]);
                                    asd.SubItems.Add(sf[3]);
                                    listView3.Items.Add(asd);


                                }
                            }
                            break;
                           
                    }

                }

            }

            open_flooplan();

        }

        private void open_flooplan(){
            
                using (WebClient wc = new WebClient())
                {
                    using (Stream s = wc.OpenRead(FloorPlan_URL))
                    {
                        Bitmap bt = new Bitmap(s);
                        Double sc = (double)bt.Width / default_map_width;
                       
                        Int32 nh = Convert.ToInt32( bt.Height / sc);
                        FloorPlan_Scale =Convert.ToInt32( FloorPlan_Scale / sc);
                        img = new Bitmap(bt, new Size(default_map_width, nh));
                        img2 = new Bitmap(img);

                    }
                }

                map.Width = img.Width;
                map.Height = img.Height;
                map.Image = img;

                MouseLocation.width = img.Width;
                MouseLocation.height = img.Height;
                MouseLocation.scale = FloorPlan_Scale;


                SelectedLocation.width = img.Width;
                SelectedLocation.height = img.Height;
                SelectedLocation.scale = FloorPlan_Scale;


                CalcLocation.width = img.Width;
                CalcLocation.height = img.Height;
                CalcLocation.scale = FloorPlan_Scale;

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                SelectedAnchorIndex = listView2.SelectedItems[0].Index;
                SelectedFingerprintIndex = -1;
            }
            else
                SelectedAnchorIndex = -1;

        }

        private void listView3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                SelectedFingerprintIndex = listView3.SelectedItems[0].Index;
                SelectedAnchorIndex = -1;
            }
            else
                SelectedFingerprintIndex = -1;

        }

        private void loogFP(object sender, MouseEventArgs e)
        {
            String data = listView3.Items[SelectedFingerprintIndex].SubItems[3].Text;

            EditFP fp = new EditFP();
            fp.data = data;

            if (fp.ShowDialog() == DialogResult.OK)
            {
                listView3.Items[SelectedFingerprintIndex].SubItems[3].Text = fp.data;
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.D) Add_Anchor();
            if (e.Control == true && e.KeyCode == Keys.F) Add_FingerPrint();
            if (SelectedAnchorIndex > -1 &&  e.KeyCode == Keys.Delete) Delete_Anchor();
            if (SelectedFingerprintIndex > -1 && e.KeyCode == Keys.Delete) Delete_FingerPrint();
                
        }

      
    }
}
