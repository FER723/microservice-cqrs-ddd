using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using System;
using ServicioPrueba.Application.Atributos.GetAtributos;
using System.Collections.Generic;

namespace ServicioPrueba.FunctionalTests
{
    public class ServicioPruebaScenarioFuncional : ServicioPruebaScenarioBase
    {
       
        [Theory]
        [InlineData(6)]
        public async Task Get_get_id_stored_atributos_and_response_ok_status_code(int id)
        {
            try
            {
                var server = CreateServerFunctional();
                var host = await server.StartAsync();
                var response = await host.GetTestClient().GetAsync(Get.AtributosBy(id));
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();

                string atributoTeorico = generarAtributo();

                // Assert
                Assert.Equal(atributoTeorico, responseString);

            }catch(Exception e)
            {
                throw e;
            }
        }

        [Fact]
        public async Task Get_get_all_stored_atributos_and_response_ok_status_code()
        {
            try
            {
                var server = CreateServerFunctional();
                var host = await server.StartAsync();
                var response = await host.GetTestClient().GetAsync(Get.Atributos);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                List<AtributoDto> listaAtributos = JsonConvert.DeserializeObject<List<AtributoDto>>(responseString);
                Assert.True(listaAtributos.Count > 0);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string generarAtributo()
        {
            List<AtributoDto> atributos = new List<AtributoDto>();
            
            AtributoDto atributo = new AtributoDto();
            atributo.idAtributo = 6;
            atributo.vchAtributo = "Media terminal individual recaudado";
            atributos.Add(atributo);

            return JsonConvert.SerializeObject(atributos);
        }
    }
}
