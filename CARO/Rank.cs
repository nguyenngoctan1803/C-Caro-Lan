using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CARO
{
    public partial class Rank : Form
    {

        DataTable dt = new DataTable();
        string constr = "server=localhost;Uid=root;Pwd=;Database=gamecaro;CharSet=utf8";
        
        public Rank()
        {
            InitializeComponent();
            
        }

        private void Rank_Load(object sender, EventArgs e)
        {

            loaddata();

            
        }

        public void loaddata()
        {
            string query = "SELECT * From caro";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                da.Fill(dt);

            }
            dt.DefaultView.Sort = "Score DESC";
            dt = dt.DefaultView.ToTable();
            int i = 0;
            int flag = 0;
            foreach (DataRow x in dt.Rows)
            {
                if (Convert.ToInt32(x["Score"]) == flag)
                {
                    x["Rank"] = i;
                }
                else
                {
                    i += 1;
                    x["Rank"] = i;
                }

                flag = Convert.ToInt32(x["Score"]);
            }
            dt.Columns.Remove("Id");
            dataGridView1.DataSource = dt;
        }
        public bool isNewPlayer(string name)
        {
            foreach (DataRow x in dt.Rows)
            {
                if (x["Name"].ToString() == name)
                {
                    return false;
                }
            }
            return true;
        }
        public void add_Player(string name)
        {
            loaddata();
            if (isNewPlayer(name))
            {
                int dem = dt.Rows.Count;
                dem = dem + 1;
                string query = string.Format("INSERT INTO caro VALUES ('{0}', '{1}','{2}','{3}')", dem, name, 0, 0);
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    int result = cmd.ExecuteNonQuery();
                    if(result == 1)
                    {   
                        //MessageBox.Show("thành công");
                        loaddata();
                    }
                    
                }
            }
            
            
        }
        public void Update_Score(string name)
        {
            loaddata();
            DataRow[] x = dt.Select("Name='" + name + "'");
            int score = Convert.ToInt32(x[0]["Score"]);
            score = score + 1;
            string query = string.Format("UPDATE caro SET Score = {0} WHERE Name = '{1}'", score, name);
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    //MessageBox.Show("thành công");
                    loaddata();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
