using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImoBarcelosRest.BO
{
    public class PHobbie
    {      
        string nome;
        string gosto;
        string morada;
        string email;

        public PHobbie()
        {

        }

        public PHobbie(string nome, string gosto, string morada,string email)
        {
            this.nome = nome;
            this.gosto = gosto;
            this.morada = morada;
            this.email = email;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string  Gosto
        {
            get { return gosto; }
            set { gosto = value; }
        }
        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }




    }
}