using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; //datatable
using System.Data.SqlClient;//sqlconnection
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GP2nö20112024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            frm2.frm1 = this; //3.işlem

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//
            dgvyukle();
        }
        public void dgvyukle()
        {
            SqlConnection bag = new SqlConnection(@"SERVER = ORKINOS\ORKINOS; Initial Catalog = tumislemler; Integrated Security = True");
            SqlDataAdapter da = new SqlDataAdapter("select * from ogrenciler", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].HeaderText = "OKUL NO";

        }

        public void button1_Click(object sender, EventArgs e)
        {
            dgvyukle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = File.AppendText("uygulama2.txt");//dosyayı açar
            DateTime dt = DateTime.Now;
            sw.WriteLine(textBox1.Text+"-"+dt);
            sw.Close();
            MessageBox.Show("Kaydedildi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("uygulama2.txt");
            string metin;
            while (sr.EndOfStream==false)
            {
                metin= sr.ReadLine();
                textBox2.Text += metin+"\r\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ekle frm2 = new ekle();
            frm2.ShowDialog();
        }
        public guncelle frm2=new guncelle();//2.işlem
        private void button5_Click(object sender, EventArgs e)
        {
            //guncelle frm2 = new guncelle();
            frm2.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //frm2.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           sil frm2=new sil();
           frm2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(@"SERVER = ORKINOS\ORKINOS; Initial Catalog = tumislemler; Integrated Security = True");
            string sql = "select * from ogrenciler";
            SqlCommand komut=new SqlCommand(sql, bag);            
            bag.Open(); 
            label2.Text=komut.ExecuteScalar().ToString();
            bag.Close();

            //int adet=komut.ExecuteNonQuery();
            //SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            //DataTable dt=new DataTable();
            //da.Fill(dt);
            //string adet = dt.Rows[0][0].ToString();
            //label2.Text=adet;
        }
    }
}
