using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Definimos la Ruta del archivo CSV que se va a leer
            string filePath = "D://Descargas/ConsoleApp.csv";

            // Verificar si el archivo existe
            if (File.Exists(filePath))
            {
                // Procesar el archivo CSV segun los requerimientos
                ProcessCsv(filePath);
            }
            else
            {
                Console.WriteLine("El archivo CSV no existe.");
            }
        }

        static void ProcessCsv(string filePath)
        {
            // Ruta del archivo de salida con los datos requeridos
            string outputPath = "D://Descargas/customer_summary.txt";

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                // Configuramos el separador de nuestro archivo .csv
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Abrir el archivo de salida para escritura
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    // Leer la cabecera (encabezado) del archivo CSV
                    string[] header = parser.ReadFields();

                    // Escribir la información procesada en el archivo de salida
                    writer.WriteLine("Processed Data:");

                    // definimos nuestras variables para poder obtener los datos necesarios
                    int a = 0;

                    string correo = "";
                    int count = 0;

                    // leemos todas las filas del archivo
                    while (!parser.EndOfData)
                    {
                        // leemos los campos
                        string[] fields = parser.ReadFields();
                        int.TryParse(fields[0], out int b); // sacamos el id

                        if (b > a) 
                        {
                           a = b;
                           correo = fields[3]; // asignamos el correo si es que es mayor el id
                        }

                        count++; // contamos las filas del archivo
                        
                    }

                    // Escribimos el numero de clientes
                    writer.WriteLine($"El numero de clientes es: {count}");

                    // Escribimos el correo
                    writer.WriteLine($"El correo con el mayor id es: {correo}");

                    Console.WriteLine("Proceso completado. Resultados guardados en 'customer_summary.txt'.");
                }
            }
        }
    }
}
