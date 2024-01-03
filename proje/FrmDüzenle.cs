using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proje
{
    public partial class FrmDüzenle : Form
    {
        string username;
        public FrmDüzenle(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void FrmProjeOlustur_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string createProjectCommand = $"insert into \"Project\" (author, projectName) values ('{username}', '{textBox1.Text}')";
            SqlDataReader createProjectQuery = Connections.Reader(createProjectCommand);
            createProjectQuery.Close();
            createProjectQuery.Dispose();

            FrmHome frmHome = new FrmHome(username);
            frmHome.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string deleteProjectCommand = $"DELETE FROM Project WHERE projectName = '{textBox2.Text}'";
            SqlDataReader deleteProjectQuery = Connections.Reader(deleteProjectCommand);
            deleteProjectQuery.Close();
            deleteProjectQuery.Dispose();

            FrmHome frmHome = new FrmHome(username);
            frmHome.Show();
            this.Close();
        }
    }
}
