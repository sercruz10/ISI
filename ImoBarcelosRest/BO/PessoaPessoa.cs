using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanControlServicos.BO
{
    public class PessoaPessoa
    {        
        
        int idPessoa;
        string nome;
        string dataNascimento;
        string morada;
        string cartaoCidadao;        
        string nif;        
        string telefone;
        string email;
        int sexo;


        public PessoaPessoa()
        {

        }

        public PessoaPessoa(int idPessoa, string nome, string dataNascimento, string morada, string cartaoCidadao, string nif, string telefone, string email, int sexo)
        {
            this.idPessoa = idPessoa;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.morada = morada;
            this.cartaoCidadao = cartaoCidadao;
            this.nif = nif;
            this.telefone = telefone;
            this.email = email;
            this.sexo = sexo;
            
        }

        public int IdPessoa
        {
            get { return idPessoa; }
            set { idPessoa = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }
        public string CartaoCidadao
        {
            get { return cartaoCidadao; }
            set { cartaoCidadao = value; }
        }
        public string NIF
        {
            get { return nif; }
            set { nif = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }








    }
}