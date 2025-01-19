using System;

using System.Text.Json;
using System.Text.Json.Serialization;

using System.Linq;

using FundamentosCSHARP.Models;
using FundamentosCSHARP.Service;

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

            var cerveza = JsonSerializer.Deserialize<Cerveza>(myJson);
        }

        async Task GetAllExampleJson()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var posts = JsonSerializer.Deserialize<List<Post>>(content);



            }
        }

        async Task PostExampleJson()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();

            Post post = new Post();
            post.userId = 50;
            post.title = "titulo de saludo 1 ";
            post.body = "Hola como están desde el body 1";

            var data = JsonSerializer.Serialize<Post>(post);

            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                var postResult = JsonSerializer.Deserialize<Post>(result);

            }
        }

        async Task PutExampleJson()
        {
            string url = "https://jsonplaceholder.typicode.com/posts/99";
            HttpClient client = new HttpClient();

            Post post = new Post();
            post.userId = 50;
            post.title = "titulo de saludo 1 ";
            post.body = "Hola como están desde el body 1";

            var data = JsonSerializer.Serialize<Post>(post);

            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await client.PutAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                var postResult = JsonSerializer.Deserialize<Post>(result);

            }
        }

        async Task DeleteExampleJson()
        {
            string url = "https://jsonplaceholder.typicode.com/posts/99";
            HttpClient client = new HttpClient();


            var httpResponse = await client.DeleteAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                var postResult = JsonSerializer.Deserialize<Post>(result);

            }
        }

        async Task ClassGeneric()
        {
            Cerveza cerveza = new Cerveza() { Alcohol = 5, Cantidad = 10, Marca = "Pilsen", Nombre = "Pilsen de trigo" };

            var post = new Post() { userId = 50, title = "titulo del post", body = "body del post" };

            SendRequest<Cerveza> service = new SendRequest<Cerveza>();

            var CervezaResponse = await service.Send(cerveza);
        }

        void HowUseLink()
        {
            List<int> numeros = new List<int>() { 1, 9, 3, 4, 7, 6, 5, 8, 2 };

            //var numero_5 = numeros.Where(x => x == 5).FirstOrDefault();

            //var numerosOrdenados = numeros.OrderBy(x => x).ToList();
            //var numerosOrdenados = numeros.OrderBy(x => x);
            //var suma = numeros.Sum(x => x);
            //var suma = numeros.Average(x => x);

            //Console.WriteLine(suma);
            //foreach (var item in numerosOrdenados)
            //{
            //    Console.WriteLine(item);
            //}


            List<Cerveza> cervezas = new List<Cerveza>() {
                new Cerveza(){ Alcohol=7, Cantidad=20, Nombre="Cerveza de cebada", Marca="Pilsen"} ,
                new Cerveza(){ Alcohol=5, Cantidad=10, Nombre="Cerveza de Malta", Marca="Corona"} ,
                new Cerveza(){ Alcohol=8, Cantidad=15, Nombre="Cerveza de Arroz", Marca="Backup"} ,
                new Cerveza(){ Alcohol=12, Cantidad=30, Nombre="Cerveza de Higo", Marca="Cristal"} ,
            };

            //var ceverzasOrdenadas = from d in cervezas
            //                        orderby d.Nombre
            //                        select d;
            var ceverzasOrdenadas = from d in cervezas
                                    where d.Nombre == "Cerveza de Malta"
                                    select d;

            int cantidad = ceverzasOrdenadas.Count();

            foreach (var cerveza in ceverzasOrdenadas)
            {
                Console.WriteLine($"{cerveza.Nombre} {cerveza.Marca}");
            }
        }
        static async Task Main(string[] args)
        {

           

        }

    }
}


