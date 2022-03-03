using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Core;
using System.Linq;

namespace WebAplication.Data
{
    public class PaisDataDbContext : IPaisData
    {
        private readonly WebAplicationDbContext db;

        public PaisDataDbContext(WebAplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Delete(int Id)
        {
            var ele = db.Paises.Find(Id);
            if (ele != null)
            {
                db.Paises.Remove(ele);
            }
            return await db.SaveChangesAsync();
        }

        public async Task<int> EditPais(Pais pais)
        {
            db.Update(pais);

            return await db.SaveChangesAsync();
        }

        public async Task<Pais> GetPais(int Id)
        {
            return await (db.Paises.FindAsync(Id));
        }

        public IEnumerable<Pais> GetPaises()
        {
            return (db.Paises);
        }

        public async Task<int> NewPais(Pais pais)
        {
            db.Paises.Add(pais);

            return await db.SaveChangesAsync();
        }
    }
}
