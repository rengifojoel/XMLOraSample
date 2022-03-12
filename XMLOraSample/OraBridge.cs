using System;

namespace XMLOraSample
{
    public class OraBridge
    {
        public static void passXmlAsCLOB (string content, ref string successProof)
        {
            Oracle.ManagedDataAccess.Client.OracleConnection conn = new Oracle.ManagedDataAccess.Client.OracleConnection("YOUR CONNECTION_STRING") ;
            conn.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
            cmd.CommandText = "XMLHANDLER.XMLHANDLERWITHCLOBPARAM";
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Oracle.ManagedDataAccess.Client.OracleParameter inputParam = cmd.Parameters.Add("XMLCONTENT", Oracle.ManagedDataAccess.Client.OracleDbType.Clob);
            inputParam.Direction = System.Data.ParameterDirection.Input;
            inputParam.Value = content;
            Oracle.ManagedDataAccess.Client.OracleParameter outParam = cmd.Parameters.Add("SUCCESSPROOF", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,100);
            outParam.Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            successProof = cmd.Parameters["SUCCESSPROOF"].Value.ToString();
            conn.Close();
        }
        public static void passXmlAsXML(System.Xml.XmlDocument content, ref string successProof)
        {
            Oracle.ManagedDataAccess.Client.OracleConnection conn = new Oracle.ManagedDataAccess.Client.OracleConnection("YOUR_CONNECTION_STRING");
            conn.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
            cmd.CommandText = "XMLHANDLER.XMLHANDLERWITHXMLPARAM";
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Oracle.ManagedDataAccess.Client.OracleParameter inputParam = cmd.Parameters.Add("XMLCONTENT", Oracle.ManagedDataAccess.Client.OracleDbType.XmlType);
            inputParam.Direction = System.Data.ParameterDirection.Input;

            inputParam.Value = content.OuterXml;
            Oracle.ManagedDataAccess.Client.OracleParameter outParam = cmd.Parameters.Add("SUCCESSPROOF", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, 100);
            outParam.Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            successProof = cmd.Parameters["SUCCESSPROOF"].Value.ToString();
            conn.Close();
        }

    }
}
