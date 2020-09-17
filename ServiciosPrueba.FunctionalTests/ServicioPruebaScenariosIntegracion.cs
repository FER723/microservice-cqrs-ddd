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

namespace ServicioPrueba.FunctionalTests
{
    public class ServicioPruebaScenarioIntegracion : ServicioPruebaScenarioBase
    {
        public ServicioPruebaScenarioIntegracion()
        {
        }

        [Fact]
        public async Task Response_ok_status_code()
        {
            var server = CreateServer();
            var host = await server.StartAsync();
            var response = await host.GetTestClient().GetAsync(Get.Atributos);
            HttpStatusCode satuscode = response.StatusCode;

            var responseString = await response.Content.ReadAsStringAsync();
            
            // Assert
            Assert.Equal("Hello World!", responseString);
            Assert.Equal(HttpStatusCode.OK, satuscode);
        }

        [Fact]
        public async Task Response_404_status_code()
        {
            var server = CreateServerIntegration();
            var host = await server.StartAsync();
            var response = await host.GetTestClient().GetAsync(Get.AtributosBAD);
            HttpStatusCode satuscode = response.StatusCode;

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("", responseString);
            Assert.Equal(HttpStatusCode.NotFound, satuscode);
        }

    }
}
