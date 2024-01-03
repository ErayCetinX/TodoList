using System;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;


namespace proje
{
    public partial class FrmOlustur : Form
    {
        public event EventHandler VeriEklendi;
    
        string authorName;
        string projectName;

        public FrmOlustur(string projectName, string authorName, ListBox Todos, ListBox Done, ListBox Doing)
        {
            InitializeComponent();
            this.authorName = authorName;
            this.projectName = projectName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Sql = "insert into \"Works\" (workName, authorName, projectName, type) values(@workName, @authorName, @projectName, @type)";
            SqlParameter[] Param = new SqlParameter[] {
                new SqlParameter("workName", workName.Text),
                new SqlParameter("authorName",authorName),
                new SqlParameter("projectName", projectName),
                new SqlParameter("type", comboBox1.SelectedItem)
            };

            SqlDataReader Reader = Connections.Reader(Sql, Param);
            Reader.Close();
            Reader.Dispose();
            workName.Text = "";
    
            this.Close();
            FrmProje frmProje = new FrmProje(authorName, projectName);
            frmProje.Show();
        }
    }
}
