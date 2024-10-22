using System.ComponentModel.DataAnnotations;

namespace TemDeTudo.Models
{
    public class Department
    {
        public int Id { get; set; }

		[Display(Name = "Nome do Departamento")]
		public string Name { get; set; }

        public List<Seller> Sellers { get; set;} = new List<Seller>();
    }
}
