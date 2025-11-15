using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ConsoleAppExercises.Model;
using JsonThreadOperation.Model;


namespace ConsoleAppExercises
{
    public class MyHttpclient
    {
        public async Task<bool> HttpClientEmail()
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://anaiyaan-api-dev.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));

                    var email = new { FromAddress = "subhanuvelusamy@gmail.com", GmailAppPassword = "ggsb tuff qeyz umkp", ToAddress = "subhanu2719gmail.com", Subject = "REST API", Content = "REST API Services" };

                    //string JsonData = JsonConvert.SerializeObject(email);
                    //StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/Json");

                    var response = client.PostAsJsonAsync("api/SendEmail", email);
                    var result = response.Result;
                    if (response.Result.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Patients[] GetPatientsAsync()
        {
            try
            {
                using (var httpclient = new HttpClient())
                {

                    httpclient.BaseAddress = new Uri("https://localhost:44342/");
                    httpclient.DefaultRequestHeaders.Accept.Clear();
                    httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));


                    var patient = new Patients();
                    string JsonData = JsonConvert.SerializeObject(patient);
                    StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/Json");

                    var response = httpclient.GetAsync("api/Json").Result;

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<Patients[]>(response.Content.ReadAsStringAsync().Result);
                    else
                        throw new Exception($"{response.Content.ReadAsStringAsync().Result}");
                }
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Register[] GetRegisterAsync()
        {
            try
            {
                using (var httpclient = new HttpClient())
                {

                    httpclient.BaseAddress = new Uri("https://localhost:44342/");
                    httpclient.DefaultRequestHeaders.Accept.Clear();
                    httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));


                    var register = new Register();
                    string JsonData = JsonConvert.SerializeObject(register);
                    StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/Json");

                    var response = httpclient.GetAsync("api/Register").Result;

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<Register[]>(response.Content.ReadAsStringAsync().Result);
                    else
                        throw new Exception($"{response.Content.ReadAsStringAsync().Result}");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}  