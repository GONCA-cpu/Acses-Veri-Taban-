using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Acses_Veri__Tabanı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\gonca\\Öğrenciler.vizee.mdb");

        OleDbCommand talimat = new OleDbCommand();


        private void veriGoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            
            OleDbCommand talimat = new OleDbCommand();
            talimat.Connection = baglanti;
            talimat.CommandText = ("select * from veriler");
            OleDbDataReader verileriOku = talimat.ExecuteReader();

            while(verileriOku.Read())
            {
                ListViewItem verileriEkle = new ListViewItem();

                verileriEkle.Text = verileriOku["Ad"].ToString();
                verileriEkle.SubItems.Add(verileriOku["Soyad"].ToString());
                verileriEkle.SubItems.Add(verileriOku["Sınıf"].ToString());
                verileriEkle.SubItems.Add(verileriOku["Bölüm"].ToString());
                verileriEkle.SubItems.Add(verileriOku["Okul"].ToString());
                verileriEkle.SubItems.Add(verileriOku["Numara"].ToString());



                listView1.Items.Add(verileriEkle);

            }
            baglanti.Close();
        }

        private void veriKaydet() 
        {
            baglanti.Open();
            OleDbCommand kaydetTalimati = new OleDbCommand("insert into veriler(Ad,Soyad,Sınıf,Bölüm,Okul,Numara)" + "values('" + textBox1.Text.ToString()+"','"+ textBox2.Text.ToString()+"','"+ textBox3.Text.ToString()+"','"+ textBox4.Text.ToString()+"','"+ textBox5.Text.ToString()+"','"+ textBox7.Text+"')",baglanti);
            kaydetTalimati.ExecuteNonQuery();
            baglanti.Close();
            veriGoster();

        }
        private void veriSil()
        {
            baglanti.Open();
            talimat.Connection = baglanti;
            talimat.CommandText = "delete from veriler where Ad= '" + textBox6.Text + "'";
            talimat.ExecuteNonQuery();
            baglanti.Close();
            veriGoster();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            veriGoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            veriKaydet();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            veriSil();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            talimat.Connection = baglanti;
            talimat.CommandText = "update veriler set Ad='" + textBox1.Text + "',Soyad='" + textBox2.Text + "',Sınıf='" + textBox3.Text + "',Bölüm='" + textBox4.Text + "',Okul='" + textBox5.Text + "' where Numara='" + textBox7.Text + "'";
            talimat.ExecuteNonQuery();
            baglanti.Close();
            veriGoster();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
