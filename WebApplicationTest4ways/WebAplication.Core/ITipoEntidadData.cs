using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Core
{
    public interface ITipoEntidadData
    {
        IEnumerable<TipoEntidad> GetTipoEntidades();

        Task<int> NewTipoEntidad(TipoEntidad tipoEntidad);

        Task<int> EditTipoEntidad(TipoEntidad tipoEntidad);

        Task<int> Delete(int Id);

        Task<TipoEntidad> GetTipoEntidad(int Id);

    }
}
