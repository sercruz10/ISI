using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImoBarcelosRest.BO
{
    public class PessoaArrendatario
    {
        int id;
        string nome;
       
        public PessoaArrendatario()
        {

        }

        public PessoaArrendatario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    }
}