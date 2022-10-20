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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text=="" && textBox3.Text=="" && textBox4.Text=="")
            {

                MessageBox.Show("Lütfen Bilgileri Giriniz!!!");

                

            }
            else
            {
                var iller = File.ReadLines(@"C:\Users\Win10\source\repos\Evet^Hayır\sorular.txt");
                string metin;
                Form1 frm = new Form1();
                foreach (var il in iller)
                {
                    frm.listBox1.Items.Add(il);


                }
                {
                    
                    frm.listBox1.Items.Add("Adın " + textBox1.Text + " mı?");
                    frm.listBox1.Items.Add("Soyadın " + textBox2.Text + " mı?");
                    frm.listBox1.Items.Add(textBox3.Text + " yaşında mısın?");
                    frm.listBox1.Items.Add("Doğduğun şehir " + textBox4.Text + "mı?");

                }
                this.Hide();
                frm.ShowDialog();
                

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Select();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Select();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Select();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
            
        }
    }
}
