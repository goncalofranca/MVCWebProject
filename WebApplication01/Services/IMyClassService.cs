using System.Collections.Generic;

namespace WebApplication01.Services
{
    public interface IMyClassService
    {
        IList<string> Distritos { get; set; }

        void AdicionarDistrito(string aDistrito);
    }
}