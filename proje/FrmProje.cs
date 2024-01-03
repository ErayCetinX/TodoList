using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace proje
{
    public partial class FrmProje : Form
    {
        string username;
        string projectName;
        public FrmProje(string username, string projectName)
        {
            InitializeComponent();
            this.username = username;
            this.projectName = projectName;
        }

        private void FrmProje_Load(object sender, EventArgs e)
        {
            Label title = new Label
            {
                Text = $"{projectName}'s wroks",
                Name = projectName,
                Font = new Font("Arial", 11, FontStyle.Regular),
                AutoSize = true,
            };
            Controls.Add(title);

            string sqlTodo = $"select id, workName from \"Works\" where type = 'todos' and projectName='{projectName}'";
            string sqlDoing = $"select id, workName from \"Works\" where type = 'doing' and projectName='{projectName}'";
            string sqlDone = $"select id, workName from \"Works\" where type = 'done' and projectName='{projectName}'";

            SqlDataReader todoRead = Connections.Reader(sqlTodo);
            SqlDataReader doingRead = Connections.Reader(sqlDoing);
            SqlDataReader doneRead = Connections.Reader(sqlDone);

            while (todoRead.Read())
            {
                Todos.Items.Add(todoRead["workName"].ToString());

            }
            while (doingRead.Read())
            {
                Doing.Items.Add(doingRead["workName"].ToString());
            }

            while (doneRead.Read())
            {
                Done.Items.Add(doneRead["workName"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOlustur frmOlustur = new FrmOlustur(projectName, username, Todos, Done, Doing);
            frmOlustur.Show();
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Todos.SelectedItem != null)
            {
                string selectedWorkName = Todos.SelectedItem.ToString();

                string Sql = $"DELETE FROM Works WHERE workName = '{selectedWorkName}'";
                Connections.Reader(Sql);
                Todos.Items.Remove(selectedWorkName);
            }
            if (Doing.SelectedItem != null)
            {
                string selectedWorkName = Doing.SelectedItem.ToString();

                string Sql = $"DELETE FROM Works WHERE workName = '{selectedWorkName}'";
                Connections.Reader(Sql);
                Doing.Items.Remove(selectedWorkName);
            }
            if (Done.SelectedItem != null)
            {
                string selectedWorkName = Done.SelectedItem.ToString();

                string Sql = $"DELETE FROM Works WHERE workName = '{selectedWorkName}'";
                Connections.Reader(Sql);
                Done.Items.Remove(selectedWorkName);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            FrmHome frmHome = new FrmHome(username);
            frmHome.Show();
            this.Close();
        }
    }
}
