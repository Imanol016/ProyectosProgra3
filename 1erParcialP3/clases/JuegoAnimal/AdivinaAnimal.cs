using _1erParcialP3.clases.ArbolBinario;
using _1erParcialP3.clases.Conexion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1erParcialP3.clases.JuegoAnimal
{
    class AdivinaAnimal
    {
        MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=juego_adi_animal; Uid=root; Pwd=45445302;");
        clsConexion conexionMySql = new clsConexion();
        public static Nodo raiz;

        public AdivinaAnimal()
        {
            raiz = new Nodo("Elefante");
        }

        public void jugar()
        {
            Nodo nodo = raiz;

            while (nodo != null) //interacion del arbol
            {
                if (nodo.izquierda != null) //existe una pregunta
                {
                    Console.WriteLine(nodo.valorNodo());
                    nodo = (respuesta()) ? nodo.izquierda : nodo.derecha;
                }
                else
                {
                    Console.WriteLine($"Ya se, es un {nodo.valorNodo()}");
                    if (respuesta())
                    {
                        Console.WriteLine("Gane!!!!   :)");
                    }
                    else
                    {
                        animalNuevo(nodo);
                    }
                    nodo = null;
                    return;
                } //fin if
            } //fin while
        } //fin jugar

        public bool respuesta()
        {
            while (true)
            {
                String resp = Console.ReadLine().ToLower().Trim();
                if (resp.Equals("si")) return true;
                if (resp.Equals("no")) return false;
                Console.WriteLine("La respuesta dee ser si o no");
            }
        } // fin respuesta

        public void animalNuevo(Nodo nodo)
        {
            String animalNodo = (String)nodo.valorNodo();
            Console.WriteLine("Cual es tu animal pues?");
            String nuevoA = Console.ReadLine();
            Console.WriteLine($"Que pregunta con respuesta si / no puedo hacer para poder decir que es un {nuevoA}");
            string pregunta = Console.ReadLine();
            Nodo nodo1 = new Nodo(animalNodo);
            Nodo nodo2 = new Nodo(nuevoA);
            Console.WriteLine($"Para un(a) {nuevoA} la respuesta es si / no ?");
            nodo.nuevoValor(pregunta + "?");

            if (respuesta())
            {
                nodo.izquierda = nodo2;
                nodo.derecha = nodo1;
                conexion.Open();

                string Query = "INSERT INTO adivina_animal (animal, descripcion) values ('" + nuevoA +"','" + pregunta + "');";
                MySqlCommand comando = new MySqlCommand(Query, conexion);
            
                comando.ExecuteNonQuery();
                conexion.Close();
                //conexionMySql.insertar();
            }
            else
            {
                nodo.izquierda = nodo1;
                nodo.derecha = nodo2;
            }
        }
    }
}
