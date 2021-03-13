using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication01.Services
{
    public class MyClassService : IMyClassService
    {
        public IList<string> Distritos { get; set; }
        public MyClassService()
        {
            Distritos = new List<string> {
                "Aveiro",
                "Braga",
                "Beja",
                "Coimbra",
                "Faro",
                "Lisboa",
                "Portalegre"
            };
        }

        public void AdicionarDistrito(string aDistrito) => Distritos.Add(aDistrito);
    }
}
