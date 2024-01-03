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
    public partial class Connections : Form
    {
        public Connections()
        {
            InitializeComponent();
        }

        private void Connections_Load(object sender, EventArgs e)
        {

        }
        public static SqlConnection Baglanti()
        {
            SqlConnection Baglan = new SqlConnection("Data Source=ERAY;Initial Catalog=gtsDB;Integrated Security=True");
            Baglan.Open();
            return Baglan;
        }

        // CRUD
        public static SqlDataReader Reader(string Sql, SqlParameter[] Param = null)
        {
            SqlConnection Baglan = Baglanti();
            SqlCommand Command = new SqlCommand(Sql, Baglan);
            if (Param != null)
            {
                Command.Parameters.AddRange(Param);
            }
            SqlDataReader Read = Command.ExecuteReader(CommandBehavior.CloseConnection);
            Command.Dispose();
            return Read;
        }

        public static DataTable VeriTablosu(string Sql, SqlParameter[] Param = null)
        {
            DataTable Tablo = new DataTable();
            SqlConnection Baglan = Baglanti();
            SqlCommand Yonet = new SqlCommand(Sql, Baglan);

            if (Param != null)
            {
                Yonet.Parameters.AddRange(Param);
            }
            SqlDataAdapter VeriAdaptoru = new SqlDataAdapter(Yonet);
            VeriAdaptoru.Fill(Tablo);
            Yonet.Dispose();
            Yonet.Parameters.Clear();
            Baglan.Close();
            Baglan.Dispose();
            return Tablo;
        }
    }
}
