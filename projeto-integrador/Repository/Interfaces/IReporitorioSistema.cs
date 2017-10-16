using Projeto_Integrador.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Integrador.Repository.Interfaces
{
    interface IReporitorioSistema
    {
        TREINAMENTO ProcurarProximoTreinamento(long cpf);
        EXERCICIO ProcurarExercicioPorCodigo(decimal codigo);
    }
}
