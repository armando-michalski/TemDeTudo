using System.ComponentModel.DataAnnotations;

namespace TemDeTudo.Models
{
    public class Seller
    {
        public int Id { get; set; }
        
        [Display(Name="Nome do Vendedor")]
        [StringLength(30, ErrorMessage="Nome excedeu o máximo de 30 caractéres")]
        public string Name { get; set; }
        
        [EmailAddress(ErrorMessage="E-mail inválido")]
        public string Email { get; set; }
        
        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Range(1400, 50000, ErrorMessage="Valor fora dos limites")]
        [DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:F2}")]
		public decimal Salary { get; set; }
        
        public int DepartmentId { get; set; }
        
        public Department Department { get; set; }
        
        public List<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
    }
}
