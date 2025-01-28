using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using c_.Domains.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace c_.Structure.DB
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;
        public DbContexto(IConfiguration configuracaoAppSettings)
        {
            _configuracaoAppSettings = configuracaoAppSettings;
        }
        public DbSet<Administrador> Admins {get ; set;} = default!;
        //public DbSet<1CIA> 1CIA {get; set;} = default!; add entities
        //public DbSet<2CIA> 2CIA {get; set;} = default!; add entities
        //public DbSet<CCAP> CCAP {get; set;} = default!; add entities
        //public DbSet<BADM> BADM {get; set;} = default!; add entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador {
                    Id = 1,
                    Email = "Admin@test.com",
                    Password = "123456",
                    Perfil = "Admin",
                }
            );
        }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured){
                var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();
                if(!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(stringConexao,
                    ServerVersion.AutoDetect(stringConexao)
                    );
                }
            }
            
        }
    }
}