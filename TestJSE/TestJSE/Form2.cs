using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestJSE
{
    public partial class Form2 : Form
    {
        public Form2(int estudianteID)
        {
            InitializeComponent();

            string query = "SELECT * FROM Students WHERE identity_card = @estudianteID;";

            String connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estudianteID", estudianteID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Verificar si hay filas en el resultado
                        if (reader.Read())
                        {
                            // Obtener el valor de la columna "nombre" del resultado
                            textBox1.Text = reader["names"].ToString();
                            textBox2.Text = reader["surnames"].ToString();
                            textBox3.Text = reader["date_of_birth"].ToString();
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron resultados para el estudiante con el identity_card proporcionado.");
                        }
                    }
                }
            }
        }

        public int IdentityCard { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Students " +  // realizamos la actualizacion de los campos segun los datos en la vista
                           "SET names = @names," +
                           "surnames = @surnames," +
                           "date_of_birth = @date_of_birth" +
                           " WHERE identity_card = @estudianteID";

            DateTime.TryParse(textBox3.Text, out DateTime nuevaFechaNacimiento); // transformamos a una nueva fehca de nacimiento

            String connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estudianteID", IdentityCard); // asignamos los valores de actualizacion
                    cmd.Parameters.AddWithValue("@names", textBox1.Text);
                    cmd.Parameters.AddWithValue("@surnames", textBox2.Text);
                    cmd.Parameters.AddWithValue("@date_of_birth", nuevaFechaNacimiento.Date);

                    int filasActualizadas = cmd.ExecuteNonQuery();
                }
            }

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
