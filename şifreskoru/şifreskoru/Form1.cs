using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace şifreskoru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = " ";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar =false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            string text = textBox2.Text;
            foreach (char txt in text)
            {
                sayac++;
            }
            label2.Text = sayac + " " + "karakterden oluşmaktadır.";
            string sifre=textBox2.Text;
            int deger=0;
            for (int i = 0; i < sayac; i++)
            {
                int asc = Convert.ToInt32(sifre[i]);
                if (asc >=48 && asc<=57 )
                {
                    deger++;
                }
                else if (asc >=97 && asc <= 122)
                {
                    deger += 3;
                }
                else if (asc >=65 && asc <= 90)
                {
                    deger += 5;
                }else
                {
                    deger += 10;
                }
                if (deger <=8 )
                {
                    label2.Text = "Şifreniz Çok Güçsüz";
                        }else if (deger >8 && deger <= 16)
                {
                    label2.Text = "Şifreniz Güçsüz";
                }else if(deger >16 && deger <= 64)
                {
                    label2.Text = "Şifreniz Ortalama";
                }else if(deger >64 && deger <=120)
                {
                    label2.Text = "Şifreniz Güçlü";
                }else if(deger >120 && deger <=160)
                {
                    label2.Text = "Şifreniz Çok Güçlü";
                }else if(deger > 160)
                {
                    label2.Text = "Şifrenizi sittin sene çözemezler";
                }
            }
            
        }
    }
}
