using ervicioPrueba.API.Request;
using MediatR;
using Moq;
using ServicioPrueba.Application.Atributos.AddAtributos;
using ServicioPrueba.Application.Atributos.GetAtributos;
using ServicioPrueba.Domain.Atributo;
using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServicioPrueba.UnitTests.Application
{
    public class AtributoCommandHandlerTest
    {

        private readonly Mock<IAtributosRepository> _repo;
        private readonly Mock<IUnitOfWork> _unitofwork;
        private readonly Mock<IAtributosSpecification> _specification;


        public AtributoCommandHandlerTest()
        {

            _repo = new Mock<IAtributosRepository>();
            _unitofwork = new Mock<IUnitOfWork>();
            _specification = new Mock<IAtributosSpecification>();
        }

        [Fact]
        public async Task Handle_return_atributodto_create()
        {
            AtributosAddCommand fakeRequest = new AtributosAddCommand(120, "test");

            //Act
            var handler = new AtributosAddCommandHandler(_repo.Object, _unitofwork.Object, _specification.Object);
            var cltToken = new System.Threading.CancellationToken();
            AtributoDto result = await handler.Handle(fakeRequest, cltToken);
            AtributoDto resulTeorico = FakeAtributoDto();

            //Assert
            Assert.Equal(resulTeorico.idAtributo, result.idAtributo);
            Assert.Equal(resulTeorico.vchAtributo, result.vchAtributo);
        }

        [Fact]
        public async Task Handle_return_false_remove()
        {
            AtributosDeleteCommand fakeRequest = new AtributosDeleteCommand(120);

            //Act
            var handler = new AtributosDeleteCommandHandler(_repo.Object, _unitofwork.Object, _specification.Object);
            var cltToken = new System.Threading.CancellationToken();
            bool result = await handler.Handle(fakeRequest, cltToken);
            AtributoDto resulTeorico = FakeAtributoDto();

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Handle_return_true_remove()
        {
            AtributosDeleteCommand fakeRequest = new AtributosDeleteCommand(120);

            _repo.Setup(orderRepo => orderRepo.GetElement(It.IsAny<ISpecification<AtributoEntity>>()))
               .Returns(FakeAtributo());

            //Act
            var handler = new AtributosDeleteCommandHandler(_repo.Object, _unitofwork.Object, _specification.Object);
            var cltToken = new System.Threading.CancellationToken();
            bool result = await handler.Handle(fakeRequest, cltToken);
            AtributoDto resulTeorico = FakeAtributoDto();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_return_atributodto_modify()
        {
            AtributosModifyCommand fakeRequest = new AtributosModifyCommand(120,"hey");
            AtributoDto fakeAtributoDto = new AtributoDto();
            fakeAtributoDto.idAtributo = 120;
            fakeAtributoDto.vchAtributo = "test";


            _repo.Setup(orderRepo => orderRepo.GetElement(It.IsAny<ISpecification<AtributoEntity>>()))
               .Returns(FakeAtributo());
            _repo.Setup(orderRepo => orderRepo.ModifyAsync(It.IsAny<AtributoEntity>()))
              .Returns(FakeAtributo());

            //Act
            var handler = new AtributosModifyCommandHandler(_repo.Object, _unitofwork.Object, _specification.Object);
            var cltToken = new System.Threading.CancellationToken();
            AtributoDto result = await handler.Handle(fakeRequest, cltToken);
            
            //Assert
            Assert.Equal(fakeAtributoDto,result);
        }

        private AtributoEntity FakeAtributo()
        {
            return new AtributoEntity(120, "test");
        }

        private AtributoDto FakeAtributoDto()
        {
            AtributoDto fakeAtributo = new AtributoDto();
            fakeAtributo.idAtributo = 120;
            fakeAtributo.vchAtributo = "test";
            return fakeAtributo;
        }
    }
}
