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

namespace proje
{
    public partial class FrmHome : Form
    {
        string username;
        public FrmHome(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        int X = 50;
        int Y = 50;
        int buttonWidth = 65;
        int buttonHeight = 65;

        private void FrmHome_Load(object sender, EventArgs e)
        {
            // burada user verisi alınıp gerekli boxlar olcak
            // bir projenin hangi görevleri var o yazılcak
            // Burada projeleri listelicez

            string sqlForUserProfile = $"select * from \"Users\" where username='{username}'";
            SqlDataReader profileReader = Connections.Reader(sqlForUserProfile);

            if (profileReader.Read())
            {
                Label usernameLabel = new Label
                {
                    Text = username + ' ' + profileReader["roleName"].ToString(),
                    Name = username,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    Location = new Point(20, 20),
                    BackColor = Color.Transparent,
                };

                Controls.Add(usernameLabel);
            }

            string Sql = $"select * from \"Project\" where author='{username}'";
            SqlDataReader Oku = Connections.Reader(Sql);
            while (Oku.Read())
            {
                Button button = new Button();
                button.Text = Oku["projectName"].ToString();
                button.Font = new Font("Arial", 8, FontStyle.Regular);

                button.Name = Oku["projectName"].ToString();
                button.Location = new Point(X, Y);
                button.Width = buttonWidth;
                button.Height = buttonHeight;
                button.MouseClick += Button_MouseClick;

                X += buttonWidth;
                Controls.Add(button);
            }
            Oku.Close();
            Oku.Dispose();
        }

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            FrmProje frmProje = new FrmProje(username,btn.Text);
            frmProje.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void createProject_Click(object sender, EventArgs e)
        {
            FrmDüzenle frmProjeOlustur = new FrmDüzenle(username);
            this.Hide();
            frmProjeOlustur.Show();
        }
    }
}

