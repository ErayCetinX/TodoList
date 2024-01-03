using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister();
            frmRegister.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text.Length > 0 && password.Text.Length > 0)
            {
                // Kullanıcı var mı kontrol et
                string isUserExistQuery = $"SELECT * FROM Users WHERE username = '{username.Text}' AND password = '{password.Text}'";

                try
                {
                    using (SqlDataReader reader = Connections.Reader(isUserExistQuery))
                    {
                        if (reader.HasRows)
                        {
                            // Kullanıcı bulundu, giriş yap
                            this.Hide(); // veya this.Close();
                            FrmHome frmHome = new FrmHome(username.Text);
                            frmHome.Show();
                        }
                        else
                        {
                            // Kullanıcı bulunamadı, hata mesajı göster
                            MessageBox.Show("Geçersiz kullanıcı adı veya şifre.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

        }
    }
}

