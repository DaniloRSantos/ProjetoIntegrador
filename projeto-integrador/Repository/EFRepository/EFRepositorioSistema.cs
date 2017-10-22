using Projeto_Integrador.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_Integrador.Models.Database;

namespace Projeto_Integrador.Repository.EFRepository
{
    public class EFRepositorioSistema : IReporitorioSistema
    {
        private readonly Entities context = new Entities();

        public IEnumerable<FICHA> ContagemFicha()
        {
            return context.FICHA;
        }

        public EXERCICIO ProcurarExercicioPorCodigo(decimal codigo)
        {
            return context.EXERCICIO.Where(x => x.COD_EXERCICIO == codigo).SingleOrDefault();
        }

        public TREINAMENTO ProcurarProximoTreinamento(long cpf)
        {
            return context.TREINAMENTO.Where(x => x.CPF_ALUNO == cpf).First();
        }

        public FICHA VerificarExistenciaFicha(long? CPF)
        {
            var ficha = context.FICHA.Where(x => x.CPF_ALUNO == CPF).FirstOrDefault();
            if(ficha == null)
            {
                return null;
            }
            else
            {
                return ficha;
            }
        }
    }
}