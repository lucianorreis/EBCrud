using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c_.Domains.DTO;
using c_.Domains.Entities;
using c_.Domains.Interfaces;
using c_.Structure.DB;

namespace c_.Domains.Services
{
    public class AdministradorServices(DbContexto contexto) : IAdminServices
    {
        private readonly DbContexto _contexto = contexto;

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Admins.Where(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password).FirstOrDefault();
            return adm;
        }

        public Administrador? Logon(LoginDTO loginDTO)
        {
            var adm = _contexto.Admins.Where(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password).FirstOrDefault();
            return adm;
        }
    }
}