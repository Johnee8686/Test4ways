using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Core
{
    public interface IClienteData
    {
        IEnumerable<Cliente> GetClientes();

        Task<int> NewCliente(Cliente cliente);

        Task<int> EditCliente(Cliente cliente);

        Task<int> Delete(int Id);

        Task<Cliente> GetCliente(int Id);

    }
}
