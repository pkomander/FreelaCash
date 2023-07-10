using FreelaCashWEB.Models;
using FreelaCashWEB.Services.Interface;
using Newtonsoft.Json;
using RestSharp;

namespace FreelaCashWEB.Services.Repository
{
    public class ServicoRepository : IServicoService
    {
        private static readonly string UrLBaseWs = "https://localhost:7230/";

        public async Task<Servico> AdicionaServicoAsync(string token, Servico model)
        {
            try
            {
                var loginJson = JsonConvert.SerializeObject(model);
                var client = new RestClient(UrLBaseWs + "api/Account/Login");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Authorization", "Bearer " + token + "");
                request.AddParameter("application/json", "" + loginJson + "", ParameterType.RequestBody);
                var response = await client.PostAsync(request);
                var jsonObject = JsonConvert.DeserializeObject<Servico>(response.Content);
                return jsonObject;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Servico> RecuperaServicoIdAsync(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Servico>> RecuperaServicosAsync(string token)
        {
            try
            {
                var client = new RestClient(UrLBaseWs + "api/servico");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token + "");
                //request.AddParameter("application/json", "" + loginJson + "", ParameterType.RequestBody);
                var response = await client.GetAsync(request);
                var jsonObject = JsonConvert.DeserializeObject<List<Servico>>(response.Content);
                return jsonObject;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Servico> UpdateServicoIdAsync(string token, Servico model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletaServicoIdAsync(string token, int servicoId)
        {
            throw new NotImplementedException();
        }
    }
}
