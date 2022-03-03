using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Core;
using System.Linq;

namespace WebAplication.Data
{
    public class ClienteDataDbContext : IClienteData
    {
        private readonly WebAplicationDbContext db;

        public ClienteDataDbContext(WebAplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Delete(int Id)
        {
            var ele = db.Clientes.Find(Id);
            if (ele != null)
            {
                db.Clientes.Remove(ele);
            }
            return await db.SaveChangesAsync();
        }

        public async Task<int> EditCliente(Cliente cliente)
        {
            db.Update(cliente);
            return await db.SaveChangesAsync();
        }

        public async Task<Cliente> GetCliente(int Id)
        {
            return await(db.Clientes.FindAsync(Id));
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return (db.Clientes);
        }

        public async Task<int> NewCliente(Cliente cliente)
        {
            db.Clientes.Add(cliente);

            return await db.SaveChangesAsync();
        }
    }
}
