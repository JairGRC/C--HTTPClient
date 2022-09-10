using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebasRest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44386/api/DatosMatricula/ObtenerDatosMatricula");
             client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent("{\"cPerCodigo\": \"2000067902\",\"nCurCodigo\" : 70003301,\"nPrdCodigo\" : 65000331,\"nUniOrgCodigo\" : 20046,\"nPerAluRegCodigo\" : 7783945,\"vMatTipo\" : \"alumno\",\"Dp_txtCPerApellido\" : \"OLIVA CHANTA\",\"Dp_txtCPerNombre\" : \"DANIELA PIERINA\"}",
                     Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var hola= JsonConvert.DeserializeObject<object>(jsonString);
                Console.WriteLine(hola.ToString());

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();





            //var request = new HttpRequestMessage(HttpMethod.Post, "api/DatosMatricula/ObtenerDatosMatricula");


            
            
            //client.SendAsync(request).ContinueWith(responseTask =>
            //{
            //    Console.WriteLine("Response: {0}", responseTask.Result);
            //    var hola = responseTask.Result.EnsureSuccessStatusCode();
            //}
            //     );
        }
    }
}
