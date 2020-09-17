using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServicioPrueba.Application.Configuration.Service;

namespace ServicioPrueba.Infrastructure.Service
{
    public class Kraken : IKraken
    {
        private readonly string _connectionString;
        private HttpClient _client;
      
        public Kraken(string connectionString)
        {
            this._connectionString = connectionString;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_connectionString);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            
        }

        string IKraken.CreateMessageAgrupadaKraken<T>(List<T> data)
        {
            DtoKraken<T> dto = CrearDto<T>("Contabilizar", "Enviar", data);
            return SerializarDto<T>(dto);
        }

        string IKraken.CreateMessageKraken<T>(string target, string operation, List<T> data)
        {
            DtoKraken<T> dto = CrearDto<T>(target, operation, data);
            return SerializarDto<T>(dto);
        }

        async Task<string> IKraken.SendKrakenPOST(string message)
        {
            string resultadoString = null;

            var httpContent = new StringContent(message, Encoding.UTF8, "application/json");
            try
            {
                var resultado = _client.PostAsync("", httpContent).Result;

                if (resultado.Content != null)
                {
                    resultadoString = await resultado.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                var error = e;
            }

            return resultadoString;
        }
    
        private DtoKraken<T> CrearDto<T>(string target, string operation, List<T> data)
        {
            DtoKraken<T> dto = new DtoKraken<T>();
            
            dto.target = target;
            dto.operation = operation;
            dto.data = data;
            
            return dto; 
        }
    
        private string SerializarDto<T>(DtoKraken<T> dto)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            string mensaje = JsonConvert.SerializeObject(dto, Formatting.None, setting);
            return mensaje;
        }
    }
}
