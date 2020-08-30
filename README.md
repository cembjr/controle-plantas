Projeto ainda não completo de uma Api para controle de plantações agrícolas com AspNet Core. 
Segue algumas das implementações e suas camadas:
- Api
-- Filtros para tratamentos de exceções dentre outros
-- Autenticação com JWT
-- MediatR 
-- AutoMapper

- Domínio
-- Utilização de Commands e Handlers 
-- Validações com FluentValidation

- Camada de dados 
-- Utilizado Entity Framework Core
-- Repository Pattern
-- Fluent Api para mapeamento de entidades x banco de dados

- Testes de Unidade do domínio
