using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
    SqlConnection con;
    SqlDataAdapter da;
    SqlCommand cmd;
    DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

       void griddoldur()
       {
            con = new SqlConnection("Data Source=DESKTOP-BAV2LIP\\SQLEXPRESS;Initial Catalog=DENEME;Integrated Security=True");
            da = new SqlDataAdapter("Select *From kisi", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds,"kisi");
            dataGridView1.DataSource = ds.Tables["kisi"];
            con.Close();
       }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "")
            {
                if (textBox1.Text == "")
                    MessageBox.Show("TC Kimlik Numarası eksik.");
                if (textBox2.Text == "")
                    MessageBox.Show("Ad Soyad eksik.");
                if (textBox5.Text == "")
                    MessageBox.Show("Dosya numarası eksik.");
                if (textBox7.Text == "")
                    MessageBox.Show("Sıra numarası eksik.");
                if (textBox8.Text == "")
                    MessageBox.Show("Kart Tipi eksik.");
                if (textBox10.Text == "")
                    MessageBox.Show("Kayıt Yapan kişi eksik.");
                goto Bitis;
            }
            else
            {
                if (textBox6.Text.Length > 254)
                {
                    MessageBox.Show("Açıklama 255 karakterden fazla olamaz.");
                    goto Bitis;
                }
                if (textBox1.Text.Length != 11)
                {
                    MessageBox.Show("TC Kimlik Numarası 11 karakter olmak zorunda.");
                    goto Bitis;
                }
                if (textBox2.Text.Length > 49)
                {
                    MessageBox.Show("Ad Soyad 50 karakterden fazla olamaz.");
                    goto Bitis;
                }
                if (textBox3.Text.Length > 19)
                {
                    MessageBox.Show("Telefon Numarası 20 karakterden fazla olamaz.");
                    goto Bitis;
                }
                if (textBox5.Text.Length > 19)
                {
                    MessageBox.Show("Dosya Numarası 20 karakterden fazla olamaz.");
                    goto Bitis;
                }
                if (textBox7.Text.Length > 19)
                {
                    MessageBox.Show("Sıra Numarası 20 karakterden fazla olamaz.");
                    goto Bitis;
                }
                if (textBox8.Text.Length > 19)
                {
                    MessageBox.Show("Kart Tipi 20 karakterden fazla olamaz.");
                    goto Bitis;
                }
                if (textBox9.Text.Length > 19)
                {
                    MessageBox.Show("Kartı Basan kişi 20 karakterden fazla olamaz.");
                    goto Bitis;
                }
                if (textBox10.Text.Length > 19)
                {
                    MessageBox.Show("Kayıt yapan kişi 20 karakterden fazla olamaz.");
                    goto Bitis;
                }
                goto Insert;
            }
            Insert: {
                string sorgu = "Insert into kisi (no,adsoyad,tel,dosya,aciklama,sira,kart,basankisi,kayitkisi,tarih) values (@no,@adsoyad,@tel,@dolap,@dosya,@aciklama,@sira,@kart,@basankisi,@kayitkisi,@tarih)";
                cmd = new SqlCommand(sorgu, con);
                con.Open();
                cmd.Parameters.AddWithValue("@no", textBox1.Text);
                cmd.Parameters.AddWithValue("@adsoyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@tel", textBox3.Text);
                cmd.Parameters.AddWithValue("@dosya", textBox5.Text);
                cmd.Parameters.AddWithValue("@aciklama", textBox6.Text);
                cmd.Parameters.AddWithValue("@sira", textBox7.Text);
                cmd.Parameters.AddWithValue("@kart", textBox8.Text);
                cmd.Parameters.AddWithValue("@basankisi", textBox9.Text);
                cmd.Parameters.AddWithValue("@kayitkisi", textBox10.Text);
                cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                griddoldur();
            }
        Bitis: { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("TC Kimlik Numarası eksik.");
                goto Bitir;
            }
            else
            {
                if (textBox6.Text.Length > 254)
                {
                    MessageBox.Show("Açıklama 255 karakterden fazla olamaz.");
                    goto Bitir;
                }
                if (textBox1.Text.Length != 11)
                {
                    MessageBox.Show("TC Kimlik Numarası 11 karakter olmak zorunda.");
                    goto Bitir;
                }
                if (textBox2.Text.Length > 49)
                {
                    MessageBox.Show("Ad Soyad 50 karakterden fazla olamaz.");
                    goto Bitir;
                }
                if (textBox3.Text.Length > 19)
                {
                    MessageBox.Show("Telefon Numarası 20 karakterden fazla olamaz.");
                    goto Bitir;
                }
                if (textBox5.Text.Length > 19)
                {
                    MessageBox.Show("Dosya Numarası 20 karakterden fazla olamaz.");
                    goto Bitir;
                }
                if (textBox7.Text.Length > 19)
                {
                    MessageBox.Show("Sıra Numarası 20 karakterden fazla olamaz.");
                    goto Bitir;
                }
                if (textBox8.Text.Length > 19)
                {
                    MessageBox.Show("Kart Tipi 20 karakterden fazla olamaz.");
                    goto Bitir;
                }
                if (textBox9.Text.Length > 19)
                {
                    MessageBox.Show("Kartı Basan kişi 20 karakterden fazla olamaz.");
                    goto Bitir;
                }
                if (textBox10.Text.Length > 19)
                {
                    MessageBox.Show("Kayıt yapan kişi 20 karakterden fazla olamaz.");
                    goto Bitir;
                }
                goto Update;
            }
            Update:
            {
                string sorgu = "Update kisi Set adsoyad=@adsoyad,tel=@tel,dosya=@dosya,aciklama=@aciklama,sira=@sira,kart=@kart,basankisi=@basankisi,kayitkisi=@kayitkisi,tarih=@tarih Where no=@no";
                cmd = new SqlCommand(sorgu, con);
                con.Open();
                cmd.Parameters.AddWithValue("@no", textBox1.Text);
                cmd.Parameters.AddWithValue("@adsoyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@tel", textBox3.Text);
                cmd.Parameters.AddWithValue("@dosya", textBox5.Text);
                cmd.Parameters.AddWithValue("@aciklama", textBox6.Text);
                cmd.Parameters.AddWithValue("@sira", textBox7.Text);
                cmd.Parameters.AddWithValue("@kart", textBox8.Text);
                cmd.Parameters.AddWithValue("@basankisi", textBox9.Text);
                cmd.Parameters.AddWithValue("@kayitkisi", textBox10.Text);
                cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                griddoldur();
            }
        Bitir: { }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from kisi where no=" + textBox1.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
            MessageBox.Show("Kayıt Silindi.");
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            griddoldur();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-BAV2LIP\\SQLEXPRESS;Initial Catalog=DENEME;Integrated Security=True");
            con.Open();
            string arama = "Select *From kisi where no like '%" + textBox1.Text + "%' and adsoyad like '%" + textBox2.Text + "%' and tel like '%" + textBox3.Text + "%' and dosya like '%" + textBox5.Text + "%'and aciklama like '%" + textBox6.Text + "%'and sira like '%" + textBox7.Text + "%'and kart like '%" + textBox8.Text + "%'and basankisi like '%" + textBox9.Text + "%'and kayitkisi like '%" + textBox10.Text + "%'";           
            da = new SqlDataAdapter(arama,con);
            ds = new DataSet();
            da.Fill(ds, "kisi");
            dataGridView1.DataSource = ds.Tables["kisi"];
            con.Close();
        }
    }
}
