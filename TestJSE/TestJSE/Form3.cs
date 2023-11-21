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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            string query = "DECLARE @max_id AS INT; " + // realizamos la inserción de los campos segun los datos en la vista
                           "SET @max_id = (SELECT MAX(identity_card) from Students);" +
                           "INSERT INTO Students(identity_card,names,surnames,date_of_birth,id_school) Values (@max_id+1,@names,@surnames,@date_of_birth,@ID_School);";

            DateTime.TryParse(textBox3.Text, out DateTime nuevaFechaNacimiento); // transformamos a una nueva fehca de nacimiento

            String connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@names", textBox1.Text); // asignamos los valores de actualizacion
                    cmd.Parameters.AddWithValue("@surnames", textBox2.Text);
                    cmd.Parameters.AddWithValue("@date_of_birth", nuevaFechaNacimiento.Date);
                    cmd.Parameters.AddWithValue("@ID_School", textBox4.Text);

                    int filasActualizadas = cmd.ExecuteNonQuery();
                }
            }

            this.Close();
        }
    }
}
