using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PII_TP2_Vet
{
    class Producto
    {
        private int idProducto;
        private int idMarca;
        private string nom_producto;
        private double precio_unitario;
        private int stock;
        private bool activo;

        //PROPIEDADES
        public int pIdProducto
        {
            set { idProducto = value; }
            get { return idProducto; }
        }
        public int pIdMarca
        {
            set {idMarca = value; }
            get { return idMarca;}
        }
        public string pNomProducto
        {
            set { nom_producto = value; }
            get { return nom_producto;}
        }
        public double pPrecio_unitario
        {
            set { precio_unitario = value; }
            get { return precio_unitario;}
        }
        public int pStock
        {
            set {stock = value; }
            get { return stock;}
        }
        public bool pActivo
        {
            set { activo = value; }
            get { return activo; }
        }

        //CONSTRUCTORES
        public Producto()
        {
           idProducto = 0;
           idMarca = 0;
           nom_producto = "";
           precio_unitario = 0;
           stock = 0;
        }
        public Producto( int idProducto, int idMarca, string producto, double precio_unitario, int stock)
        {
          this.idProducto = idProducto;
          this.idMarca = idMarca;
          this.nom_producto = producto;
          this.precio_unitario = precio_unitario;
          this.stock = stock;
        }
        public override string ToString()
        {
            return idProducto + " - " + nom_producto;
        }
    }

}
