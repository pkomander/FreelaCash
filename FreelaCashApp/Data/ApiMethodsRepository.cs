using FreelaCashApp.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static UIKit.UIGestureRecognizer;

namespace FreelaCashApp.Data
{
    public class ApiMethodsRepository : IApiMethodsService
    {

        private static string _urlEndpointAPI = "https://localhost:7230";
        public async Task<string> CreateAccountAsync(User user)
        {
            try
            {
                var jsonUser = JsonConvert.SerializeObject(user);

                string endpoint = $"{_urlEndpointAPI}/api/Account/Register";

                var client = new RestClient(endpoint);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Authorization", "Bearer " + token + "");
                request.AddParameter("application/json", jsonUser, ParameterType.RequestBody);
                var response = await client.PostAsync(request);
                var retorno = JsonConvert.DeserializeObject<string>(response.Content);
                //var retorno = JsonConvert.DeserializeObject<User>(response.Content);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Cadastrar usuario. Erro: {ex.Message}");
            }
        }

        public async Task<RetornoLogin> LoginAccountAsync(UserLogin userLogin)
        {
            try
            {
                var jsonUser = JsonConvert.SerializeObject(userLogin);

                string endpoint = $"{_urlEndpointAPI}/api/Account/Login";

                var client = new RestClient(endpoint);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Authorization", "Bearer " + token + "");
                request.AddParameter("application/json", jsonUser, ParameterType.RequestBody);
                var response = await client.PostAsync(request);
                var retorno = JsonConvert.DeserializeObject<RetornoLogin>(response.Content);
                //var retorno = JsonConvert.DeserializeObject<User>(response.Content);
                return retorno;
            }
            catch (Exception ex)
            {
                //throw new Exception($"Erro ao tentar Cadastrar usuario. Erro: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Servico>> GetAllServicosAsync(string token)
        {
            try
            {

                string endpoint = $"{_urlEndpointAPI}/api/Servico";

                var client = new RestClient(endpoint);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token + "");
                //request.AddParameter("application/json", jsonUser, ParameterType.RequestBody);
                var response = await client.GetAsync(request);
                var retorno = JsonConvert.DeserializeObject<List<Servico>>(response.Content);
                //var retorno = JsonConvert.DeserializeObject<User>(response.Content);
                return retorno;
            }
            catch (Exception ex)
            {
                //throw new Exception($"Erro ao tentar Cadastrar usuario. Erro: {ex.Message}");
                return null;
            }
        }

        public async Task<UserUpdate> GetUsertAsync(string token)
        {
            try
            {
                string endpoint = $"{_urlEndpointAPI}/api/Account/GetUser";

                var client = new RestClient(endpoint);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token + "");
                //request.AddParameter("application/json", jsonUser, ParameterType.RequestBody);
                var response = await client.GetAsync(request);
                var retorno = JsonConvert.DeserializeObject<UserUpdate>(response.Content);
                //var retorno = JsonConvert.DeserializeObject<User>(response.Content);
                return retorno;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<UserUpdate> UpdateUsertAsync(string token, UserUpdate userUpdate, Image imagem)
        {
            try
            {
                string endpoint = $"{_urlEndpointAPI}/api/Account/UpdateUser";

                var jsonUser = JsonConvert.SerializeObject(userUpdate);

                var client = new RestClient(endpoint);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token + "");
                request.AddFile("", "/C:/Users/prara/OneDrive/Imagens/1605090798241.jfif");
                request.AddParameter("application/json", jsonUser, ParameterType.RequestBody);
                var response = await client.PutAsync(request);
                var retorno = JsonConvert.DeserializeObject<UserUpdate>(response.Content);
                //var retorno = JsonConvert.DeserializeObject<User>(response.Content);
                return retorno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
