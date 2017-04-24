using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanControlServicos.BO
{
    public class Picagem
    {
        List<byte> carateristicas;
        string morada;
        string localidade;
        DateTime data;

        public Picagem()
        {

        }

        public Picagem(List<byte> carateristicas, string morada, string localidade, DateTime data)
        {

            this.carateristicas = carateristicas;
            this.morada = morada;
            this.localidade = localidade;
            this.data = data;

        }
        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        public string Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }
        public List<byte> Carateristicas
        {
            get { return carateristicas; }
            set { carateristicas = value; }
        }
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }


    }
}