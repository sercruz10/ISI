using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using HumanControlServicos.BO;
using System.Data;
using System.IO;
using DPFP;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace HumanControlServicos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HumanControlServicos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HumanControlServicos.svc or HumanControlServicos.svc.cs at the Solution Explorer and start debugging.
    [WebService(Namespace = "http://localhost:30463/HumanControlServicos.svc/", Description = "ImobiliariaBarcelos", Name = "IMOBARCELOS")]
    public class HumanControlServicos : IIHumanControlServicos
    {
        #region Adiciona Habitação
        /// <summary>
        /// Adiciona Habitação
        /// </summary>
        /// <param name="morada"></param>
        /// <param name="assoalhadas"></param>
        /// <param name="quartos"></param>
        /// <param name="area"></param>
        /// <param name="anoC"></param>
        /// <param name="internet"></param>
        /// <param name="wifi"></param>
        /// <param name="tipologia"></param>
        /// <param name="idArrendatario"></param>
        /// <returns>True or False</returns>
        public bool AdicionaHabiticao(string morada, string assoalhadas, string quartos, string area, string anoC, string internet, string wifi, string tipologia, string idArrendatario)
        {
            try
            {
                string query = @"INSERT INTO Habitacao(Morada, NAssoalhadas, NQuartos, Area, AnoConstrucao, Internet, Wifi, Tipologia, Arrendatario_IdArrendatario)" +
                    "VALUES (@morada, @assoalhadas, @quartos, @area,@anoC, @internet, @wifi, @tipologia, @idArrendatario)";
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBImobiliarioEntities"].ConnectionString);
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                //cmd.Parameters.AddWithValue("@id", DBNull.Value);
                cmd.Parameters.AddWithValue("@morada", morada);
                cmd.Parameters.AddWithValue("@assoalhadas", assoalhadas);
                cmd.Parameters.AddWithValue("@quartos", quartos);
                cmd.Parameters.AddWithValue("@area", area);
                cmd.Parameters.AddWithValue("@anoC", anoC);
                cmd.Parameters.AddWithValue("@internet", internet);
                cmd.Parameters.AddWithValue("@wifi", wifi);
                cmd.Parameters.AddWithValue("@tipologia", tipologia);
                cmd.Parameters.AddWithValue("@idArrendatario", int.Parse(idArrendatario));
                sqlConnection.Open();
                int i = cmd.ExecuteNonQuery();
                if (!(i == 0 || i == -1))
                {
                    return true;
                }
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }



        }

        #endregion

        #region Altera Dados de uma Habitação
        /// <summary>
        /// Altera Dados Habitação
        /// </summary>
        /// <param name="morada"></param>
        /// <param name="assoalhadas"></param>
        /// <param name="quartos"></param>
        /// <param name="area"></param>
        /// <param name="anoC"></param>
        /// <param name="internet"></param>
        /// <param name="wifi"></param>
        /// <param name="tipologia"></param>
        /// <param name="idArrendatario"></param>
        /// <param name="idHabitacao"></param>
        /// <returns>true or false</returns>
        public bool AlteraDadosHabitacao(string morada, string assoalhadas, string quartos, string area, string anoC, string internet, string wifi, string tipologia, string idArrendatario, string idHabitacao)
        {
            try
            {
                string query = "UPDATE Habitacao SET Morada = @morada, NAssoalhadas=@assoalhadas, NQuartos=@quartos, Area=@area,AnoConstrucao=@anoC, Internet=@internet, Wifi=@wifi,Tipologia=@tipologia, Arrendatario_IdArrendatario=@idArrendatario WHERE IdHabitacao = @idHabitacao";
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBImobiliarioEntities"].ConnectionString);
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@idHabitacao", int.Parse(idHabitacao));
                cmd.Parameters.AddWithValue("@morada", morada);
                cmd.Parameters.AddWithValue("@assoalhadas", assoalhadas);
                cmd.Parameters.AddWithValue("@quartos", quartos);
                cmd.Parameters.AddWithValue("@area", assoalhadas);
                cmd.Parameters.AddWithValue("@anoC", anoC);
                cmd.Parameters.AddWithValue("@internet", internet);
                cmd.Parameters.AddWithValue("@wifi", wifi);
                cmd.Parameters.AddWithValue("@tipologia", tipologia);
                cmd.Parameters.AddWithValue("@idArrendatario", int.Parse(idArrendatario));
                sqlConnection.Open();
                int i = cmd.ExecuteNonQuery();
                if (!(i == 0 || i == -1))
                {
                    return true;
                }
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion

        #region Elimina Habitação

        /// <summary>
        /// Elimina Habitação pelo ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>true or false</returns>
        public bool ApagarHabitacao(string id)
        {
            try
            {
                string query = "DELETE FROM Habitacao WHERE IdHabitacao = @id";
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBImobiliarioEntities"].ConnectionString);
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@id", int.Parse(id));

                sqlConnection.Open();
                int i = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (!(i == 0 || i == -1))
                {
                    return true;
                }
                sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Lista Arrendátarios
        /// <summary>
        /// Lista de Arrendatarios
        /// </summary>
        /// <returns>Arrendatarios</returns>
        public List<PessoaArrendatario> Arrendatario()
        {
            List<PessoaArrendatario> arrendatarios = new List<PessoaArrendatario>();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBImobiliarioEntities"].ConnectionString);
            try
            {
                string query = @"SELECT Arrendatario.IdArrendatario as Id, Nome FROM Pessoa inner join Arrendatario on Pessoa.IdPessoa=Arrendatario.Pessoa_IdPessoa";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Pessoa a = new Pessoa();

                try
                {
                    if (dr.HasRows)
                    {
                        // Percorre o DataReader
                        while (dr.Read())
                        {
                            arrendatarios.Add(new PessoaArrendatario() { Id = Convert.ToInt32(dr["Id"]), Nome = Convert.ToString(dr["Nome"]) });
                        }
                    }
                }
                finally
                {
                    // Fecha o DataReader
                    dr.Close();
                }
            }
            finally
            {
                // Fecha a conexão
                sqlConnection.Close();
            }

            return arrendatarios;
        }

        #endregion

        #region Lista Pessoas

        /// <summary>
        /// Lista Pessoas Registadas na Imobiliaria
        /// </summary>
        /// <returns>Lista de Pessoas</returns>
        public List<PessoaPessoa> Pessoas()
        {
            List<PessoaPessoa> pessoas = new List<PessoaPessoa>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBImobiliarioEntities"].ConnectionString);
            try
            {
                string str = "SELECT IdPessoa, Nome, Morada,DataNascimento,Telefone,CartaoCidado,Email,NIF,Sexo_IdSexo FROM Pessoa";
                SqlCommand novo = new SqlCommand(str, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = novo.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        pessoas.Add(new PessoaPessoa() { IdPessoa = Convert.ToInt32(reader["IdPessoa"]), Nome = Convert.ToString(reader["Nome"]), Morada = Convert.ToString(reader["Morada"]), DataNascimento = Convert.ToString(reader["DataNascimento"]), Telefone = Convert.ToString(reader["Telefone"]), CartaoCidadao = Convert.ToString(reader["CartaoCidado"]), Email = Convert.ToString(reader["Email"]), NIF = Convert.ToString(reader["NIF"]), Sexo = Convert.ToInt32(reader["Sexo_IdSexo"]) });

                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {

                sqlConnection.Close();
            }

            return pessoas;
        }
        #endregion

        #region Habitações
        /// <summary>
        /// Devolve todas Habitações
        /// </summary>
        /// <returns>Lista Habitações</returns>
        public List<Habitacao> Habitacoes()
        {
            List<Habitacao> listaHabitacoes = new List<Habitacao>();
            Habitacao habitacao = new Habitacao();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBImobiliarioEntities"].ConnectionString);
            try
            {
                string query = @"Select *from Habitacao";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader dReader = cmd.ExecuteReader();
                try
                {
                    while (dReader.Read())
                    {
                        listaHabitacoes.Add(new Habitacao() { IdHabitacao = Convert.ToInt32(dReader["IdHabitacao"]), Morada = Convert.ToString(dReader["Morada"]), NAssoalhadas = Convert.ToString(dReader["NAssoalhadas"]), NQuartos = Convert.ToString(dReader["NQuartos"]), Area = Convert.ToString(dReader["Area"]), AnoConstrucao = Convert.ToString(dReader["AnoConstrucao"]), Internet = Convert.ToString(dReader["Internet"]), Wifi = Convert.ToString(dReader["Wifi"]), Tipologia = Convert.ToString(dReader["Tipologia"]), Arrendatario_IdArrendatario = Convert.ToInt16(dReader["Arrendatario_IdArrendatario"]) });
                    }
                }
                finally
                {
                    // Fecha o DataReader
                    dReader.Close();
                }
            }

            catch (Exception ex)
            {


            }
            finally
            {
                // Fecha a conexão
                sqlConnection.Close();
            }

            return listaHabitacoes;


        }

        #endregion

        #region Devolve Habitação
        /// <summary>
        /// Devolve Habitação Pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Habitação</returns>
        Habitacao IIHumanControlServicos.HabitacaoId(string id)
        {

            Habitacao habitacao = new Habitacao();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBImobiliarioEntities"].ConnectionString);

            try
            {
                string query = @"Select *from Habitacao Where IdHabitacao=@id";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                SqlDataReader dReader = cmd.ExecuteReader();

                try
                {

                    while (dReader.Read())
                    {
                        habitacao.AnoConstrucao = Convert.ToString(dReader["AnoConstrucao"]);
                        habitacao.Area = Convert.ToString(dReader["Area"]);
                        habitacao.Arrendatario_IdArrendatario = Convert.ToInt16(dReader["Arrendatario_IdArrendatario"]);
                        habitacao.Internet = Convert.ToString(dReader["Internet"]);
                        habitacao.Morada = Convert.ToString(dReader["Morada"]);
                        habitacao.NAssoalhadas = Convert.ToString(dReader["NAssoalhadas"]);
                        habitacao.NQuartos = Convert.ToString(dReader["NQuartos"]);
                        habitacao.Tipologia = Convert.ToString(dReader["Tipologia"]);

                    }
                }
                finally
                {
                    // Fecha o DataReader
                    dReader.Close();
                }
            }

            catch (Exception ex)
            {


            }
            finally
            {
                // Fecha a conexão
                sqlConnection.Close();
            }

            return habitacao;
        }


        #endregion

        #region Cliente Hobbie
        /// <summary>
        /// Lista Cliente e seu respectivo Hobbie
        /// </summary>
        /// <returns>Lista</returns>
        public List<PHobbie> PessoasHobbie()
        {
            List<PHobbie> lista = new List<PHobbie>();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBImobiliarioEntities"].ConnectionString);

            try
            {
                string query = @"Select Nome, Morada, Email, Hobbie.Designacao from Pessoa Inner Join Cliente on Pessoa.IdPessoa=Cliente.Pessoa_IdPessoa
                                Inner Join RClienteHoobieSet on Cliente.IdCliente=RClienteHoobieSet.Cliente_IdCliente
                                inner Join Hobbie on RClienteHoobieSet.Hobbie_IdHobbie=Hobbie.IdHobbie";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                //cmd.Parameters.AddWithValue("@id", int.Parse(id));
                SqlDataReader dReader = cmd.ExecuteReader();
                try
                {

                    while (dReader.Read())
                    {

                        lista.Add(new PHobbie()
                        {
                            Nome = Convert.ToString(dReader["Nome"]),
                            Morada = Convert.ToString(dReader["Morada"]),
                            Email = Convert.ToString(dReader["Email"]),
                            Gosto = Convert.ToString(dReader["Designacao"])
                        });

                    }
                }

                finally
                {
                    // Fecha o DataReader
                    dReader.Close();
                }
            }

            catch (Exception ex)
            {


            }
            finally
            {
                // Fecha a conexão
                sqlConnection.Close();
            }
            return lista;
        }

        #endregion

        #region Insere Cliente

        public bool InsereCliente(PessoaCliente novo)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBImobiliarioEntities"].ConnectionString);
            int id;
            try
            {
                string str = "INSERT INTO Pessoa(Nome, Morada,DataNascimento, Telefone, CartaoCidado, NIF, Email, Sexo_IdSexo) VALUES(@name, @adress,@birtday, @phone, @cc, @nifff, @mailll, @Id_Sexo)";
                SqlCommand cmd = new SqlCommand(str, sqlConnection);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = novo.Nome;
                cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = novo.Morada;
                cmd.Parameters.Add("@birtday", SqlDbType.NVarChar).Value = novo.DataNascimento;
                cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = novo.Telefone;
                cmd.Parameters.Add("@cc", SqlDbType.NVarChar).Value = novo.CartaoCidadao;
                cmd.Parameters.Add("@nifff", SqlDbType.NVarChar).Value = novo.Nif;
                cmd.Parameters.Add("@mailll", SqlDbType.NVarChar).Value = novo.Email;

                if (novo.Sexo.ToString() == "Masculino")
                {
                    cmd.Parameters.Add("@Id_Sexo", SqlDbType.NVarChar).Value = 2;
                }
                if (novo.Sexo.ToString() != "Masculino")
                {
                    cmd.Parameters.Add("@Id_Sexo", SqlDbType.NVarChar).Value = 1;

                }
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();


            }
            catch (Exception a)
            {

                return false;


            }


            try
            {

                sqlConnection.Open();
                string IdUltimoPessoa = "SELECT * FROM Pessoa ORDER BY IdPessoa DESC";
                SqlCommand ultimo = new SqlCommand(IdUltimoPessoa, sqlConnection);
                DataSet dsConsulta = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(ultimo);
                sda.Fill(dsConsulta);
                int valor = Convert.ToInt16(dsConsulta.Tables[0].Rows[0]["IdPessoa"]);
                id = valor;
                sqlConnection.Close();
            }


            catch (Exception a)
            {
                return false;

            }

            try
            {
                string query = "INSERT INTO Utilizador(UserName, Password, Tipo) VALUES(@user, @pass, @type)";
                SqlCommand comando = new SqlCommand(query, sqlConnection);
                comando.Parameters.Add("@user", SqlDbType.NVarChar).Value = novo.Email;
                comando.Parameters.Add("@pass", SqlDbType.NVarChar).Value = novo.Nif;
                comando.Parameters.Add("@type", SqlDbType.NVarChar).Value = "Cliente";
                sqlConnection.Open();
                comando.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception a)
            {
                return false;

            }

            int idUtilizador;
            try
            {
                sqlConnection.Open();
                string IdUltimoPessoa = "SELECT * FROM Pessoa ORDER BY IdPessoa DESC";
                SqlCommand ultimo = new SqlCommand(IdUltimoPessoa, sqlConnection);
                DataSet dsConsulta = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(ultimo);
                sda.Fill(dsConsulta);
                int valor = Convert.ToInt16(dsConsulta.Tables[0].Rows[0]["IdPessoa"]);
                id = valor;
                sqlConnection.Close();
            }


            catch (Exception a)
            {
                return false;

            }
            try
            {
                sqlConnection.Open();
                string IdUltimoPessoa = "SELECT * FROM Utilizador ORDER BY IdUtilizador DESC";
                SqlCommand ultimo = new SqlCommand(IdUltimoPessoa, sqlConnection);
                DataSet dsConsulta = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(ultimo);
                sda.Fill(dsConsulta);
                int valor = Convert.ToInt16(dsConsulta.Tables[0].Rows[0]["IdUtilizador"]);
                idUtilizador = valor;
                sqlConnection.Close();
            }
            catch (Exception a)
            {
                return false;

            }

            try
            {
                string str = "INSERT INTO Cliente(Facebook, Linkedlin,Twiter,Instituto, Curso, AnoEscolar, Pessoa_IdPessoa, Utilizador_IdUtilizador) VALUES(@face, @link, @twi, @escola, @curso, @ano, @IdPessoa, @UtiPessoa)";
                SqlCommand cmd = new SqlCommand(str, sqlConnection);
                cmd.Parameters.Add("@face", SqlDbType.NVarChar).Value = novo.Facebook;
                cmd.Parameters.Add("@link", SqlDbType.NVarChar).Value = novo.Linkedlin;
                cmd.Parameters.Add("@twi", SqlDbType.NVarChar).Value = novo.Twiter;
                cmd.Parameters.Add("@escola", SqlDbType.NVarChar).Value = novo.Escola;
                cmd.Parameters.Add("@curso", SqlDbType.NVarChar).Value = novo.Curso;
                cmd.Parameters.Add("@ano", SqlDbType.NVarChar).Value = novo.Escola;
                cmd.Parameters.Add("@IdPessoa", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@UtiPessoa", SqlDbType.Int).Value = idUtilizador;
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception a)
            {
                return false;
            }





            return true;
        }

        #endregion

        #region Fingerprint

        public string Nome(Picagem colaborador)
        {
            byte[] array = new byte[colaborador.Carateristicas.Capacity];
            int i = 0;
            foreach (var item in colaborador.Carateristicas)
            {
                array[i] = colaborador.Carateristicas[i];
                i++;
            }
            Stream stream = new MemoryStream(array);
            DPFP.FeatureSet carateristicas = new DPFP.FeatureSet(stream);
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBHumanControl"].ConnectionString);
            string nome = "";
            DPFP.Template template = new DPFP.Template();
            DPFP.Verification.Verification verificador = new DPFP.Verification.Verification();
            if (carateristicas != null)
            {
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                try
                {
                    sqlConnection.Open();
                    string str = "SELECT *FROM EmployeeSet";
                    SqlCommand cmd = new SqlCommand(str, sqlConnection);
                    bool flag = false;
                    string name = "";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            name = reader["Nome"].ToString();
                            byte[] img = (byte[])(reader["Fingerprint"]);
                            MemoryStream mss = new MemoryStream(img);
                            template.DeSerialize(mss.ToArray());

                            verificador.Verify(carateristicas, template, ref result);
                            if (result.Verified)
                            {
                                name = reader["Nome"].ToString();
                                flag = true;
                                reader.Close();
                                break;
                            }

                        }
                    }
                    if (flag == true)
                    { 
                        nome = name;
                    }
                    else
                        nome = "Não registado";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    reader.Close();


                }
                catch (Exception b)
                {
                    nome = b.ToString();

                }
            }
            return nome;
        }

        #endregion

        public List<NomeNumero> Names()
        {
            List<NomeNumero> pessoas = new List<NomeNumero>();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBHumanControl"].ConnectionString);
            try
            {
                string str = "SELECT *FROM EmployeeSet";
                SqlCommand novo = new SqlCommand(str, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = novo.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        pessoas.Add(new NomeNumero() { Numero = Convert.ToInt32(reader["IdEmployee"]), Nome = Convert.ToString(reader["Nome"]) });

                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {

                sqlConnection.Close();
            }


            return pessoas;
        }


    }
}
