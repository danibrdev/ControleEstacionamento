using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBenner.DAO.Entities
{
    public class ControleEstacionamento : BaseEntity
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm ss}")]
        [DataType(DataType.DateTime)]
        public DateTime Entrada { get; set; } = DateTime.Now;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm ss}")]
        [DataType(DataType.DateTime)]
        public DateTime? Saida { get; set; }

        public string PlacaVeiculo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public decimal Valor { get; set; }
    }
}
