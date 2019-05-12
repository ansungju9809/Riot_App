using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;

namespace summoner_information
{
    public partial class Form1 : Form
    {

        public static string api_pvp_net = ".api.riotgames.com/api/lol";
        public static string development_api_key = "?api_key=RGAPI-be36c748-06ba-4ab7-832a-d0633229de9c";
        public static string summoner_by_name = "v1.4/summoner/by-name";
        public static string aUrl;

        public static string isim_arama;

        public Form1()
        {
            InitializeComponent();
        }


        void arama_isim(string _bolge, string _isim) 
        {
            if (_bolge == "" || _isim == "") return;
            isim_arama = _isim.Replace(" ", "").ToLower();
            aUrl = "https://" + _bolge.ToLower() + api_pvp_net + _bolge.ToLower() + "/" + summoner_by_name + _isim + development_api_key;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            arama_isim(comboBox1.Text.ToLower(), textBox2.Text.ToLower());

            var jsunn = new WebClient().DownloadString(aUrl);
            var jss = new JavaScriptSerializer();
            var d = jss.Deserialize<dynamic>(jsunn);

            label5.Text = Convert.ToString(d[isim_arama]["id"]);
            label6.Text = d[isim_arama]["name"];
            label7.Text = Convert.ToString(d[isim_arama]["summonerLevel"]);
            label8.Text = comboBox1.Text;
        }

    }
}
