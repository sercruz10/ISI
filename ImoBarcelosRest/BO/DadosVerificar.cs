using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanControlServicos.BO
{
    public class DadosVerificar
    {
        DPFP.FeatureSet carateristicas;

        public DadosVerificar()
        {

        }
        public DadosVerificar(DPFP.FeatureSet carateristicas)
        {

            this.carateristicas = carateristicas;

        }

        DPFP.FeatureSet Carateristicas
        {
            get { return carateristicas; }
            set { carateristicas = value; }
        }
    }
}