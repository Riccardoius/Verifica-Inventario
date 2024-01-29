using MySql.Data.MySqlClient;

namespace VerificaMySql
{
    public partial class Form1 : Form
    {
        string ConnectionString = "server=127.0.0.1;" +
                                    "database=verificamysql;" +
                                    "uid=verificamysql;" +
                                    "pwd=2iot";
        public Form1()
        {
            InitializeComponent();
            //TestConnessione();
            PololaTabella();
        }

        public void PololaTabella()
        {
            MySqlConnection connessione = new MySqlConnection(ConnectionString);
            try
            {
                connessione.Open();
                string query = "SELECT * FROM inventario";
                MySqlCommand cmd = new MySqlCommand(query, connessione);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dataGridView1.Rows.Add(
                        dr.GetString("Cod-Farnell"),
                        dr.GetString("Cod-Produttore"),
                        dr.GetString("Quantità"),
                        dr.GetString("Prezzo")
                    );
                }

                connessione.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void TestConnessione()
        {
            MySqlConnection connessione = new MySqlConnection(ConnectionString);
            try
            {
                connessione.Open();
                connessione.Close();
            }
            catch
            {
                MessageBox.Show("Impossibile stabilire una connessione al DB");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}