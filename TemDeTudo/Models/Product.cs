using System.ComponentModel.DataAnnotations;

namespace TemDeTudo.Models
{
    public class Product
    {
        public int Id { get; set; }

		[Display(Name = "Nome do Produto")]
		public string Name { get; set; }

		[Display(Name = "Descrição do Produto")]
		public string Description { get; set; }
    }
}
