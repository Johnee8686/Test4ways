using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Core;
using System.Linq;

namespace WebAplication.Data
{
    public class TipoEntidadDataDbContext : ITipoEntidadData
    {
        private readonly WebAplicationDbContext db;

        public TipoEntidadDataDbContext(WebAplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> EditTipoEntidad(TipoEntidad tipoEntidad)
        {
            db.Update(tipoEntidad);
            return await db.SaveChangesAsync();
        }
        public IEnumerable<TipoEntidad> GetTipoEntidades()
        {
            return (db.TipoEntidades);
        }
        public async Task<TipoEntidad> GetTipoEntidad(int Id)
        {
            return await (db.TipoEntidades.FindAsync(Id));
        }
        public async Task<int> NewTipoEntidad(TipoEntidad tipoEntidad)
        {
            db.TipoEntidades.Add(tipoEntidad);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var ele = db.TipoEntidades.Find(Id);
            if (ele != null)
            {
                db.TipoEntidades.Remove(ele);
            }
            return await db.SaveChangesAsync();
        }
    }
}
