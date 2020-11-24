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
    public partial class FormLogin : Form
    {
        private OleDbCommand cmd;
        private DataSet ds;
        private OleDbDataAdapter da;
        private OleDbDataReader rd;

        Koneksi Konn = new Koneksi();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataReader reader = null;
            OleDbConnection conn = Konn.GetConn();
            {
                conn.Open();
                cmd = new OleDbCommand("select * from tb_kasir where KodeKasir='" + textBox1.Text + "' and PasswordKasir='" + textBox2.Text + "'", conn);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    FormMenuUtama.menu.menuLogin.Enabled = false;
                    FormMenuUtama.menu.menuLogout.Enabled = true;
                    FormMenuUtama.menu.menuMaster.Enabled = true;
                    FormMenuUtama.menu.menuTransaksi.Enabled = true;
                    FormMenuUtama.menu.menuLaporan.Enabled = true;
                    FormMenuUtama.menu.menuUtility.Enabled = true;

                    //FormMenuUtama frmUtama = new FormMenuUtama();
                    //frmUtama.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Username Atau Password Salah");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox1.Text = "KSR001";
            textBox2.Text = "ADMIN";
        }
    }
}
