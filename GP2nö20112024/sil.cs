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
    public partial class sil : Form
    {
        public sil()
        {
            InitializeComponent();
        }

        private void sil_Load(object sender, EventArgs e)
        {
            cbyukle();
        }
        public void cbyukle()
        {
            SqlConnection bag = new SqlConnection(@"SERVER = ORKINOS\ORKINOS; Initial Catalog = tumislemler; Integrated Security = True");
            string sql = "select * from ogrenciler";
            SqlCommand komut = new SqlCommand(sql, bag);
            bag.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["okulno"]);
            }
            bag.Close();

        }
        void getir()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getir();
        }
        void ogrsil()
        {
            DialogResult cevap = MessageBox.Show("Emin misin", "Silinecek", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                SqlConnection bag = new SqlConnection(@"Data Source=ORKINOS\ORKINOS;Initial Catalog=tumislemler;Integrated Security=True");//1.
                SqlCommand komut = new SqlCommand("DELETE FROM ogrenciler WHERE okulno='" + comboBox1.SelectedItem + "'", bag);
                bag.Open();
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Silindi");
            }            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ogrsil();
            Form1 frm1 = new Form1(); 
            frm1.button1.PerformClick();
            frm1.Show();
        }
    }
}
