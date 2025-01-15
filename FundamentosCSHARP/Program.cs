using System;

using FundamentosCSHARP.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FundamentosCSHARP
{
    class Program
    {

        void curso_listas()
        {

            //Cerveza cerveza = new Cerveza(100, "Cerveza Stout");
            //cerveza.Beberse(299);

            int[] numeros = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int numero = numeros[0];

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine(numeros[i]);
            }

            foreach (var item in numeros)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("****************************************");

            List<int> lista = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            lista.Add(0);
            lista.Add(10);
            lista.Remove(10);

            foreach (var item in lista)
            {
                Console.WriteLine("Elemento " + item);
            }

            List<Cerveza> cervezas = new List<Cerveza>() {
                new Cerveza(400, "Cerveza Pilsen"),
                new Cerveza(600)
            };

            Cerveza cristal = new Cerveza(300, "Cerveza Cristal");
            cervezas.Add(cristal);

            foreach (var cerveza in cervezas)
            {
                Console.WriteLine("Cerveza: " + cerveza.Nombre);
            }

        }
        static void MostrarRecomendaciones(IBebidaAlcoholica bebida)
        {
            bebida.MaxRecomendado();
        }
        void CRUD()
        {
            //var bebidaAlcoholica = new Vino(100);
            //MostrarRecomendaciones(bebidaAlcoholica);

            CervezaBD cervezaBD = new CervezaBD();

            // insertamos nueva cerveza
            //{
            //    Cerveza cerveza = new Cerveza(16, "Brahama");
            //    cerveza.Marca = "Backus";
            //    cerveza.Alcohol = 6;
            //    cervezaBD.Add(cerveza);
            //}

            // Editamos una cerveza
            //{
            //    Cerveza cerveza = new Cerveza(16, "Cerveza Brahama");
            //    cerveza.Marca = "Backus";
            //    cerveza.Alcohol = 6;
            //    cervezaBD.Edit(cerveza, 4);
            //}

            // Eliminar una cerveza
            {

                cervezaBD.Delete(4);
            }

            // Obtener todas las cervezas
            var cervezas = cervezaBD.Get();

            foreach (var cerveza in cervezas)
            {
                Console.WriteLine(cerveza.Nombre);
            }
        }
        void HandlerFilesAndJSON()
        {
            //Cerveza cerveza = new Cerveza(100, "Cerveza Cusqueña");
            //string myJson = JsonSerializer.Serialize(cerveza);
            //File.WriteAllText("objeto.txt", myJson);

            string myJson = File.ReadAllText("objeto.txt");

            Cerveza cerveza = JsonSerializer.Deserialize<Cerveza>(myJson);
        }
        static void Main(string[] args)
        {

           



        }

    }
}


