using ervicioPrueba.API.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicioPrueba.API.Atributos;
using ServicioPrueba.Application.Atributos.AddAtributos;
using ServicioPrueba.Application.Atributos.GetAtributos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ServicioPrueba.UnitTests.Application
{
    public class AtributoAPITest
    {
        private readonly Mock<IMediator> _mediatorMock;

        public AtributoAPITest()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task Remove_requestId_success()
        {
            //Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<AtributosDeleteCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult(true));

            //Act
            var atributosController = new AtributosController(_mediatorMock.Object);
            var actionResult = (OkObjectResult)await atributosController.DeleteAtributo(120);
            
            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);

        }

        [Fact]
        public async Task Modify_request_success()
        {
            AtributoDto fakeAtributo = new AtributoDto();
            fakeAtributo.idAtributo = 120;
            fakeAtributo.vchAtributo = "hey";

            AtributosRequest fakeRequest = new AtributosRequest();
            fakeRequest.AtributoId = 120;
            fakeRequest.Descripcion = "hey";

            //Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<AtributosModifyCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult(fakeAtributo));

            //Act
            var atributosController = new AtributosController(_mediatorMock.Object);
            var actionResult = (OkObjectResult)await atributosController.ModificarAtributo(fakeRequest);

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal(actionResult.Value, fakeAtributo);
        }

        [Fact]
        public async Task Add_request_success()
        {
            AtributoDto fakeAtributo = new AtributoDto();
            fakeAtributo.idAtributo = 120;
            fakeAtributo.vchAtributo = "hey";

            AtributosRequest fakeRequest = new AtributosRequest();
            fakeRequest.AtributoId = 120;
            fakeRequest.Descripcion = "hey";

            //Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<AtributosAddCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult(fakeAtributo));

            //Act

            var atributosController = new AtributosController(_mediatorMock.Object);
            var actionResult = (CreatedResult)await atributosController.RegisterAtributo(fakeRequest);

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.Created);
            Assert.Equal(actionResult.Value, fakeAtributo);
        }

        [Fact]
        public async Task Get_atributosAll_success()
        {
            List<AtributoDto> fakeDynamicResult = new List<AtributoDto>();

            //Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAtributosQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(fakeDynamicResult));

            //Act
            var atributosController = new AtributosController(_mediatorMock.Object);
            var actionResult = (OkObjectResult)await atributosController.GetAtributos();

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_atributosById_success()
        {
            List<AtributoDto> fakeDynamicResult = new List<AtributoDto>();

            //Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAtributosQuery>(), default(CancellationToken)))
                .Returns(Task.FromResult(fakeDynamicResult));

            //Act
            var atributosController = new AtributosController(_mediatorMock.Object);
            var actionResult = (OkObjectResult)await atributosController.GetAtributoID(120);

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

    }
}

