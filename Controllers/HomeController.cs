using EntityFramework.DB;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IList<Funcionario> funcionario { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            

                return View();
        }

        [HttpPost]
        public IActionResult RecuperarDados()
        {
            var teste = 1;

            using (var contexto = new ProjetoDb())
            {
                funcionario = contexto.Funcionarios.ToList();
            }

                return View("Index", funcionario);
        }

        [HttpPost]
        public IActionResult EnviarDados(string Nome, int Idade)
        {
            Funcionario funcionarioSet = new Funcionario()
            {
                Nome = Nome,
                Idade = Idade
            };

            using (var contexto = new ProjetoDb())
            {
                contexto.Funcionarios.Add(funcionarioSet);
                contexto.SaveChanges();
            }

                return RecuperarDados();
        }

        public IActionResult AdicionarDados(string Nome, int Idade)
        {
            Funcionario funcionarioInsert = new Funcionario() {
                Nome = Nome,
                Idade = Idade
            };

            using (var contexto = new ProjetoDb())
            {
                contexto.Funcionarios.Add(funcionarioInsert);
                contexto.SaveChanges();
            }

                return View("Index");
        }

        [HttpPost]
        public IActionResult Deletar(int IdFuncionario)
        {
            using (var contexto = new ProjetoDb())
            {
                Funcionario funcionarioDelete = contexto.Funcionarios.Where(x => x.Id == IdFuncionario).FirstOrDefault();

                contexto.Funcionarios.Remove(funcionarioDelete);
                contexto.SaveChanges();

            }
                return RecuperarDados();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}