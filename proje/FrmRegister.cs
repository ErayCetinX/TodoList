using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proje
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            string Sql = "select * from \"Roles\"";
            SqlDataReader Oku = Connections.Reader(Sql);
            while (Oku.Read())
            {
                comboBox1.Items.Add(Oku["roleName"].ToString());
            }
            Oku.Close();
            Oku.Dispose();

            string projectSql = "select * from \"Project\"";
            SqlDataReader projectSqlQuery = Connections.Reader(projectSql);
            while (projectSqlQuery.Read())
            {
                projectName.Items.Add(projectSqlQuery["projectName"].ToString());
            }
            projectSqlQuery.Close();
            projectSqlQuery.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
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
                            MessageBox.Show("Girilen bilgilerle kullanıcı vardır tekrar deneyin.");
                            username.Text = "";
                            password.Text = "";
                            projectName.Text = "";
                        }
                        else
                        {
                            string Sql = "insert into \"Users\" (username,password, roleName, projectName) values(@username, @password, @roleName, @projectName)";
                            SqlParameter[] Param = new SqlParameter[] {
                                new SqlParameter("username", username.Text),
                                new SqlParameter("password",password.Text),
                                new SqlParameter("roleName",comboBox1.SelectedItem),
                                new SqlParameter("projectName", projectName.Text)
                            };

                            string createProjectUser = $"insert into \"Project\" (projectName, author) values('{projectName.Text}', '{username.Text}')";

                            SqlDataReader create = Connections.Reader(createProjectUser);
                            SqlDataReader Reader = Connections.Reader(Sql, Param);

                            create.Close();
                            create.Dispose();
                            Reader.Close();
                            Reader.Dispose();
                            FrmHome frmHome = new FrmHome(username.Text);
                            this.Close();
                            frmHome.Show();
                            username.Text = "";
                            password.Text = "";
                            projectName.Text = "";
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
