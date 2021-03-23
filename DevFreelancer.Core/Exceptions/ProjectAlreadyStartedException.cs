using System;

namespace DevFreelancer.Core.Exceptions
{
    public class ProjectAlreadyStartedException : Exception
    {
        // GERAR UMA EXCEÇÃO QUANDO UM PROJETO FOR INICIALIZADO E JÁ ESTIVER OUTRO CADASTRO E ATIVO
        public ProjectAlreadyStartedException() : base("Project is already started")
        {
        }
    }
}
