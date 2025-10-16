using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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

                    var  response = client.PostAsJsonAsync("api/SendEmail", email);
                    var result = response.Result;
                    if (response.Result.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
            }catch(Exception ex)
            {
                throw ex;
            }

            
        }
    }
}