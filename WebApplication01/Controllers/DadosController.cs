using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication01.Controllers
{
    public class DadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Atenção ao nome dos parametros porque o que for colocado será o que estará na query string
        /// em vez de nome etiver XYZ na query string no browser estará "..../dados/registaCliente/id=1&XYZ=Zé"
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nome"></param>
        /// <param name="Morada"></param>
        /// <param name="Idade"></param>
        /// <returns></returns>
        public IActionResult RegistaCliente(int Id, string Nome, string Morada, int Idade)
        {
            /// para testar
            /// http://....../Dados/ResgistaCliente?Id=1&Nome=Ze&Morada=Porto&Idade=20
            /// http://....../Dados/ResgistaCliente?1&Nome=Ze&Morada=Porto&Idade=20

            return View();
        }
        public IActionResult MostraRegistoCliente(int Id, string Nome, string Morada, int Idade)
        {
            /// para testar
            /// http://....../Dados/ResgistaCliente?Id=1&Nome=Ze&Morada=Porto&Idade=20
            /// http://....../Dados/ResgistaCliente?1&Nome=Ze&Morada=Porto&Idade=20

            ViewData.Add("id", Id);
            ViewData.Add("nome", Nome);
            ViewData.Add("morada", Morada);
            ViewData.Add("idade", Idade);

            return View();
        }
    }
}
