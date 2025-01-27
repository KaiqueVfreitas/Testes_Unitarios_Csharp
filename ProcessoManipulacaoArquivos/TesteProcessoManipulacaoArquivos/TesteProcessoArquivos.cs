using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessoManipulacaoArquivos;
using System;
using System.Configuration;
using System.IO;

namespace TesteProcessoManipulacaoArquivos
{
    [TestClass]
    public class TesteProcessoArquivos
    {
        private const string arquivo = @"C:\Temp\teste.txt";
        private string _BomNomeArquivo;

        public TestContext TestContext { get; set; }
        

        [TestInitialize]
        public void Setup()
        {
            ConfigurarBomNomeArquivo();
        }

        private void ConfigurarBomNomeArquivo()
        {
            _BomNomeArquivo = ConfigurationManager.AppSettings["BomNomeArquivo"];
            if (string.IsNullOrEmpty(_BomNomeArquivo))
            {
                throw new InvalidOperationException("A configuração 'BomNomeArquivo' não foi definida.");
            }

            if (_BomNomeArquivo.Contains("[AppPath]"))
            {
                _BomNomeArquivo = _BomNomeArquivo.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        public void NomeArquivoExiste()
        {
            ProcessoArquivos procManArquivo = new ProcessoArquivos();
            File.AppendAllText(_BomNomeArquivo, "Texto");

            bool resposta = procManArquivo.VerificacaoExistenciaArquivo(_BomNomeArquivo);

            Assert.IsTrue(resposta);
        }

        [TestMethod]
        public void NomeArquivoNãoExiste()
        {
            ProcessoArquivos procManArquivo = new ProcessoArquivos();

            bool resposta = procManArquivo.VerificacaoExistenciaArquivo(arquivo);

            Assert.IsFalse(resposta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NomeArquivoVazio()
        {
            ProcessoArquivos procManArquivo = new ProcessoArquivos();
            procManArquivo.VerificacaoExistenciaArquivo("");
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_BomNomeArquivo))
            {
                File.Delete(_BomNomeArquivo);
            }
        }
    }
}
