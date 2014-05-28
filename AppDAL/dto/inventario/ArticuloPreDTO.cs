using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
    public class ArticuloPreDTO
    {

        //Propiedades
        private int _IdArticuloPre;
        private string _CodigoArticulo;
        private int _IdUnidadMedida;
        private string _Descripcion;
        private string _Codigo;
        private int _IdClase;
        private int _IdFamilia;
        private int _IdProyecto;
        private Decimal _UltimoPrecioOc;
        private string _CodigoOriginal;
        private int _TiempoUtilMeses;
        private string _Modelo;
        private string _Marca;
        private string _Estado;
        private DateTime _FechaCreacion;
        private int _IdUsuarioCreacion;
        private DateTime _FechaModificacion;
        private int _IdUsuarioModificacion;
        private int _IdArticulo;

        private string _NombreClase;
        private string _NombreFamilia;
        private string _NombreProyecto;
        private string _NombreUnidadMedida;


        private string _Serie;
        private string _Lote;
        private DateTime _FechaVencimiento;
        private string _Observaciones;
        private string _ObservacionesAlmacenamiento;

        //Constructor

      public ArticuloPreDTO() { }

      public ArticuloPreDTO(int _IdArticuloPre, string _CodigoArticulo, int _IdUnidadMedida, string _Descripcion, string _Codigo, int _IdClase, int _IdFamilia, int _IdProyecto, Decimal _UltimoPrecioOc, string _CodigoOriginal, int _TiempoUtilMeses, string _Modelo, string _Marca, string _Estado, DateTime _FechaCreacion, int _IdUsuarioCreacion, DateTime _FechaModificacion, int _IdUsuarioModificacion)
      {
          this._IdArticuloPre = _IdArticuloPre;
          this._CodigoArticulo = _CodigoArticulo;
          this._IdUnidadMedida = _IdUnidadMedida;
          this._Descripcion = _Descripcion;
          this._Codigo = _Codigo;
          this._IdClase = _IdClase;
          this._IdFamilia = _IdFamilia;
          this._IdProyecto = _IdProyecto;
          this._UltimoPrecioOc = _UltimoPrecioOc;
          this._CodigoOriginal = _CodigoOriginal;
          this._TiempoUtilMeses = _TiempoUtilMeses;
          this._Modelo = _Modelo;
          this._Marca = _Marca;
          this._Estado = _Estado;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaModificacion = _FechaModificacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
      }

      //Get y Set
      public int IdArticuloPre
      {
          get { return _IdArticuloPre; }
          set { _IdArticuloPre = value; }
      }
      public string CodigoArticulo
      {
          get { return _CodigoArticulo; }
          set { _CodigoArticulo = value; }
      }
      public int IdUnidadMedida
      {
          get { return _IdUnidadMedida; }
          set { _IdUnidadMedida = value; }
      }
      public string Descripcion
      {
          get { return _Descripcion; }
          set { _Descripcion = value; }
      }
      public string Codigo
      {
          get { return _Codigo; }
          set { _Codigo = value; }
      }
      public int IdClase
      {
          get { return _IdClase; }
          set { _IdClase = value; }
      }
      public int IdFamilia
      {
          get { return _IdFamilia; }
          set { _IdFamilia = value; }
      }
      public int IdProyecto
      {
          get { return _IdProyecto; }
          set { _IdProyecto = value; }
      }
      public Decimal UltimoPrecioOc
      {
          get { return _UltimoPrecioOc; }
          set { _UltimoPrecioOc = value; }
      }
      public string CodigoOriginal
      {
          get { return _CodigoOriginal; }
          set { _CodigoOriginal = value; }
      }
      public int TiempoUtilMeses
      {
          get { return _TiempoUtilMeses; }
          set { _TiempoUtilMeses = value; }
      }
      public string Modelo
      {
          get { return _Modelo; }
          set { _Modelo = value; }
      }
      public string Marca
      {
          get { return _Marca; }
          set { _Marca = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
      public DateTime FechaCreacion
      {
          get { return _FechaCreacion; }
          set { _FechaCreacion = value; }
      }
      public int IdUsuarioCreacion
      {
          get { return _IdUsuarioCreacion; }
          set { _IdUsuarioCreacion = value; }
      }
      public DateTime FechaModificacion
      {
          get { return _FechaModificacion; }
          set { _FechaModificacion = value; }
      }
      public int IdUsuarioModificacion
      {
          get { return _IdUsuarioModificacion; }
          set { _IdUsuarioModificacion = value; }
      }

      public string NombreClase
      {
          get { return _NombreClase; }
          set { _NombreClase = value; }
      }

      public string NombreFamilia
      {
          get { return _NombreFamilia; }
          set { _NombreFamilia = value; }
      }

      public string NombreProyecto
      {
          get { return _NombreProyecto; }
          set { _NombreProyecto = value; }
      }

      public string NombreUnidadMedida
      {
          get { return _NombreUnidadMedida; }
          set { _NombreUnidadMedida = value; }
      }

        public Boolean EstadoBool
        {
            get
            {
                if (_Estado == "1")
                    return true;
                else
                    return false;
            }
        }

        public string Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }

        public string Lote
        {
            get { return _Lote; }
            set { _Lote = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        public string ObservacionesAlmacenamiento
        {
            get { return _ObservacionesAlmacenamiento; }
            set { _ObservacionesAlmacenamiento = value; }
        }

        public int IdArticulo
        {
            get { return _IdArticulo; }
            set { _IdArticulo = value; }
        }

  }
}
