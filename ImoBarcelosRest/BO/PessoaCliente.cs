using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImoBarcelosRest.BO
{
    public class PessoaCliente
    {
        
        string nome;
        string morada;
        string dataNascimento;
        string telefone;
        string cartaoCidadao;
        string nif;
        string email;
        string sexo;
        string facebook;
        string linkedlin;
        string twiter;
        string escola;
        string curso;
        string ano;
        

        public PessoaCliente()
        {

        }

        public PessoaCliente(string nome, string morada, string dataNascimento, string telefone, string cartaoCidadao, string nif, string email, string sexo, string facebook, string linkedlin,string twiter, string escola, string curso, string ano)
        {
            this.nome=nome;
            this.morada=morada;
            this.dataNascimento=dataNascimento;
            this.telefone = telefone; 
            this.cartaoCidadao=cartaoCidadao;
            this.nif=nif;
            this.email=email;
            this.sexo = sexo; ;
            this.facebook=facebook;
            this.linkedlin = linkedlin;
            this.twiter=twiter;
            this.escola=escola;
            this.curso=curso;
            this.ano=ano;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }
        public string DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string CartaoCidadao
        {
            get { return cartaoCidadao; }
            set { cartaoCidadao = value; }
        }


          
        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public string Facebook
        {
            get { return facebook; }
            set { facebook = value; }
        }
        public string Twiter
        {
            get { return twiter; }
            set { twiter = value; }
        }
        public string Escola
        {
            get { return escola; }
            set { escola = value; }
        }


        public string Curso
        {
            get { return curso; }
            set { curso = value; }
        }

        public string Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        public string Linkedlin
        {
            get { return linkedlin; }
            set { linkedlin = value; }
        }



    }
}