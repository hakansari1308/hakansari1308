using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evet_Hayır
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int adet = listBox1.Items.Count;
            Random rastgele = new Random();
            int sayi = rastgele.Next(adet);
            


            label1.Text = listBox1.Items[sayi].ToString();
                button1.Visible = false;
                textBox1.Visible = true;
                button2.Visible = true;
            textBox1.Select();
            listBox1.Items.RemoveAt(sayi);
            
            
        }
        

        private void textBox1_KeyDown(object sender, KeyEventArgs e )
        {
            string cevp;
            if (e.KeyCode == Keys.Enter)
            {
                 char[] eh = { 'e', 'v', 't', 'h', 'a', 'y', 'ı', 'r' };

                
                string cumle=textBox1.Text.ToLower();
                int toplam = 0;
                string[] ayırma= cumle.Split(' ');
                foreach (string kelime in ayırma)
                {
                    foreach (char karakter in kelime)
                    {
                        foreach (char sesli in eh)
                            if (karakter == sesli)
                                toplam++;
                        if (toplam <= 5 && toplam >= 4)
                        {
                            MessageBox.Show("KAYBETTİNİZ");
                            Application.Exit();
                        }
                        else
                        {
                            textBox1.Text = "";
                            button2_Click(sender, e);
                        }
                    }
                    toplam = 0;
                }
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int adet = listBox1.Items.Count;
            if (adet == 0)
            {
                MessageBox.Show("KAZANDINIZ");
                Application.Exit();
            }
            else
            {


                int sayi = rastgele.Next(adet);
                label1.Text = listBox1.Items[sayi].ToString();
                textBox1.Visible = true;
                listBox1.Items.RemoveAt(sayi);
                string[] AracListe = new string[] { "Evet", "Hayır", "evet", "hayır" };

                char[] eh = { 'e', 'v', 't', 'h', 'a', 'y', 'ı', 'r' };


                string cumle = textBox1.Text.ToLower();
                int toplam = 0;
                string[] ayırma = cumle.Split(' ');
                foreach (string kelime in ayırma)
                {
                    foreach (char karakter in kelime)
                    {
                        foreach (char sesli in eh)
                            if (karakter == sesli)
                                toplam++;
                        if (toplam <= 5 && toplam >= 4)
                        {
                            MessageBox.Show("KAYBETTİNİZ");
                            Application.Exit();
                        }
                        else
                        {
                            textBox1.Text = "";
                            button2_Click(sender, e);
                        }
                    }
                    toplam = 0;
                }
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Select();
            }
            }
    }
    
}
