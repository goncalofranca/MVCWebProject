using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WebApplication01.Services;

namespace WebApplication01.Controllers
{
    public class DistritosController : Controller
    {
        private readonly IMyClassService _myService;
        public DistritosController(IMyClassService aIMyService)
        {
            _myService = aIMyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string MostrarDistritos()
        {
            StringBuilder _ctxDistList = new();

            foreach(var itemDist in _myService.Distritos)
            {
                // adiciona um virgula, como separador, so depois do primeiro registo ser inserido
                if(_ctxDistList.Length > 0)
                {
                    _ctxDistList.Append(", ");
                }
                _ = _ctxDistList.Append(itemDist);
            }

            return _ctxDistList.ToString();
        }
    }
}
