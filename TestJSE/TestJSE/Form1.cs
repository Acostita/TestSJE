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
            
            string searchTerm = textBox1.Text.Trim(); // leemos el texto que queremos buscar
            string query = "SELECT s.identity_card,CONCAT(s.names,' ',s.surnames), c.name " + // seleccionamos la lista
                            "FROM Students AS s INNER JOIN Schools AS c " +                   // de estudiantes con sus
                            "ON s.id_school = c.id " +                                        // respectivos nombres de colegio
                            "WHERE s.names LIKE @SearchTerm " +
                            "OR s.surnames LIKE @SearchTerm " +
                            "OR CONVERT(VARCHAR, s.date_of_birth, 103) LIKE @SearchTerm " +
                            "OR c.name LIKE @SearchTerm;";
            DataTable dataTable = new DataTable();                      // creamos una tabla que se cargará al grid

            String connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {             
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) // ejecutamos la senetencia SQL
                    {
                        adapter.Fill(dataTable); // cargamos los datos a tabla

                        // cargamos los datos de la tabla creada a nuestra grilla o grid
                        dvgStudents.DataSource = dataTable;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;  // nos a nuestra base de datos local
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString)) // establecemos los parametros de la conexion
            {
                conn.Open(); // nos conectamos
                using (SqlCommand cmd = new SqlCommand("StudentsData", conn)) // ejecutamos la sentencia creada en Pregunta1_TestJSE
                {
                    cmd.CommandType = CommandType.StoredProcedure; // definmos como un procedimiento
                    SqlDataReader reader = cmd.ExecuteReader(); // leemos los datos
                    dt.Load(reader); // cargamos los datos
                }
            }

            dvgStudents.DataSource = dt; // cargamos nuestra tabla
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            // Asegurarse de que la celda seleccionada no sea el encabezado
            if (e.RowIndex >= 0) // vamos a querer actualizar valores de una fila
            {
                DataGridViewRow filaSeleccionada = dvgStudents.Rows[e.RowIndex];

                // Obtener el valor de la celda en la columna del ID
                int estudianteID = Convert.ToInt32(filaSeleccionada.Cells["identity_card"].Value); // obtenemos el id de la fila seleccionada

                Form2 f2 = new Form2(estudianteID); // Le pasamos el id a la nueva vista para poder buscar la información necesaria

                f2.IdentityCard = estudianteID;  // definimos una variable en el Form2

                f2.Show(); // mostramos la ventana Form2.
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

        private void button1_Click_3(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
