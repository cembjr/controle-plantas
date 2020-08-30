using ControlePlantas.Domain.Commands;
using System;
using Xunit;

namespace ControlePlantas.Domain.Tests
{
    [CollectionDefinition(nameof(AreaPlantioCollection))]
    public class AreaPlantioCollection : ICollectionFixture<AreaPlantioFixture>
    { }

    public class AreaPlantioFixture : IDisposable
    {
        public RegisterAreaPlantioCommand RegisterAreaPlantioCommandValid()
        {
            return new RegisterAreaPlantioCommand
            {
                Id = Guid.NewGuid(),
                Descricao = "Nova área de plantio",
                TamanhoAlqueires = 2M,
                TamanhoHectares = 4.84M
            };
        }

        public RegisterAreaPlantioCommand RegisterAreaPlantioCommandInvalid()
        {
            return new RegisterAreaPlantioCommand
            {
                Id = Guid.NewGuid(),
                Descricao = "",
                TamanhoAlqueires = 0,
                TamanhoHectares = 0
            };
        }

        public UpdateAreaPlantioCommand UpdateAreaPlantioCommandValid()
        {
            return new UpdateAreaPlantioCommand
            {
                Id = Guid.NewGuid(),
                Descricao = "Nova área de plantio",
                TamanhoAlqueires = 2M,
                TamanhoHectares = 4.84M
            };
        }

        public UpdateAreaPlantioCommand UpdateAreaPlantioCommandInvalid()
        {
            return new UpdateAreaPlantioCommand
            {
                Id = Guid.NewGuid(),
                Descricao = "",
                TamanhoAlqueires = 0,
                TamanhoHectares = 0
            };
        }

        public RemoveAreaPlantioCommand RemoveAreaPlantioCommandValid()
        {
            return new RemoveAreaPlantioCommand { Id = Guid.NewGuid() };
        }

        public RemoveAreaPlantioCommand RemoveAreaPlantioCommandInvalid()
        {
            return new RemoveAreaPlantioCommand();
        }
        public AreaPlantio ObterAreaPlantio()
        {
            return new AreaPlantio("Teste Fixture", 1, 2.42M, Guid.NewGuid());
        }

        public void Dispose()
        {
        }
    }
}
