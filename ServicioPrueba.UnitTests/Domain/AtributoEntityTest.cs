using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using System;
using ServicioPrueba.Application.Atributos.GetAtributos;
using System.Collections.Generic;
using ServicioPrueba.Domain.Atributo;

namespace ServicioPrueba.UnitTests.Domain
{
    public class AtributoEntityTest
    { 

        [Fact]
        public void Create_atributoEntity_item_success()
        {
            //Arrange    
            var id = 100;
            var descripcion = "FakeAtributo";
            
            //Act 
            var fakeOrderItem = new AtributoEntity(id, descripcion);

            //Assert
            Assert.NotNull(fakeOrderItem);
        }

        [Fact]
        public void Invalid_number_id()
        {
            //Arrange            
            var id = 0;
            var descripcion = "FakeAtributo";

            //Act - Assert
            Assert.Throws<ArgumentNullException>(() => new AtributoEntity(id, descripcion));
        }

        [Fact]
        public void Invalid_descripcion()
        {
            //Arrange    
            //Arrange            
            var id = 12;
            var descripcion = " ";

            //Act - Assert
            Assert.Throws<ArgumentNullException>(() => new AtributoEntity(id, descripcion));
        }

    }
}
