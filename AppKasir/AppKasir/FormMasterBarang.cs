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

namespace AppKasir
{
    public partial class FormMasterBarang : Form
    {
        private OleDbCommand cmd;
        private DataSet ds;
        private OleDbDataAdapter da;
        private OleDbDataReader rd;

        Koneksi Konn = new Koneksi();

        void munculSatuan()
        {
            comboBox1.Items.Add("PCS");
            comboBox1.Items.Add("BOX");
            comboBox1.Items.Add("BOTOL");
            comboBox1.Items.Add("PAX");
            comboBox1.Items.Add("KILO");
            comboBox1.Items.Add("KARUNG");
        }

        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            munculSatuan();
            MunculDataBarang();
        }

        void MunculDataBarang()
        {
            OleDbConnection conn = Konn.GetConn();
            cmd = new OleDbCommand("select * from tb_barang", conn);
            ds = new DataSet();
            da = new OleDbDataAdapter(cmd);
            da.Fill(ds, "tb_barang");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tb_barang";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        public FormMasterBarang()
        {
            InitializeComponent();
        }

        private void FormMasterBarang_Load(object sender, EventArgs e)
        {
            KondisiAwal();   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Semua Form Terisi!!");
            }
            else
            {
                OleDbConnection conn = Konn.GetConn();
                cmd = new OleDbCommand("insert into tb_barang values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Di Input");
                KondisiAwal();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                OleDbConnection conn = Konn.GetConn();
                cmd = new OleDbCommand("select * from tb_barang where KodeBarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox1.Text = rd[0].ToString();
                    textBox2.Text = rd[1].ToString();
                    textBox3.Text = rd[2].ToString();
                    textBox3.Text = rd[3].ToString();
                    textBox3.Text = rd[4].ToString();
                    comboBox1.Text = rd[5].ToString();
                }
                else
                {
                    MessageBox.Show("Data Tidak Ada!!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" ||  comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Semua Form Terisi!!");
            }
            else
            {
                OleDbConnection conn = Konn.GetConn();
                cmd = new OleDbCommand("Update tb_barang set NamaBarang='" + textBox2.Text + "',HargaBeli='" + textBox3.Text + "',HargaJual='" + textBox4.Text + "',JumlahBarang='" + textBox5.Text + "',SatuanBarang='" + comboBox1.Text + "' where KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Di Edit");
                KondisiAwal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" ||  comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Semua Form Terisi!!");
            }
            else
            {
                OleDbConnection conn = Konn.GetConn();
                cmd = new OleDbCommand("Delete tb_kasir where KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Di Hapus");
                KondisiAwal();
            }
        }
    }
}
