using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace PII_TP2_Vet
{
    public class AccesoDato
    {
        private OleDbConnection conexion;
        private OleDbCommand comando;
        private OleDbDataReader lector;
        private string cadenaConexion;

        //CONSTRUCTORES
        public AccesoDato()
        {
            conexion = new OleDbConnection();
            comando = new OleDbCommand();
            lector = null;
            cadenaConexion = null;
        }

        public AccesoDato(string cadenaConexion)
        {
            conexion = new OleDbConnection();
            comando = new OleDbCommand();
            lector = null;
            this.cadenaConexion = cadenaConexion;
        }
        
        //PROPIEDADES
        public OleDbDataReader pLector
        {
            set { lector = value; }
            get { return lector; }
        }

        public string pCadenaConexion
        {
            set { cadenaConexion = value; }
            get { return cadenaConexion; }
        }

        public OleDbCommand pComando
        {
            set { comando = value; }
            get { return comando; }
        }

        public OleDbConnection pConexion
        {
            get { return conexion; }
        }

        //METODOS
        public void conectar()
        {
            //ABRIR CONEXION
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            //ESTABLECER TIPO DE CONEXION (EN ESTE CASO CON COMANDO DE TEXTO)
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        public void desconectar()
        {
            //DESTRUYE LA CONEXION
            conexion.Close();            
            conexion.Dispose();
        }

        public DataTable consultarTabla(string nombreTabla)
        {
            DataTable tabla = new DataTable();
            conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }

        public void leerTabla(string nombreTabla)
        {
            conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            //IMPORTANTE: DATAREADER NO SE PUEDE DESCONECTAR, SINO PIERDE LOS DATOS,
            //            POR LO TANTO, ACCEDEMOS AL READER DESDE AFUERA DEL METODO
            lector = comando.ExecuteReader();
        }

        public DataTable consultarBD(string consultaSQL)
        {
            //CONSULTA GENERAL PARA CUALQUIER CONSULTA PERSONALIZADA
            DataTable tabla = new DataTable();
            conectar();
            comando.CommandText = consultaSQL;
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }

        public void actualizarBD(string consultaSQL)
        {
            //PARA EJECUTAR LOS INSERT, UPDATE Y LOS DELETE DE REGISTROS
            conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();
            desconectar();
        }
    }
}
