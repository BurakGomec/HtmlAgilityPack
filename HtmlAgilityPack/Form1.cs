using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace HtmlAgilityPack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "https://csc.deu.edu.tr/";

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string adres;
            adres = textBox1.Text;//kullanıcının istediği adresi alıyor
            WebRequest istek = HttpWebRequest.Create(adres);
            WebResponse cevap;
            cevap = istek.GetResponse();//cevabı al 
            StreamReader gelenbilgiler = new StreamReader(cevap.GetResponseStream());
            string gelen = gelenbilgiler.ReadToEnd(); //gelenbilgileri okumayı sonlandir
            int baslikbaslangic = gelen.IndexOf("<title>")+7; //<title>dan sayiyi oku
            int baslikbitis = gelen.Substring(baslikbaslangic).IndexOf("</title>");
            string baslik = gelen.Substring(baslikbaslangic,baslikbitis);
            MessageBox.Show(baslik);











        }
    }
}
