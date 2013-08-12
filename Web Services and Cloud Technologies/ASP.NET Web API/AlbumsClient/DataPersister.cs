namespace AlbumsClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class DataPersister
    {
        private readonly HttpClient client;

        public DataPersister()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri("http://localhost:12312/api/");
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        }

        public IEnumerable<T> GetAll<T>(string controller)
        {
            HttpResponseMessage response = this.client.GetAsync(controller).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<T> result = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                return result;
            }
            else
            {
                Console.WriteLine("({0}) {1}", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public T GetSingle<T>(string controller, int id)
        {
            HttpResponseMessage response = this.client.GetAsync(controller + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                T result = response.Content.ReadAsAsync<T>().Result;
                return result;
            }
            else
            {
                Console.WriteLine("({0}) {1}", (int)response.StatusCode, response.ReasonPhrase);
                return default(T);
            }
        }

        public void Create<T>(string controller, T value)
        {
            HttpResponseMessage response = this.client.PostAsJsonAsync<T>(controller, value).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("{0} created successfully", GetEntityName(controller));
            }
            else
            {
                string s = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("({0}) {1}", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void Update<T>(string controller, int id, T newValue)
        {
            HttpResponseMessage response = this.client.PutAsJsonAsync<T>(controller + "/" + id, newValue).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("{0} updated successfully", GetEntityName(controller));
            }
            else
            {
                Console.WriteLine("({0}) {1}", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void Delete<T>(string controller, int id)
        {
            HttpResponseMessage response = this.client.DeleteAsync(controller + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("{0} deleted successfully", GetEntityName(controller));
            }
            else
            {
                Console.WriteLine("({0}) {1}", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static string GetEntityName(string controller)
        {
            return controller.Replace(controller[0], controller.ToUpper()[0]).Remove(controller.Length - 1);
        }
    }
}