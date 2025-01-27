using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoManipulacaoArquivos
{
    public class ProcessoArquivos
    {
        public bool VerificacaoExistenciaArquivo(string nomeArquivo)
        {
            if (string.IsNullOrEmpty(nomeArquivo))
            {
                throw new ArgumentNullException("Arquivo está vázio");
            }
            return File.Exists(nomeArquivo);
            
        }
    }
}
