using ControlePlantas.Api.Filters;
using ControlePlantas.Domain;
using ControlePlantas.Domain.Contracts;
using ControlePlantas.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace ControlePlantas.Api
{
    public static class Settings
    {
        public static string Secret = "ControlePlantas@CEMBJR_15997680316";

        public static byte[] Key = Encoding.ASCII.GetBytes(Secret);


        public static void RegisterDI(this IServiceCollection services)
        {
            services.AddTransient<IAreaPlantioRepository, AreaPlantioRepository>();
            services.AddTransient<IPlantacaoRepository, PlantacaoRepository>();
            services.AddTransient<IInsumoRepository, InsumoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IFornecedorRepository, FornecedorRepository>();
            services.AddTransient<IEntradaInsumoRepository, EntradaInsumoRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<ISaidaInsumoRepository, SaidaInsumoRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            //namespace MediatR
            services.AddMediatR(AppDomain.CurrentDomain.Load("ControlePlantas.Domain"));

            services.AddScoped<ControlePlantasContext>();
        }

        public static void RegisterFilters(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new DomainExceptionFilter());
                options.Filters.Add(new ExceptionFilter());
                options.Filters.Add(new AuthenticatedUserFilter());
            });
        }
        public static void RegisterCors(this IServiceCollection services, string myAllowSpecificOrigins)
        {
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy(myAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
    }
}
