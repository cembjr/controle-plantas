using ControlePlantas.Data;
using ControlePlantas.Domain.Commands;
using ControlePlantas.Domain.Contracts;
using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ControlePlantas.Domain.Tests
{
    [Collection(nameof(AreaPlantioCollection))]
    public class AreaPlantioHandlerTests
    {
        private readonly AreaPlantioFixture _areaFixture;
        private readonly Mock<IAreaPlantioRepository> areaPlantioRepository;
        public AreaPlantioHandlerTests(AreaPlantioFixture areaFixture)
        {
            _areaFixture = areaFixture;
            areaPlantioRepository = new Mock<IAreaPlantioRepository>();
            SetUp();
        }

        private void SetUp()
        {
            areaPlantioRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                                 .Returns(Task.Run(() => _areaFixture.ObterAreaPlantio()));
        }

        private void Setup_ObterPorIdInvalido()
        {
            areaPlantioRepository.Setup(x => x.ObterPorId(It.IsAny<Guid>())).Returns(Task.Run(() => (AreaPlantio)null));
        }

        #region Register Command
        [Fact(DisplayName = "Registrar com Área Válida"), TestPriority(1)]
        [Trait("Categoria", "Área Plantio Register Command")]
        public async Task AreaPlantioCommandHandler_RegistrerCommand_RegistrarComSucesso()
        {
            AuthenticatedUser.IdEmpresa = Guid.NewGuid();
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);

            var result = await areaPlantioCommandHandler.Handle(_areaFixture.RegisterAreaPlantioCommandValid(), cancellationToken: new CancellationToken());
            Assert.True(result.Success);
            areaPlantioRepository.Verify(x => x.Adicionar(It.IsAny<AreaPlantio>()), Times.Once);
        }

        [Fact(DisplayName = "Registrar com Área Inválida")]
        [Trait("Categoria", "Área Plantio Register Command")]
        public async Task AreaPlantioCommandHandler_RegistrerCommand_RegistrarSemSucesso()
        {
            AuthenticatedUser.IdEmpresa = Guid.NewGuid();
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);

            var result = await areaPlantioCommandHandler.Handle(_areaFixture.RegisterAreaPlantioCommandInvalid(), cancellationToken: new CancellationToken());

            Assert.False(result.Success);
            areaPlantioRepository.Verify(x => x.Adicionar(It.IsAny<AreaPlantio>()), Times.Never);
        }

        [Fact(DisplayName = "Registrar Área Sem IdEmpresa")]
        [Trait("Categoria", "Área Plantio Register Command")]
        public async Task AreaPlantioCommandHandler_RegistrerCommand_RegistrarSemIdEmperesa()
        {
            AuthenticatedUser.IdEmpresa = Guid.Empty;
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);

            var result = await areaPlantioCommandHandler.Handle(_areaFixture.RegisterAreaPlantioCommandValid(), cancellationToken: new CancellationToken());

            Assert.False(result.Success);
            areaPlantioRepository.Verify(x => x.Adicionar(It.IsAny<AreaPlantio>()), Times.Never);
        } 
        #endregion

        #region Update Command
        [Fact(DisplayName = "Atualizar com Área Válida"), TestPriority(2)]
        [Trait("Categoria", "Área Plantio Update Command")]
        public async Task AreaPlantioCommandHandler_UpdateCommand_AtualizarComSucesso()
        {
            AuthenticatedUser.IdEmpresa = Guid.NewGuid();
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);
            
            var result = await areaPlantioCommandHandler.Handle(_areaFixture.UpdateAreaPlantioCommandValid(), cancellationToken: new CancellationToken());
            Assert.True(result.Success);
            areaPlantioRepository.Verify(x => x.Atualizar(It.IsAny<AreaPlantio>()), Times.Once);
        }

        [Fact(DisplayName = "Atualizar com Área Inválida")]
        [Trait("Categoria", "Área Plantio Update Command")]
        public async Task AreaPlantioCommandHandler_UpdateCommand_NaoAtualizarComAreaInvalida()
        {
            AuthenticatedUser.IdEmpresa = Guid.NewGuid();
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);

            var result = await areaPlantioCommandHandler.Handle(_areaFixture.UpdateAreaPlantioCommandInvalid(), cancellationToken: new CancellationToken());

            Assert.False(result.Success);
            areaPlantioRepository.Verify(x => x.Atualizar(It.IsAny<AreaPlantio>()), Times.Never);
        }

        [Fact(DisplayName = "Não Atualizar Área Sem IdEmpresa com Área Válida")]
        [Trait("Categoria", "Área Plantio Update Command")]
        public async Task AreaPlantioCommandHandler_UpdateCommand_NaoAtualizarSemIdEmperesaComAreaValida()
        {
            AuthenticatedUser.IdEmpresa = Guid.Empty;
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);

            var result = await areaPlantioCommandHandler.Handle(_areaFixture.UpdateAreaPlantioCommandValid(), cancellationToken: new CancellationToken());

            Assert.False(result.Success);
            areaPlantioRepository.Verify(x => x.Atualizar(It.IsAny<AreaPlantio>()), Times.Never);
        }

        [Fact(DisplayName = "Não Atualizar com Área Válida quando registro a ser atualizado não existe"), TestPriority(2)]
        [Trait("Categoria", "Área Plantio Update Command")]
        public async Task AreaPlantioCommandHandler_UpdateCommand_NaoAtualizarQuandoRegistroNaoExisteASerAtualizadoNaoExiste()
        {
            Setup_ObterPorIdInvalido();
            AuthenticatedUser.IdEmpresa = Guid.NewGuid();
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);

            var result = await areaPlantioCommandHandler.Handle(_areaFixture.UpdateAreaPlantioCommandValid(), cancellationToken: new CancellationToken());
            Assert.False(result.Success);
            areaPlantioRepository.Verify(x => x.Atualizar(It.IsAny<AreaPlantio>()), Times.Never);
        }
        #endregion

        #region Delete Command
        [Fact(DisplayName = "Remover Área Válida"), TestPriority(2)]
        [Trait("Categoria", "Área Plantio Remove Command")]
        public async Task AreaPlantioCommandHandler_RemoveCommand_DeletarComSucesso()
        {
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);

            var result = await areaPlantioCommandHandler.Handle(_areaFixture.RemoveAreaPlantioCommandValid(), cancellationToken: new CancellationToken());
            Assert.True(result.Success);
            areaPlantioRepository.Verify(x => x.Deletar(It.IsAny<Guid>()), Times.Once);
        }

        [Fact(DisplayName = "Não Remover Área Inválida"), TestPriority(2)]
        [Trait("Categoria", "Área Plantio Remove Command")]
        public async Task AreaPlantioCommandHandler_RemoveCommand_NaoDeletarAreaInvalida()
        {
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);

            var result = await areaPlantioCommandHandler.Handle(_areaFixture.RemoveAreaPlantioCommandInvalid(), cancellationToken: new CancellationToken());
            Assert.False(result.Success);
            areaPlantioRepository.Verify(x => x.Deletar(It.IsAny<Guid>()), Times.Never);
        }

        [Fact(DisplayName = "Não Remover Área Válida mas que não existe"), TestPriority(2)]
        [Trait("Categoria", "Área Plantio Remove Command")]
        public async Task AreaPlantioCommandHandler_RemoveCommand_NaoRemoverAreaValidaMasQueNaoExiste()
        {
            Setup_ObterPorIdInvalido();
            AuthenticatedUser.IdEmpresa = Guid.NewGuid();
            var areaPlantioCommandHandler = new AreaPlantioCommandHandler(areaPlantioRepository.Object);

            var result = await areaPlantioCommandHandler.Handle(_areaFixture.RemoveAreaPlantioCommandValid(), cancellationToken: new CancellationToken());
            Assert.False(result.Success);
            areaPlantioRepository.Verify(x => x.Deletar(It.IsAny<Guid>()), Times.Never);
        }

        #endregion
    }
}
