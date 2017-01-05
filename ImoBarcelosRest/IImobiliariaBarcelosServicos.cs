using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ImoBarcelosRest.BO;

namespace ImoBarcelosRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImobiliariaBarcelosServicos" in both code and config file together.
    [ServiceContract]
    public interface IImobiliariaBarcelosServicos
    {

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Habitacoes")]
        List<Habitacao> Habitacoes();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Habitacao/{id}")]
        Habitacao HabitacaoId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Arrendatario")]
        List<PessoaArrendatario> Arrendatario();


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AdicionaHabiticao/{morada}/{assoalhadas}/{quartos}/{area}/{anoC}/{internet}/{wifi}/{tipologia}/{idArrendatario}")]
        bool AdicionaHabiticao(string morada, string assoalhadas, string quartos, string area, string anoC,string internet,string wifi,string tipologia, string idArrendatario);


        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AlteraDadosHabitacao/{morada}/{assoalhadas}/{quartos}/{area}/{anoC}/{internet}/{wifi}/{tipologia}/{idArrendatario}/{idHabitacao}")]
        bool AlteraDadosHabitacao(string morada, string assoalhadas, string quartos, string area, string anoC, string internet, string wifi, string tipologia, string idArrendatario,string idHabitacao);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ApagarHabitacao/{id}")]
        bool ApagarHabitacao(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "Pessoas")]
        List<Pessoa> Pessoas();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "PessoasHobbie")]
        List<PHobbie> PessoasHobbie();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Cliente")]
        bool InsereCliente(PessoaCliente novo);



    }


}
