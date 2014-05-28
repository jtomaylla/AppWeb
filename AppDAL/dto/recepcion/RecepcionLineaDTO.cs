using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class RecepcionLineaDTO
  {

      //Propiedades
      private int _IdRecepcion;
      private int _IdRecepcionLinea;
      private int _IdOrdenCompra;
      private int _IdOrdenCompraLinea;
      private int _IdArticulo;
      private Decimal _CantidadRecepcionada;
      private string _Anotaciones;
      private string _Estado;
      private DateTime _FechaCreacion;
      private int _IdUsuarioCreacion;
      private DateTime _FechaModificacion;
      private int _IdUsuarioModificacion;

      private DateTime _FechaRecepcion;
      private string _CodigoArticulo;
      private string _NombreArticulo;
      private string _RazonSocial;
      private int _NumeroLineaOC;

      
      //Constructor

      public RecepcionLineaDTO() { }

      public RecepcionLineaDTO(int _IdRecepcion, int _IdRecepcionLinea, int _IdOrdenCompra, int _IdOrdenCompraLinea, int _IdArticulo, Decimal _CantidadRecepcionada, string _Anotaciones, DateTime _FechaCreacion, int _IdUsuarioCreacion, DateTime _FechaModificacion, int _IdUsuarioModificacion )
      {
          this._IdRecepcion = _IdRecepcion;
          this._IdRecepcionLinea = _IdRecepcionLinea;
          this._IdOrdenCompra = _IdOrdenCompra;
          this._IdOrdenCompraLinea = _IdOrdenCompraLinea;
          this._IdArticulo = _IdArticulo;
          this._CantidadRecepcionada = _CantidadRecepcionada;
          this._Anotaciones = _Anotaciones;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaModificacion = _FechaModificacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
      }

      //Get y Set
      public int IdRecepcion
      {
          get { return _IdRecepcion; }
          set { _IdRecepcion = value; }
      }
      public int IdRecepcionLinea
      {
          get { return _IdRecepcionLinea; }
          set { _IdRecepcionLinea = value; }
      }
      public int IdOrdenCompra
      {
          get { return _IdOrdenCompra; }
          set { _IdOrdenCompra = value; }
      }
      public int IdOrdenCompraLinea
      {
          get { return _IdOrdenCompraLinea; }
          set { _IdOrdenCompraLinea = value; }
      }
      public int IdArticulo
      {
          get { return _IdArticulo; }
          set { _IdArticulo = value; }
      }
      public Decimal CantidadRecepcionada
      {
          get { return _CantidadRecepcionada; }
          set { _CantidadRecepcionada = value; }
      }
      public string Anotaciones
      {
          get { return _Anotaciones; }
          set { _Anotaciones = value; }
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

       public DateTime FechaRecepcion
      {
          get { return _FechaRecepcion;  }
          set { _FechaRecepcion= value; }
      }

      public string CodigoArticulo
      {
          get { return _CodigoArticulo;}
          set { _CodigoArticulo = value; }
      }

      public string NombreArticulo
      {
          get { return _NombreArticulo;}
          set { _NombreArticulo = value; }
      }

      public string RazonSocial
      {
          get { return _RazonSocial;}
          set { _RazonSocial = value; }
      }

      public string Estado
      {
          get { return _Estado;  }
          set { _Estado = value; }
      }

      public int NumeroLineaOC
      {
          get { return _NumeroLineaOC; }
          set { _NumeroLineaOC = value; }
      }
  
  }
}
