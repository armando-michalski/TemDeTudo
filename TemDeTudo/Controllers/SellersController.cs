using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemDeTudo.Data;
using TemDeTudo.Models;
using TemDeTudo.Models.ViewModels;

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
            // Instanciar um SellerFormViewModel
            // Essa instância vai ter duas propriedades:
            // Um vendedor e Uma lista de Departamentos
            var viewModel = new SellerFormViewModel();
            
            // Carregando os departamentos do Banco de Dados
            viewModel.Departments = _context.Department.ToList();
            
            return View(viewModel);
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
            //seller.Department = _context.Department.FirstOrDefault();
            //seller.DepartmentId = seller.Department.Id;

            // Adicionar o objeto vendedor ao banco: _context.Seller.Add(seller);
            _context.Add(seller);

            // Confirma/Persiste as alterações na base de dados
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            //verifica se foi passado um id como parametro
            if (id == null)
            {
                return NotFound();
            }

            Seller seller = _context.Seller.Include("Department").FirstOrDefault(x => x.Id == id);
            //Se nao localizado o vendedor com esse id, vai para pagina de erro
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Seller seller = _context.Seller.Include("Department").FirstOrDefault(s => s.Id == id);
            
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Seller seller = _context.Seller.FirstOrDefault(s => s.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            _context.Remove(seller);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            //Verificar se existe um objeto vendedor com o id passado por parâmetro
            var seller = _context.Seller.First(s => s.Id == id);

            if (seller == null)
            {
                return NotFound();
            }

            //Cria uma lista de departamentos
            List<Department> departments = _context.Department.ToList();

            //Cria uma instância do viewModel
            SellerFormViewModel viewModel = new SellerFormViewModel();
            viewModel.Seller = seller;
            viewModel.Departments = departments;
            
            //Retorna uma view
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Seller seller)
        {
            // Não precisa desse código abaixo completo, pode usar o resumido abaixo
            // _context.Seller.Update(seller);
            _context.Update(seller);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}
