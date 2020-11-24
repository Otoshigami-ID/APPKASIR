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
    public partial class FormMasterKasir : Form
    {
        private OleDbCommand cmd;
        private DataSet ds;
        private OleDbDataAdapter da;
        private OleDbDataReader rd;

        Koneksi Konn = new Koneksi();

        void munculLevel()
        {
            comboBox1.Items.Add("ADMIN");
            comboBox1.Items.Add("USER");
        }

        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            munculLevel();
            MunculDataKasir();
        }
        public FormMasterKasir()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void MunculDataKasir()
        {
            OleDbConnection conn = Konn.GetConn();
            cmd = new OleDbCommand("select * from tb_kasir", conn);
            ds = new DataSet();
            da = new OleDbDataAdapter(cmd);
            da.Fill(ds, "tb_kasir");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tb_kasir";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
        }

        private void FormMasterKasir_Load(object sender, EventArgs e)
        {
            KondisiAwal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Semua Form Terisi!!");
            }
            else
            {
                OleDbConnection conn = Konn.GetConn();
                cmd = new OleDbCommand("insert into tb_kasir values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "')", conn);
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
                cmd = new OleDbCommand("select * from tb_kasir where KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox1.Text = rd[0].ToString();
                    textBox2.Text = rd[1].ToString();
                    textBox3.Text = rd[2].ToString();
                    comboBox1.Text = rd[3].ToString();
                }
                else
                {
                    MessageBox.Show("Data Tidak Ada!!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Semua Form Terisi!!");
            }
            else
            {
                OleDbConnection conn = Konn.GetConn();
                cmd = new OleDbCommand("Update tb_kasir set NamaKasir='" + textBox2.Text + "',PasswordKasir='" + textBox3.Text + "',levelKasir='" + comboBox1.Text + "' where KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Di Edit");
                KondisiAwal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
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
