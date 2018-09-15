using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Veoxteam.DistributedSystems.DialogFlow.Helpers
{
    public class BaseProxy
    {
        protected readonly string _path;

        protected BaseProxy(string path)
        {
            _path = path;
        }

        protected Response<T> Ejecutar<T>(string recurso, HttpMethod metodo = HttpMethod.Get, object parametro = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_path);
                    client.DefaultRequestHeaders.Add("ContentType", "application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "d815d9b44f6e40fda80dd8bdbf0b8eb3");

                    HttpResponseMessage resultadoApi;

                    switch (metodo)
                    {
                        case HttpMethod.Post:
                            {
                                string json = parametro == null ? string.Empty : JsonConvert.SerializeObject(parametro);
                                resultadoApi = client.PostAsync(recurso, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                                break;
                            }
                        case HttpMethod.Put:
                            {
                                string json = parametro == null ? string.Empty : JsonConvert.SerializeObject(parametro);
                                resultadoApi = client.PutAsync(recurso, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                                break;
                            }
                        default:
                            {
                                resultadoApi = client.GetAsync(_path + recurso).Result;
                                break;
                            }
                    }

                    if (resultadoApi.IsSuccessStatusCode)
                    {
                        string resultado = resultadoApi.IsSuccessStatusCode ? resultadoApi.Content.ReadAsStringAsync().Result : string.Empty;

                        if (string.IsNullOrEmpty(resultado))
                            throw new Exception("No se obtuvo resultados de la consulta.");

                        return new Response<T>(JsonConvert.DeserializeObject<T>(resultado));
                    }
                    else
                    {
                        string error = resultadoApi.ReasonPhrase;

                        throw new Exception(error);
                    }
                }
            }
            catch (Exception excepcion)
            {
                return new Response<T>(excepcion.Message, excepcion.StackTrace);
            }
        }
    }

    public enum HttpMethod
    {
        Get,
        Post,
        Put,
        Delete
    }
}
