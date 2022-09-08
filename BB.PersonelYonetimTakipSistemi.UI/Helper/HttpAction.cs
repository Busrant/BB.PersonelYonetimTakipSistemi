using BB.PersonelYonetimTakipSistemi.Model.Result;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BB.PersonelYonetimTakipSistemi.UI.Helper
{
    public static class HttpAction
    {

        public static string BaseUrl { get; private set; } = Startup.StaticConfig.GetSection("AppSettings")["baseUrl"];
        //public static string BaseUrl { get; private set; } = "";

        public static async Task<DataResultDto<T>> Get<T>(string Url)
        {
            try
            {
              //  Uri convertedUri = new Uri(BaseUrl+Url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl + Url);
                request.Method = "GET";
                request.ContentLength = 0;
                request.ContentType = "multipart/form-data; charset=UTF-8";
                request.MediaType = "multipart/form-data";
                request.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                //GlobalProxySelection.Select = new WebProxy(convertedUri);
                using var webResponse = request.GetResponse();   //System.Net.WebException: 'The remote server returned an error: (404) Not Found.'
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();

                var dataSerialize = JsonConvert.DeserializeObject<DataResultDto<T>>(data);

                return dataSerialize;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<DataResultDto<T>> Get<T>(string Url,string Token)
        {
            try
            {
                //  Uri convertedUri = new Uri(BaseUrl+Url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl+Url);
                request.Method = "GET";

                if (!string.IsNullOrEmpty(Token))
                    request.Headers.Add("Authorization", "Bearer " + Token);

                request.ContentLength = 0;
                request.ContentType = "multipart/form-data; charset=UTF-8";
                request.MediaType = "multipart/form-data";
                request.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                //GlobalProxySelection.Select = new WebProxy(convertedUri);
                using var webResponse = request.GetResponse();   //System.Net.WebException: 'The remote server returned an error: (404) Not Found.'
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();

                var dataSerialize = JsonConvert.DeserializeObject<DataResultDto<T>>(data);

                return dataSerialize;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> Post<T>(T obj, string Url)
        {
            string result = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create(BaseUrl + Url);
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version11;
                request.Method = "POST";
                request.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                byte[] postBytes = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

                request.ContentType = "application/json; charset=UTF-8";        
                request.Accept = "application/json";                            
                request.ContentLength = postBytes.Length;
                Stream requestStream = await request.GetRequestStreamAsync();

                request.Headers["Content-Type"] = "application/json";           

                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    result = rdr.ReadToEnd();
                }

            }
            catch (System.Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public static async Task<string> Post<T>(T obj, string Url, string Token)
        {
            string result = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create(BaseUrl + Url);
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version11;
                request.Method = "POST";
                request.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                byte[] postBytes = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                request.ContentLength = postBytes.Length;
                Stream requestStream = await request.GetRequestStreamAsync();

                request.Headers["Content-Type"] = "application/json";

                if (!string.IsNullOrEmpty(Token))
                    request.Headers.Add("Authorization", "Bearer "+Token);
              

                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    result = rdr.ReadToEnd();
                }

            }
            catch (System.Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}
