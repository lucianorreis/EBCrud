using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c_.Domains.Entities;
using c_.Domains.DTO;

namespace c_.Domains.Interfaces
{
    public interface IAdminServices // fixador de regras da classe admin
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}