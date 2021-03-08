using _1erParcialP3.clases.JuegoAnimal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1erParcialP3.clases.Conexion
{

    class clsConexion
    {
        MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=juego_adi_animal; Uid=root; Pwd=45445302;");
        
        public void abrirConexion()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Error de conexion!!");
            }
        }

        public void buscar()
        {
            
            conexion.Close();
        }
        /*
        public void insertar()
        {
            AdivinaAnimal nuevoAnimal = new AdivinaAnimal();

            conexion.Open();
            string Query = "INSERT INTO adivina_animal (animal, descripcion) values ('" +  + "','" + AdivinaAnimal.raiz.derecha + "');";
            MySqlCommand comando = new MySqlCommand(Query, conexion);

            comando.ExecuteNonQuery();
            conexion.Close();
            
        }
        */
    }
}
