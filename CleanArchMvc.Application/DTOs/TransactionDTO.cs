using CleanArchMvc.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CleanArchMvc.Application.DTOs
{
    public class TransactionDTO
    {
        [Key]
        public string Sku { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "double(8, 2)")]
        [Range(1, 10000, ErrorMessage = " The amount must have {1} e {2}")]
        public double Amount { get; set; }

        [Required]
        [StringLength(3, ErrorMessage = "Currency must have at least {1} characters")]
        public string Currency { get; set; }


    }
}
