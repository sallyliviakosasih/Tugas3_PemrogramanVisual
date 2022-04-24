using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Tugas3_PV_Kasir_Sally_Livia_Kosasih_201401025
{
    public partial class Form1 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        
        
        koneksi Konn = new koneksi();
        public Form1()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Tampil_Barang();
            Bersihkan();
        }
        //menampilkan tabel
        void Tampil_Barang()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * from TBL_BARANG", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "TBL_BARANG");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TBL_BARANG";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        //reset kolom
        void Bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        //Membuat tombol Simpan
        private void button_simpan(object sender, EventArgs e)
        {
            //Memeriksa apakah tombol text kosong
            if(textBox1.Text.Trim()  == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim()== "")
            {
                MessageBox.Show("Kolom tidak boleh Kosong");
            }
            else
            {
                //Menyimpan data yang diinput
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO TBL_BARANG VALUES ('" + textBox1.Text + "','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+ "','" + textBox5.Text + "','" + textBox6.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Ditambahkan");
                    Tampil_Barang();
                    Bersihkan();
                }
                catch(Exception X)
                {
                    MessageBox.Show(X.ToString());
                    Bersihkan();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["KodeBarang"].Value.ToString();
                textBox2.Text = row.Cells["NamaBarang"].Value.ToString();
                textBox3.Text = row.Cells["HargaJual"].Value.ToString();
                textBox4.Text = row.Cells["HargaBeli"].Value.ToString();
                textBox5.Text = row.Cells["JumlahBarang"].Value.ToString();
                textBox6.Text = row.Cells["SatuanBarang"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }
        //update data
        private void button2_Click(object sender, EventArgs e)
        {
            //Memeriksa apakah tombol text kosong
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Kolom tidak boleh Kosong");
            }
            else
            {
                //Menyimpan data yang diinput
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("UPDATE TBL_BARANG SET KodeBarang = '" + textBox1.Text + "', NamaBarang = '" + textBox2.Text + "', HargaJual = '" + textBox3.Text + "', HargaBeli = '" + textBox4.Text + "', JumlahBarang = '" + textBox5.Text + "', SatuanBarang = '" + textBox6.Text + "'WHERE KodeBarang = '"+textBox1.Text+"'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Diupdate");
                    Tampil_Barang();
                    Bersihkan();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                    Bersihkan();
                }
            }
        }

        //hapus data
        private void button3_Click(object sender, EventArgs e)
        {
            //Memeriksa apakah tombol text kosong
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Data tidak dapat dihapus");
            }
            else
            {
                if (MessageBox.Show("Apakah Anda Ingin Menghapus Data?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SqlConnection conn = Konn.GetConn();
                    try
                    {
                        cmd = new SqlCommand("DELETE FROM TBL_BARANG WHERE KodeBarang = '" + textBox1.Text + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil dihapus");
                        Tampil_Barang();
                        Bersihkan();
                    }
                    catch (Exception X)
                    {
                        MessageBox.Show(X.ToString());
                        Bersihkan();
                    }
                }
            }
        }
    }
}