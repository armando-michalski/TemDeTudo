using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemDeTudo.Data;
using TemDeTudo.Models;

namespace TemDeTudo.Controllers
{
    public class SellersController : Controller
    {
        private readonly TemDeTudoContext _context;
        public SellersController(TemDeTudoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var sellers = _context.Seller.Include("Department").ToList();
            return View(sellers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            // Testa se foi passado o vendedor
            if (seller == null)
            {
                // Retorna página não encontrada
                return NotFound();
            }

            // Código provisório, que vai cadastrar o primeiro Departamento que encontrar
            seller.Department = _context.Department.FirstOrDefault();
            seller.DepartmentId = seller.Department.Id;

            // Adicionar o objeto vendedor ao banco: _context.Seller.Add(seller);
            _context.Add(seller);

            // Confirma/Persiste as alterações na base de dados
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
