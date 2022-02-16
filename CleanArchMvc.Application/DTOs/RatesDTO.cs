using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class RatesDTO
    {
      
        [Required(ErrorMessage = "The From is Required")]
        [StringLength(3, ErrorMessage = "Currency must have at least {1} characters")]
        public string From { get; set; }

        [Required(ErrorMessage = "The To is Required")]
        [StringLength(3, ErrorMessage = "Currency must have at least {1} characters")]
        public string To { get; set; }

        [Required(ErrorMessage = "The Rate is Required")]
        public double Rate { get; set; }
        public object Id { get; set; }
    }
}
