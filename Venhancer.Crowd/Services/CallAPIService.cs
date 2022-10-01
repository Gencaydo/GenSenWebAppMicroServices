using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers;
using System.Net;
using Venhancer.Crowd.Dtos;

namespace Venhancer.Crowd.Services
{
    public static class CallAPIService
    {
        public static async Task<CreateTokenDto.Response> CallTokenAPI(string _apiUrl, CreateTokenDto.Request _tokenobject, string apiBaseUrl)
        {
            var tokenResponse = new CreateTokenDto.Response();
            try
            {
                var client = new RestClient(apiBaseUrl + _apiUrl);
                var request = new RestRequest();
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", 
                                     $"client_id={_tokenobject.client_id}&" +
                                     $"client_secret={_tokenobject.client_secret}&" +
                                     $"grant_type={_tokenobject.grant_type}&" +
                                     $"username={_tokenobject.username}&" +
                                     $"password={_tokenobject.password}", 
                                     ParameterType.RequestBody);
                var response = await client.ExecutePostAsync(request);
                
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    tokenResponse = JsonConvert.DeserializeObject<CreateTokenDto.Response>(response.Content);
                }
                
                return tokenResponse;
            }
            catch
            {
                return tokenResponse;
            }
        }
        public static async Task<string> CallPostAPI(string _apiUrl,object _postobject,string apiBaseUrl)
        {
            try
            {
                var client = new RestClient(apiBaseUrl + _apiUrl);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                var body = JsonConvert.SerializeObject(_postobject);
                request.AddStringBody(body, ContentType.Json);
                var response = await client.ExecutePostAsync(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
