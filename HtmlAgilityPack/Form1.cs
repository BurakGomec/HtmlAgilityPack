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
using HtmlAgilityPack;

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
            try
            {
                string adres;
                adres = textBox1.Text;//kullanıcının istediği adresi alıyor
                WebRequest istek = HttpWebRequest.Create(adres);
                WebResponse cevap;
                cevap = istek.GetResponse();//cevabı al 
                StreamReader gelenbilgiler = new StreamReader(cevap.GetResponseStream());
                string gelen = gelenbilgiler.ReadToEnd(); //gelenbilgileri okumayı sonlandir
                int baslikbaslangic = gelen.IndexOf("<title>") + 7; //<title>dan sayiyi oku
                int baslikbitis = gelen.Substring(baslikbaslangic).IndexOf("</title>");
                string baslik = gelen.Substring(baslikbaslangic, baslikbitis);
                MessageBox.Show(baslik);




            }
            catch (FormatException)
            {

                MessageBox.Show("Giris Formatiniz Hatali,Tekrar Deneyin");
            }
            catch(Exception E)
            {
                MessageBox.Show(E.ToString());
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string adres2 = textBox1.Text;
                Uri url = new Uri(adres2);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8; //Turkce karakter duzeltmesi
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);
                HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("//a");

                foreach (var baslik in basliklar)
                {
                    string link = baslik.Attributes["href"].Value;
                    listBox1.Items.Add(baslik.InnerText);

                }

            }
            catch (UriFormatException)
            {
                MessageBox.Show("Giris Formatiniz Hatali,Tekrar Deneyin");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Giris Formatiniz Hatali,Tekrar Deneyin");
            }
            
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }



        }
    }
}
