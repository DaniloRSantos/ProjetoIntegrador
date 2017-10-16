using Projeto_Integrador.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Integrador.Repository.Interfaces
{
    interface IRepositorioConta
    {
        PESSOA ProcuraUsuarioPorEmail(string email);
        bool VerificaDadosLogin(string email, string senha);

        bool VerificaTipoUsuario(long cpf);
    }
}
