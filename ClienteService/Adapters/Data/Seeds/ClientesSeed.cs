using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeds
{
    public static class ClientesSeed
    {
        public static void Clientes(ModelBuilder builder)
        {
            
                builder.Entity<Cliente>().HasData(
                    new Cliente() {
                        Cpf = "90406710015",
                        Nome = "Pumba",
                        Celular = "1166996699",
                        UF = "SP",
                    },
                    new Cliente()
                    {
                        Cpf = "67482339094",
                        Nome = "Rafiki",
                        Celular = "1165656565",
                        UF = "SP",
                    },
                    new Cliente()
                    {
                        Cpf = "89387788008",
                        Nome = "Simba",
                        Celular = "4155668899",
                        UF = "PR",
                    },
                    new Cliente()
                    {
                        Cpf = "99927465050",
                        Nome = "Timão",
                        Celular = "1158585858",
                        UF = "SP",
                    },
                    new Cliente()
                    {
                        Cpf = "27585548010",
                        Nome = "Zazu",
                        Celular = "5126262626",
                        UF = "RS",
                    },
                    new Cliente()
                    {
                        Cpf = "71676470042",
                        Nome = "Nala",
                        Celular = "1198989898",
                        UF = "SP",
                    },
                    new Cliente()
                    {
                        Cpf = "83799824014",
                        Nome = "Mufasa",
                        Celular = "1165686568",
                        UF = "SP",
                    },
                    new Cliente()
                    {
                        Cpf = "30439355001",
                        Nome = "Scar",
                        Celular = "1126232623",
                        UF = "SP"
                    },
                    new Cliente()
                    {
                        Cpf = "61450660088",
                        Nome = "Ed",
                        Celular = "4166666666",
                        UF = "PR"
                    }
                );

                
                builder.Entity<Financiamento>().HasData(
                    new Financiamento
                    {
                        Id = 1,
                        DataUltimoVencimento = DateTime.UtcNow.AddDays(30),
                        TipoFinanciamento = Domain.Enums.TipoFinanciamento.CreditoDireto,
                        ValorTotal = 5000,
                        Cpf = "90406710015"
                    },new Financiamento
                    {
                        Id = 2,
                        DataUltimoVencimento = DateTime.UtcNow.AddDays(30),
                        TipoFinanciamento = Domain.Enums.TipoFinanciamento.CreditoDireto,
                        ValorTotal = 5000,
                        Cpf = "67482339094"
                    },new Financiamento
                    {
                        Id = 3,
                        DataUltimoVencimento = DateTime.UtcNow.AddDays(30),
                        TipoFinanciamento = Domain.Enums.TipoFinanciamento.CreditoDireto,
                        ValorTotal = 5000,
                        Cpf = "89387788008"
                    },
                    new Financiamento()
                    {
                        Id = 4,
                        DataUltimoVencimento = DateTime.UtcNow.AddDays(120),
                        TipoFinanciamento = Domain.Enums.TipoFinanciamento.CreditoPessoaFisica,
                        ValorTotal = 5000,
                        Cpf = "99927465050"
                    },
                    new Financiamento()
                    {
                        Id = 5,
                        DataUltimoVencimento = DateTime.UtcNow.AddDays(120),
                        TipoFinanciamento = Domain.Enums.TipoFinanciamento.CreditoPessoaFisica,
                        ValorTotal = 5000,
                        Cpf= "27585548010"
                    },
                    new Financiamento()
                    {
                        Id = 6,
                        DataUltimoVencimento = DateTime.UtcNow.AddDays(120),
                        TipoFinanciamento = Domain.Enums.TipoFinanciamento.CreditoPessoaFisica,
                        ValorTotal = 5000,
                        Cpf = "71676470042"
                    },
                    new Financiamento()
                    {
                        Id = 7,
                        DataUltimoVencimento = DateTime.UtcNow.AddDays(60),
                        TipoFinanciamento = Domain.Enums.TipoFinanciamento.CreditoPessoaFisica,
                        ValorTotal = 5000,
                        Cpf = "83799824014"
                    },new Financiamento()
                    {
                        Id = 8,
                        DataUltimoVencimento = DateTime.UtcNow.AddDays(60),
                        TipoFinanciamento = Domain.Enums.TipoFinanciamento.CreditoPessoaFisica,
                        ValorTotal = 5000,
                        Cpf = "30439355001"
                    }
                );
                   

                    
                builder.Entity<Parcela>().HasData(
                    new Parcela()
                    {
                        IdFinanciamento = 1,
                        Id = 1,
                        NumeroParcela = 1,
                        DataVencimento = DateTime.UtcNow.AddDays(-90),
                        DataPagamento = DateTime.UtcNow.AddDays(-90),
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 1,
                        Id = 2,
                        NumeroParcela = 2,
                        DataVencimento = DateTime.UtcNow.AddDays(-60),
                        DataPagamento = DateTime.UtcNow.AddDays(-60),
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 1,
                        Id = 3,
                        NumeroParcela = 3,
                        DataVencimento = DateTime.UtcNow.AddDays(-30),
                        DataPagamento = DateTime.UtcNow.AddDays(-30),
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 1,
                        Id = 4,
                        NumeroParcela = 4,
                        DataVencimento = DateTime.UtcNow,
                        DataPagamento = DateTime.UtcNow,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 1,
                        Id = 5,
                        NumeroParcela = 5,
                        DataVencimento = DateTime.UtcNow.AddDays(30),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 2,
                        Id = 6,
                        NumeroParcela = 1,
                        DataVencimento = DateTime.UtcNow.AddDays(-60),
                        DataPagamento = DateTime.UtcNow.AddDays(-60),
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 2,
                        Id = 7,
                        NumeroParcela = 2,
                        DataVencimento = DateTime.UtcNow.AddDays(-30),
                        DataPagamento = DateTime.UtcNow.AddDays(-30),
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 2,
                        Id = 8,
                        NumeroParcela = 3,
                        DataVencimento = DateTime.UtcNow.AddDays(-1),
                        DataPagamento = DateTime.UtcNow.AddDays(-1),
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 2,
                        Id = 9,
                        NumeroParcela = 4,
                        DataVencimento = DateTime.UtcNow.AddDays(30),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 2,
                        Id = 10,
                        NumeroParcela = 5,
                        DataVencimento = DateTime.UtcNow.AddDays(60),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 3,
                        Id = 11,
                        NumeroParcela = 1,
                        DataVencimento = DateTime.UtcNow,
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 3,
                        Id = 12,
                        NumeroParcela = 2,
                        DataVencimento = DateTime.UtcNow.AddDays(30),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 3,
                        Id = 13,
                        NumeroParcela = 3,
                        DataVencimento = DateTime.UtcNow.AddDays(60),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 3,
                        Id = 14,
                        NumeroParcela = 4,
                        DataVencimento = DateTime.UtcNow.AddDays(90),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 3,
                        Id = 15,
                        NumeroParcela = 5,
                        DataVencimento = DateTime.UtcNow.AddDays(120),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                     new Parcela()
                     {
                         IdFinanciamento = 4,
                         Id = 16,
                         NumeroParcela = 1,
                         DataVencimento = DateTime.UtcNow,
                         DataPagamento = null,
                         ValorParcela = 1000
                     },
                    new Parcela()
                    {
                        IdFinanciamento = 4,
                        Id = 17,
                        NumeroParcela = 2,
                        DataVencimento = DateTime.UtcNow.AddDays(30),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 4,
                        Id = 18,
                        NumeroParcela = 3,
                        DataVencimento = DateTime.UtcNow.AddDays(60),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 4,
                        Id = 19,
                        NumeroParcela = 4,
                        DataVencimento = DateTime.UtcNow.AddDays(90),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 4,
                        Id = 20,
                        NumeroParcela = 5,
                        DataVencimento = DateTime.UtcNow.AddDays(120),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 5,
                        Id = 21,
                        NumeroParcela = 1,
                        DataVencimento = DateTime.UtcNow,
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 5,
                        Id = 22,
                        NumeroParcela = 2,
                        DataVencimento = DateTime.UtcNow.AddDays(30),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 5,
                        Id = 23,
                        NumeroParcela = 3,
                        DataVencimento = DateTime.UtcNow.AddDays(60),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 5,
                        Id = 24,
                        NumeroParcela = 4,
                        DataVencimento = DateTime.UtcNow.AddDays(90),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 5,
                        Id = 25,
                        NumeroParcela = 5,
                        DataVencimento = DateTime.UtcNow.AddDays(120),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 6,
                        Id = 26,
                        NumeroParcela = 1,
                        DataVencimento = DateTime.UtcNow.AddDays(-60),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 6,
                        Id = 27,
                        NumeroParcela = 2,
                        DataVencimento = DateTime.UtcNow.AddDays(-30),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 6,
                        Id = 28,
                        NumeroParcela = 3,
                        DataVencimento = DateTime.UtcNow.AddDays(-1),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 6,
                        Id = 29,
                        NumeroParcela = 4,
                        DataVencimento = DateTime.UtcNow.AddDays(30),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 6,
                        Id = 30,
                        NumeroParcela = 5,
                        DataVencimento = DateTime.UtcNow.AddDays(60),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 7,
                        Id = 31,
                        NumeroParcela = 1,
                        DataVencimento = DateTime.UtcNow.AddDays(-60),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 7,
                        Id = 32,
                        NumeroParcela = 2,
                        DataVencimento = DateTime.UtcNow.AddDays(-30),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 7,
                        Id = 33,
                        NumeroParcela = 3,
                        DataVencimento = DateTime.UtcNow.AddDays(-1),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 7,
                        Id = 34,
                        NumeroParcela = 4,
                        DataVencimento = DateTime.UtcNow.AddDays(30),
                        DataPagamento = null,
                        ValorParcela = 1000
                    },
                    new Parcela()
                    {
                        IdFinanciamento = 7,
                        Id = 35,
                        NumeroParcela = 5,
                        DataVencimento = DateTime.UtcNow.AddDays(60),
                        DataPagamento = null,
                        ValorParcela = 1000
                    }
                );
        }
    }
}
