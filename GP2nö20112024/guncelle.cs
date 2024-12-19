using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GP2nö20112024
{
    public partial class guncelle : Form
    {
        public guncelle()
        {
            InitializeComponent();
        }
        //guncelle formundan form1in kontrolüne/aracına erişebilmek:
        public Form1 frm1;//1. işlem
        private void button2_Click(object sender, EventArgs e)
        {
            //getir();
        }
        //public void getir()
        //{
        //    SqlConnection bag = new SqlConnection(@"SERVER = ORKINOS\ORKINOS; Initial Catalog = tumislemler; Integrated Security = True");
        //    string sql = "select * from ogrenciler where okulno=@prm1";
        //    SqlDataAdapter da = new SqlDataAdapter(sql,bag);
        //    da.SelectCommand.Parameters.AddWithValue("@prm1",textBoxokulno.Text);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    textBoxadi.Text = dt.Rows[0][2].ToString();
        //    textBoxsoyadi.Text=dt.Rows[0][3].ToString();
        //    textBoxbolumu.Text=dt.Rows[0][4].ToString();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            ogrguncelle();
            //guncelle2();
        }
        public void ogrguncelle() 
        {
            SqlConnection bag = new SqlConnection(@"SERVER = ORKINOS\ORKINOS; Initial Catalog = tumislemler; Integrated Security = True");
            string sql = "update ogrenciler set adi=@prmadi,soyadi=@prmsoyadi,bolumu=@prmbolumu where okulno=@prmokulno";
            SqlCommand komut = new SqlCommand(sql, bag);
            komut.Parameters.AddWithValue("@prmokulno", textBoxokulno.Text);
            komut.Parameters.AddWithValue("@prmadi", textBoxadi.Text);
            komut.Parameters.AddWithValue("@prmsoyadi", textBoxsoyadi.Text);
            komut.Parameters.AddWithValue("@prmbolumu", textBoxbolumu.Text);
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Güncellendi");
        }
        void guncelle2()
        {
            SqlConnection bag = new SqlConnection(@"SERVER = ORKINOS\ORKINOS; Initial Catalog = tumislemler; Integrated Security = True");
            string sql = "update ogrenciler set adi=@prmadi,soyadi=@prmsoyadi,bolumu=@prmbolumu where okulno=@prmokulno";
            SqlCommand komut = new SqlCommand(sql, bag);
            komut.Parameters.AddWithValue("@prmokulno", comboBox1.SelectedItem);
            komut.Parameters.AddWithValue("@prmadi", textBoxadi.Text);
            komut.Parameters.AddWithValue("@prmsoyadi", textBoxsoyadi.Text);
            komut.Parameters.AddWithValue("@prmbolumu", textBoxbolumu.Text);
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Güncellendi");


        }

        private void guncelle_Load(object sender, EventArgs e)
        {
            //cbyukle2();
            textBoxokulno.Text = frm1.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxadi.Text = frm1.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxsoyadi.Text=frm1.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxbolumu.Text=frm1.dataGridView1.CurrentRow.Cells["bolumu"].Value.ToString();
                
        }
        void cbyukle()
        {
            SqlConnection bag = new SqlConnection(@"SERVER = ORKINOS\ORKINOS; Initial Catalog = tumislemler; Integrated Security = True");
            SqlDataAdapter da = new SqlDataAdapter("select * from ogrenciler", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "okulno";
        }
        void cbyukle2()
        {
            SqlConnection bag = new SqlConnection(@"SERVER = ORKINOS\ORKINOS; Initial Catalog = tumislemler; Integrated Security = True");
            string sql = "select * from ogrenciler";
            SqlCommand komut = new SqlCommand(sql,bag);
            bag.Open();
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["okulno"]);
            }
            bag.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getir2();
        }
        void getir2()
        {
            SqlConnection bag = new SqlConnection(@"SERVER = ORKINOS\ORKINOS; Initial Catalog = tumislemler; Integrated Security = True");
            string sql = "select * from ogrenciler where okulno=@prm1";
            SqlDataAdapter da = new SqlDataAdapter(sql, bag);
            da.SelectCommand.Parameters.AddWithValue("@prm1", comboBox1.SelectedItem);
            DataTable dt = new DataTable();
            da.Fill(dt);
            textBoxadi.Text = dt.Rows[0][2].ToString();
            textBoxsoyadi.Text = dt.Rows[0][3].ToString();
            textBoxbolumu.Text = dt.Rows[0][4].ToString();

        }
    }
}
