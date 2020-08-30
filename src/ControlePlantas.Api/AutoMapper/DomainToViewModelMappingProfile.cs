using AutoMapper;
using ControlePlantas.Domain;
using ControlePlantas.Domain.Core.Helper;

namespace ControlePlantas.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            Mapper();
        }

        private void Mapper()
        {
            CreateMap<Insumo, InsumoDTO>()
                .ForMember(x => x.DescricaoTipoInsumo, x => x.MapFrom(m => m.TipoInsumo.GetDescription()));

            CreateMap<AreaPlantio, AreaPlantioDTO>();

            CreateMap<Plantacao, PlantacaoDTO>()
                .ForMember(x => x.DataInicial, x => x.MapFrom(m => m.Periodo.DataInicial))
                .ForMember(x => x.DescricaoAreaPlantio, x => x.MapFrom(m => m.AreaPlantio.Descricao));

            CreateMap<Usuario, UsuarioDTO>();

            CreateMap<Fornecedor, FornecedorDTO>()
                .ForMember(x => x.Endereco, x => x.MapFrom(m =>
                                    new EnderecoDTO
                                    {
                                        CEP = m.Endereco.CEP,
                                        Cidade = m.Endereco.Cidade,
                                        Complemento = m.Endereco.Complemento,
                                        Logradouro = m.Endereco.Logradouro,
                                        Numero = m.Endereco.Numero
                                    }));

            CreateMap<EntradaInsumo, EntradaInsumoDTO>()
                .ForMember(x => x.NomeInsumo, x=> x.MapFrom(m => m.Insumo.Nome));

            CreateMap<SaidaInsumo, SaidaInsumoDTO>()
                .ForMember(x => x.NomeInsumo, x => x.MapFrom(m => m.EntradaInsumo.Insumo.Nome));
        }
    }
}
