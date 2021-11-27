using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4WebApi
{
    public class WebApiHelper<T>
    {
        HttpClient client = new HttpClient();
        string url = ConfigurationManager.AppSettings["ApiAddress"].ToString();

        public async Task<IEnumerable<T>> GetListAsync(string path)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync(path.TrimEnd('/'));
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    IEnumerable<T> items = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                    return items;
                }
                else
                    return Enumerable.Empty<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Enumerable.Empty<T>();
        }

        public async Task<T> GetByIdAsync(string path, int id)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response;
                response = await client.GetAsync($"{path.TrimEnd('/')}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    T item = JsonConvert.DeserializeObject<T>(json);
                    return item;
                }
                else 
                    return default(T);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return default(T);
        }

        public async Task<T> AddAsync(string path, T item)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response;
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(path.TrimEnd('/'), content);

                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
                T item2 = JsonConvert.DeserializeObject<T>(json);
                return item2;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return default(T);
        }

        public async Task<bool> UpdateAsync(string path, int id, T item)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response;
                response = await client.PutAsJsonAsync($"{path.TrimEnd('/')}/{id}", item);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public async Task<bool> DeleteAsync(string path, int id)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response;
                response = await client.DeleteAsync($"{path.TrimEnd('/')}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}
