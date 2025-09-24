using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Gestor_PnL.Classes
{
    class SQLConnectionClass
    {
        //connection string to connect to development database
        //public string constring = "Server=br02-wdb2\\desenv;Database=DPDPC1;User Id=PDPCuser;Password=PDPCpassword;";

        //connection string to connect to production database
        public string constring = "Server=br02-wdb1\\mssqlserver_prd1;Database=PLEDIGITAL;User Id=gestorpnl_user;Password=gestorpnl_user@2023;";


        //public string constring = Classes.GlobalVariablesClass.ConnectionStringServidor;

        #region Declaracao de Variaveis globais

        private bool _State;                // Indica ULTIMO Status da conexão
        private string _ErrorMessage;       // Indica ULTIMO Mensagem de Erro da conexao
        private int _ErrorNumber;           // Indica ULTIMO Numero de Erro da conexao

        private bool _CompleteCommand;      // Indica ULTIMO comando foi executado com sucesso

        private int _IdInserted;              // Scope Identity 

        private SqlDataReader _rsData;        // Usado para retornar colecao de registros
        private SqlDataAdapter _daData;       // Cria um dataAdapter para tratar a conexão
        private OleDbDataAdapter _daDataOLE;  // Cria um dataAdapter para tratar a conexão
        private DataTable _dtData;            // Cria um datatable para tratar o resultado
        private DataSet _dsData = new DataSet();            // Cria um datatable para tratar o resultado
        private DataTable _dtDataOLE;         // Cria um datatable para tratar o resultado
        private OleDbConnection _connOleDb;   // Conexão com banco Ole
        private SqlConnection _connSQL;       //Conexão SQL
        private SqlTransaction _tranSQL;      // Transação a ser comparrtilhada


        #endregion

        #region Properties

        public DataSet DataSet
        {
            get { return _dsData; }
        }
        public SqlDataReader RecordSet
        {
            // Metodo para ler os registros
            get { return _rsData; }
        }

        public SqlDataAdapter DataAdapter
        {
            //
            get { return _daData; }
        }

        public OleDbDataAdapter DataAdapterOLE
        {
            //
            get { return _daDataOLE; }
        }

        public DataTable DataTable
        {
            get { return _dtData; }
        }

        public DataTable DataTableOLE
        {
            get { return _dtDataOLE; }
        }

        public int ErrorNumber
        {
            // Metodo para ler ultimo código de error
            get { return _ErrorNumber; }
        }


        public int IdInserted
        {
            // Metodo para ler ultimo código de error
            get { return _IdInserted; }
        }

        public string ErrorDescription
        {
            // Metodo para ler ultima descrição de error
            get { return _ErrorMessage; }
        }
        public bool ConnectionState
        {
            // Metodo para ler ultimo status da conexao
            get { return _State; }
        }
        public bool CompleteCommand
        {
            // Metodo para ler status do ultimo comando executado.
            get { return _CompleteCommand; }
        }
        public OleDbConnection connOleDb
        {
            get { return _connOleDb; }
        }

        public SqlConnection connSQL
        {
            get { return _connSQL; }
        }

        public SqlTransaction tranSQL
        {
            get { return _tranSQL; }
        }
        #endregion

        #region Definicao de Metodos SQL

        /// <summary>
        /// Metodo responsavel por executar uma instrução SQL
        /// Recebe como parametro o nome de uma chave do arquivo web.config que contem string de conexão e
        /// a instrução SQL a ser executada pode ser um SELECT ou uma procedure (preferencialmente)
        /// Utilizo Try..Catch para tratamento de erro
        /// </summary>
        /// <param name="myConnectionName"></param>
        /// <param name="myQueryString"></param>
        public void ExecuteCommand(string myConnectionName, string myQueryString, SqlParameter[] oParametro, bool bProcedure, bool bRetornaDS, string sNome)
        {

            // Definir valores padrões das variaveis
            _ErrorMessage = "";
            _State = false;
            _CompleteCommand = false;

            try
            {


                // Se nao for passado nenhuma chave de conexão do arquivo web.config
                // vou setar uma chave padrao de conexão do arquivo Web.Config
                if (myConnectionName.Length == 0)
                { // Aqui estou indicando o nome da chave que contem a string de conexão no arquivo web.config
                    myConnectionName = "PPDPC1";
                }

                //string myConnectionString = ConfigurationManager.ConnectionStrings[myConnectionName].ToString();
                string myConnectionString = constring;

                // Se não for informado comando T-SQL retorno error
                if (myQueryString.Length > 0) // Se realmente foi passado um comando a ser executado
                {
                    // Inicio uma conexão com o banco de dados
                    SqlConnection myConnection = new SqlConnection(myConnectionString);
                    // Abro a conexão

                    myConnection.Open();

                    // Inicio um comando
                    SqlCommand myCommand = new SqlCommand(myQueryString, myConnection);

                    if (bProcedure)
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                    }

                    if (oParametro != null)
                    {
                        foreach (SqlParameter oParam in oParametro)
                        {

                            myCommand.Parameters.Add(oParam);
                        }
                    }

                    if (bRetornaDS)
                    {

                        _dsData.Clear();

                        _dsData.DataSetName = sNome;

                        _daData = new SqlDataAdapter(myCommand);

                        //* Set up data adapter and fill dataset
                        _daData.SelectCommand = myCommand;
                        _daData.Fill(_dsData, sNome);

                    }
                    else
                    {
                        //Executo um comando com ExecuteReader, pois este retorna dados a um SqlDataReader
                        _rsData = myCommand.ExecuteReader(); // Executo do comando

                    }

                    _State = true;                      // Indico o status da operação 
                    _CompleteCommand = true;
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro seto as variaveis abaixo
                MessageBox.Show(ex.Message.ToString(), "Erro na conexão com servidor", MessageBoxButtons.OK);
                _ErrorMessage = ex.Message.ToString();
                _State = false;
                _ErrorNumber = ex.GetHashCode();
            }
        }

        public void ExecuteNoQuerySQL(string myQueryString, string sTrans, SqlParameter[] oParametro, bool bProcedure)
        {

            // Definir valores padrões das variaveis
            _ErrorMessage = "";
            _State = false;
            _CompleteCommand = false;

            try
            {
                if (_connSQL.State == System.Data.ConnectionState.Open) // Se a transação estiver aberta
                {

                    // Inicio um comando
                    SqlCommand myCommand = new SqlCommand(myQueryString, _connSQL);

                    if (sTrans != "")
                    {

                        BeginTransactionSQL(sTrans);

                    }

                    if (bProcedure)
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                    }

                    if (oParametro != null)
                    {
                        foreach (SqlParameter oParam in oParametro)
                        {
                            if (oParam != null)
                            {
                                myCommand.Parameters.Add(oParam);
                            }
                        }
                    }

                    myCommand.Transaction = _tranSQL;

                    // Executo um comando com ExecuteNoQuery sem retornar dados
                    myCommand.ExecuteNonQuery(); // Executo do comando

                    _State = true;                      // Indico o status da operação 
                    _CompleteCommand = true;
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro seto as variaveis abaixo
                MessageBox.Show(ex.Message.ToString());
                _ErrorMessage = ex.Message.ToString();
                _State = false;
                _ErrorNumber = ex.GetHashCode();
            }
        }

        public void ExecuteEscalarSQL(string myQueryString, string sTrans)
        {

            // Definir valores padrões das variaveis
            _ErrorMessage = "";
            _State = false;
            _CompleteCommand = false;

            try
            {
                if (_connSQL.State == System.Data.ConnectionState.Open) // Se a transação estiver aberta
                {

                    // Inicio um comando
                    SqlCommand myCommand = new SqlCommand(myQueryString, _connSQL);

                    if (sTrans != "")
                    {

                        BeginTransactionSQL(sTrans);

                    }

                    myCommand.Transaction = _tranSQL;


                    // Executo um comando com ExecuteNoQuery sem retornar dados
                    _IdInserted = (int)myCommand.ExecuteScalar();

                    _State = true;                      // Indico o status da operação 
                    _CompleteCommand = true;
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro seto as variaveis abaixo
                _ErrorMessage = ex.Message.ToString();
                _State = false;
                _ErrorNumber = ex.GetHashCode();
            }
        }

        public void RetornaDataTable(string myQueryString)
        {

            // Definir valores padrões das variaveis
            _ErrorMessage = "";
            _State = false;
            _CompleteCommand = false;

            try
            {

                // Se não for informado comando T-SQL retorno error
                if (_connSQL.State == System.Data.ConnectionState.Open) // Se a conexão estiver aberta
                {

                    //Populo o data Adapter
                    _daData = new SqlDataAdapter(myQueryString, _connSQL);
                    SqlCommandBuilder cBuilder = new SqlCommandBuilder(_daData);

                    _dtData = new DataTable();
                    _daData.Fill(_dtData);

                    _connSQL.Close();

                    _State = true;                      // Indico o status da operação 
                    _CompleteCommand = true;

                }
                else
                {
                    _ErrorMessage = "A conexão com a base de dados está fechada.";
                    _State = false;
                    _ErrorNumber = 0;
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro seto as variaveis abaixo
                _ErrorMessage = ex.Message.ToString();
                _State = false;
                _ErrorNumber = ex.GetHashCode();
            }
        }

        public void ConnectSQL(string myConnectionName)
        {
            // Definir valores padrões das variaveis
            _ErrorMessage = "";
            _State = false;

            // Se nao for passado nenhuma chave de conexão do arquivo web.config
            // vou setar uma chave padrao de conexão do arquivo Web.Config
            if (myConnectionName.Length == 0)
            { // Aqui estou indicando o nome da chave que contem a string de conexão no arquivo web.config
                myConnectionName = "PLEDIGITAL";
            }

            //string myConnectionString = ConfigurationManager.ConnectionStrings[myConnectionName].ToString();
            string myConnectionString = constring;

            try
            {
                // Inicio uma conexão com o banco de dados
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                // Abro a conexão
                myConnection.Open();

                _connSQL = myConnection;

                _State = true;

            }
            catch (Exception ex)
            {
                // Em caso de erro seto as variaveis abaixo
                _ErrorMessage = ex.Message.ToString();
                _State = false;
                _ErrorNumber = ex.GetHashCode();
            }

        }

        public void BeginTransactionSQL(string Nome)
        {
            _tranSQL = _connSQL.BeginTransaction(Nome);
        }

        public void CommitTransactionSQL()
        {
            _tranSQL.Commit();
        }

        public void RollBackTransactionSQL(string Nome)
        {
            _tranSQL.Rollback(Nome);
        }

        public void CloseConnectionSQL()
        {
            _connSQL.Close();
        }


        #endregion

        #region Definição de Métodos OLEBD
        public void RetornaDataOLE(OleDbConnection myConnection, string sSQL)
        {

            // Definir valores padrões das variaveis
            _ErrorMessage = "";
            _State = false;
            _CompleteCommand = false;

            try
            {

                _daDataOLE = new OleDbDataAdapter(sSQL, myConnection);

                _dtDataOLE = new DataTable();

                _daDataOLE.Fill(_dtDataOLE);

                myConnection.Close();

                _State = true;                      // Indico o status da operação 
                _CompleteCommand = true;

            }
            catch (Exception ex)
            {
                // Em caso de erro seto as variaveis abaixo
                _ErrorMessage = ex.Message.ToString();
                _State = false;
                _ErrorNumber = ex.GetHashCode();
            }


        }

        public void ConnectOleDb(string appPath)
        {
            // Definir valores padrões das variaveis
            _ErrorMessage = "";
            _State = false;

            try
            {
                OleDbConnection connOleDb = new OleDbConnection();

                connOleDb.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data source= '" + appPath + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";
                connOleDb.Open();

                _connOleDb = connOleDb;

                _State = true;

            }
            catch (Exception ex)
            {
                // Em caso de erro seto as variaveis abaixo
                _ErrorMessage = ex.Message.ToString();
                _State = false;
                _ErrorNumber = ex.GetHashCode();
            }

        }
        #endregion
    }
}

