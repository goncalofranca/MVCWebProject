using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication01.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Saudacao()
        {
            return Content("Olá, estás dentro do Produtos Controller e no Mátodo Saudação");
        }

        public IActionResult ProdutosEmJson()
        {
            string[] listProdutos = new string[] { "Limao", "Melao", "Abacaxi" };
            return Json(listProdutos);
        }

        /// <summary>
        /// Faz redirect to another action, in this case Index
        /// </summary>
        /// <returns>returns the view wich it will be redirect</returns>
        public IActionResult ToAntother()
        {
            return RedirectToAction("Index");
        }
    }
}
