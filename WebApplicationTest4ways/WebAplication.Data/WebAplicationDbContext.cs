
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAplication.Core;

namespace WebAplication.Data
{
    public class WebAplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public WebAplicationDbContext(DbContextOptions<WebAplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<TipoEntidad> TipoEntidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region PAIS
            List<Pais> _paises = new List<Pais>();

            _paises.Add(new Pais { IdPais = 1, Nombre = "PR" }) ;
            _paises.Add(new Pais { IdPais = 2, Nombre = "EU" });
            _paises.Add(new Pais { IdPais = 3, Nombre = "Otro" });

            modelBuilder.Entity<Pais>().HasData(_paises);
            #endregion


            #region TIPO ENTIDAD
            List<TipoEntidad> _TipoEntidades = new List<TipoEntidad>();

            _TipoEntidades.Add(new TipoEntidad { IdTipoEntidad = 1, Nombre = "Individuo" });
            _TipoEntidades.Add(new TipoEntidad { IdTipoEntidad = 2, Nombre = "Compañía" });

            modelBuilder.Entity<TipoEntidad>().HasData(_TipoEntidades);
            #endregion


            #region CLIENTES
            List<Cliente> _Clientes = new List<Cliente>();

            var IdCliente = 1;

            //..----------------------COMPANIAS
            var fakeClientes = new Faker<Cliente>("en_US")
                .CustomInstantiator(f => new Cliente { IdCliente = IdCliente++ })
                .RuleFor(bp => bp.Nombre, f => $@"{f.Company.CompanyName()}")
                .RuleFor(bp => bp.IdPais, f => f.Random.Int(1, 3))
                .RuleFor(bp => bp.IdTipoEntidad,  2 );

            _Clientes.AddRange(fakeClientes.Generate(2));

            modelBuilder.Entity<Cliente>().HasData(_Clientes);


            //..----------------------INDIVIDUOS
            _Clientes = new List<Cliente>();
            fakeClientes = new Faker<Cliente>("en_US")
                .CustomInstantiator(f => new Cliente { IdCliente = IdCliente++ })
                .RuleFor(bp => bp.Nombre, f => $@"{f.Name.FullName()}")
                .RuleFor(bp => bp.IdPais, f => f.Random.Int(1, 3))
                .RuleFor(bp => bp.IdTipoEntidad, 1);

            _Clientes.AddRange(fakeClientes.Generate(2));

            modelBuilder.Entity<Cliente>().HasData(_Clientes);

            #endregion


        }
    }
}
