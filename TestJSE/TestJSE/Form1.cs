using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace TestJSE
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string searchTerm = textBox1.Text.Trim();
            string query = "SELECT s.identity_card,CONCAT(s.names,' ',s.surnames), c.name " +
                            "FROM Students AS s INNER JOIN Schools AS c " +
                            "ON s.id_school = c.id " +
                            "WHERE s.names LIKE @SearchTerm " +
                            "OR s.surnames LIKE @SearchTerm " +
                            "OR CONVERT(VARCHAR, s.date_of_birth, 103) LIKE @SearchTerm " +
                            "OR c.name LIKE @SearchTerm;";
            DataTable dataTable = new DataTable();

            String connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {             
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);

                        // Bind the search results to your DataGridView
                        dvgStudents.DataSource = dataTable;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("StudentsData", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }

            dvgStudents.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            // Asegurarse de que la celda seleccionada no sea el encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dvgStudents.Rows[e.RowIndex];

                // Obtener el valor de la celda en la columna del ID
                int estudianteID = Convert.ToInt32(filaSeleccionada.Cells["identity_card"].Value);

                Form2 f2 = new Form2(estudianteID);

                f2.IdentityCard = estudianteID;

                f2.Show();
                // Luego, puedes utilizar estudianteID según tus necesidades
            }


            
        }

        private void lblHelloWorld_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("StudentsData", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }

            dvgStudents.DataSource = dt;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
