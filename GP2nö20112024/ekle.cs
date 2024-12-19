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
    public partial class ekle : Form
    {
        public ekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogrekle();
        }
        void ogrekle()
        {
            SqlConnection bag = new SqlConnection(@"server=ORKINOS\ORKINOS;initial catalog=tumislemler;integrated security=true");
            string sql = "insert into ogrenciler (okulno,adi,soyadi,bolumu) values ('" + textBoxokulno.Text + "',@prmadi,@prmsoyadi,@prmbolumu)";
            SqlCommand komut = new SqlCommand(sql, bag);
            komut.Parameters.AddWithValue("@prmadi", textBoxadi.Text);
            komut.Parameters.AddWithValue("@prmsoyadi", textBoxsoyadi.Text);
            komut.Parameters.AddWithValue("@prmbolumu", textBoxbolumu.Text);
            bag.Open();
            komut.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Kayıt yapıldı.");





        }
    }
}
