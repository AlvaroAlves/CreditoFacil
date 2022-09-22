﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Financiamento
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public TipoFinanciamento TipoFinanciamento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataUltimoVencimento { get; set; }
    }
}
