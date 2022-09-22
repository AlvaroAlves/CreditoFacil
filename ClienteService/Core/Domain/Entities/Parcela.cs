﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Parcela
    {
        public int Id { get; set; }
        public int IdFinanciamento { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
