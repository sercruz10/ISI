using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanControlServicos.BO
{
    public class NomeNumero
    {
        int numero;
        string nome;
        

        public NomeNumero()
        {

        }

        public NomeNumero(int numero, string nome)
        {
            
            this.numero = numero;
            this.nome = nome;
        }
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

   
    }
}