using FreelaCash.Dominio;
using FreelaCashWEB.Models;
using FreelaCashWEB.Services.Interface;
using Microsoft.AspNetCore.Routing;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using RestSharp;

namespace FreelaCashWEB.Services.Repository
{
    public class LoginRepository : ILoginService
    {
        //private static readonly string UrLBaseWs = ConfigurationManager.AppSettings["UrLBaseWsSantaRita"];
        private static readonly string UrLBaseWs = "https://localhost:7230/";

        public async Task<RetornoAuth> LoginAsync(Login model)
        {
            try
            {
                var loginJson = JsonConvert.SerializeObject(model);
                var client = new RestClient(UrLBaseWs+"api/Account/Login");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Authorization", "Bearer " + token + "");
                request.AddParameter("application/json", "" + loginJson + "", ParameterType.RequestBody);
                var response = await client.PostAsync(request);
                var jsonObject = JsonConvert.DeserializeObject<RetornoAuth>(response.Content);
                return jsonObject;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
