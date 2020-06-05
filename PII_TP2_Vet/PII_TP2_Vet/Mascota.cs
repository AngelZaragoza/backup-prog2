using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace PII_TP2_Vet
{
    class Mascota
    {
        private int idMascota;
        private int idCliente;
        private string nombre;
        private int tipoMascota;
        private DateTime fechaNac;
        private bool sexo;
        private int raza;
        private int peso;
        private string observacion;
        private bool estado;
        
        //PROPIEDADES
        public int pIdMascota { set { idMascota = value; } get { return idMascota; } }
        public int pIdCliente { set { idCliente = value; } get { return idCliente; } }
        public string pNombre { set { nombre = value; } get { return nombre; } }
        public int pTipoMascota { set { tipoMascota = value; } get { return tipoMascota; } }
        public DateTime pFechaNac { set { fechaNac = value; } get { return fechaNac; } }
        public bool pSexo { set { sexo = value; } get { return sexo; } }
        public int pRaza { set { raza = value; } get { return raza; } }
        public int pPeso { set { peso = value; } get { return peso; } }
        public string pObservacion { set { observacion = value; } get { return observacion; } }        
        public bool pEstado { set { estado = value; } get { return estado; } }
        
        //CONSTRUCTORES
        public Mascota()
        {
            idMascota = 0;
            idCliente= 0;
            nombre = "";
            tipoMascota = 0;
            fechaNac = DateTime.Today;
            sexo = false;
            raza = 0;
            peso = 0;
            observacion = "";            
            estado = false;
        }

        public Mascota(int idMascota, int idCliente, string nombre, int TipoMascota, DateTime fechaNac,  bool sexo, int idRaza,int peso, string observacion, bool estado)
        {
            this.idMascota = idMascota;
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.tipoMascota = TipoMascota;
            this.fechaNac = fechaNac;
            this.sexo = sexo;
            this.raza = idRaza;
            this.peso = peso;
            this.observacion = observacion;            
            this.estado = estado;
        }

        //METODOS
        public override string ToString()
        {
            return idMascota + " - " + nombre;
        }
    }
}
