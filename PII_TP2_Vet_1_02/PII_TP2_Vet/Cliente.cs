using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace PII_TP2_Vet
{
    class Cliente
    {
        private int idCliente;
        private string apellido;
        private string nombre;
        private string direccion;
        private string telFijo;
        private string telCel;
        private string correo;
        private int tipoDoc;
        private string nroDoc;
        private int sexo;
        private DateTime fechaNac;
        private bool estado;

        public int pIdCliente 
        { set { idCliente = value; }
          get { return idCliente; } }
        public string pApellido
        { set { apellido = value; } 
          get { return apellido; } }
        public string pNombre
        { set { nombre = value; }
          get { return nombre; } }
        public string pDireccion
        { set { direccion = value; }
          get { return direccion; } }
        public string pTelFijo
        { set { telFijo = value; } 
          get { return telFijo; } }
        public string pTelCel
        { set { telCel = value; }
          get { return telCel; } }
        public string pCorreo 
        { set { correo = value; }
          get { return correo; } }
        public int pTipoDoc
        { set { tipoDoc = value; }
          get { return tipoDoc; } }
        public string pNroDoc 
        { set { nroDoc = value; }
          get { return nroDoc; } }
        public int pSexo
        { set { sexo = value; }
          get { return sexo; } }
        public DateTime pFechaNac
        { set { fechaNac = value; }
          get { return fechaNac; }
        }
        public bool pEstado
        { set { estado = value; }
            get { return estado; } }

        public Cliente()
        {
            idCliente = 0;
            apellido = "";
            nombre = "";
            direccion = "";
            telFijo = "";
            telCel = "";
            correo = "";
            tipoDoc = 0;
            nroDoc = "";
            sexo = 0;
            fechaNac = DateTime.Today;
        }
        public Cliente(int idCliente, string apel, string nom, string direccion, string telFijo, string telCel, string correo, int tipoD, string nroDoc, int sexo, DateTime fechaNac)
        {
            this.idCliente = idCliente;
            this.apellido = apel;
            this.nombre = nom;
            this.direccion = direccion;
            this.telFijo = telFijo;
            this.telCel = telCel;
            this.correo = correo;
            this.tipoDoc = tipoD;
            this.nroDoc = nroDoc;
            this.sexo = sexo;
            this.fechaNac = fechaNac;

        }
        public override string ToString()
        {
            return idCliente + " - " + apellido + " " + nombre;
        }
    }
}
