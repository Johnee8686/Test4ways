using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Core
{
    public interface IPaisData
    {
        IEnumerable<Pais> GetPaises();

        Task<int> NewPais(Pais pais);

        Task<int> EditPais(Pais pais);

        Task<int> Delete(int Id);

        Task<Pais> GetPais(int Id);

    }
}
