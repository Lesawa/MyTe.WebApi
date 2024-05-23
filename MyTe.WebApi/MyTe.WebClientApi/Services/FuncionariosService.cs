using MyTe.WebClientApi.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace MyTe.WebClientApi.Services
{
    public class FuncionariosService
    {
        private readonly HttpClient httpClient;
        public FuncionariosService(IHttpClientFactory client)
        {
            httpClient = client.CreateClient();

            httpClient.BaseAddress = new Uri("http://localhost:5081/");//se fosse para conectar com o azure, colocaria o caminho de lá aqui
            httpClient.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<FuncionarioClient>> ListarFuncionariosAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/funcionariosapi");
                if (response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<FuncionarioClient[]>();
                    return lista!.ToList();
                }
                else
                {
                    throw new Exception("Não foi possível obter a lista de Funcionario");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task IncluirFuncionarioAsync(FuncionarioClient funcionario)
        {
            try
            {
                // gerar o json a partir do objeto fornecido como parâmetro
                string json = JsonConvert.SerializeObject(funcionario);

                // gerar o fluxo de bytes para a API
                HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

                // enviando o objeto para a API
                var response = await httpClient.PostAsync("api/funcionariosapi", content);
                if (!response.IsSuccessStatusCode)
                {
                    string erro = $"Erro: {response.StatusCode} - {response.ReasonPhrase}";
                    throw new Exception(erro);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
