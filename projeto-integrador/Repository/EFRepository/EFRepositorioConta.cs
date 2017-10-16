using Projeto_Integrador.Models.Database;
using Projeto_Integrador.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.Repository.EFRepository
{
    public class EFRepositorioConta : IRepositorioConta
    {
        private readonly Entities context = new Entities();

        public PESSOA ProcuraUsuarioPorEmail(string email)
        {
            return context.PESSOA.Where(x => x.EMA_PESSOA == email).SingleOrDefault();
        }

        public bool VerificaDadosLogin(string email, string senha)
        {
            PESSOA usuario = context.PESSOA.Where(x => x.EMA_PESSOA == email).SingleOrDefault();
            if (usuario != null)
            {
                if (usuario.SEN_PESSOA == senha)
                    return true;
            }
            return false;
        }

        public bool VerificaTipoUsuario(long cpf)
        {
           FUNCIONARIO dados = context.FUNCIONARIO.Where(x => x.CPF_PESSOA == cpf).SingleOrDefault();
            if (dados != null)
            {
                return true;
            }
            return false;

        }
    }
}