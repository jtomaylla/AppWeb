using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class RecepcionDTO
  {

      //Propiedades
      private int _IdRecepcion;
      private int _IdProveedor;
      private DateTime _FechaRecepcion;
      private string _NumeroRecibo;
      private string _NumeroFactura;
      private string _Anotaciones;
      private int _IdOrdenCompra;
      private string _TipoRecepcion;
      private int _IdProyecto;
      private int _IdSede;

      private DateTime _FechaCreacion;
      private int _IdUsuarioCreacion;
      private DateTime _FechaModificacion;
      private int _IdUsuarioModificacion;

      private string _RazonSocial;
      private string _NombreProyecto;

      //Constructor
      public RecepcionDTO() { }

      public RecepcionDTO(int _IdRecepcion, int _IdProveedor, DateTime _FechaRecepcion, string _NumeroRecibo, int _IdOrdenCompra, string _Anotaciones, DateTime _FechaCreacion, int _IdUsuarioCreacion, DateTime _FechaModificacion, int _IdUsuarioModificacion )
      {
          this._IdRecepcion = _IdRecepcion;
          this._IdProveedor = _IdProveedor;
          this._FechaRecepcion = _FechaRecepcion;
          this._NumeroRecibo = _NumeroRecibo;
          this._IdOrdenCompra = _IdOrdenCompra;
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

      public int IdProveedor
      {
          get { return _IdProveedor; }
          set { _IdProveedor = value; }
      }
      
      public DateTime FechaRecepcion
      {
          get { return _FechaRecepcion; }
          set { _FechaRecepcion = value; }
      }
      
      public string NumeroRecibo
      {
          get { return _NumeroRecibo; }
          set { _NumeroRecibo = value; }
      }

      public string NumeroFactura
      {
          get { return _NumeroFactura; }
          set { _NumeroFactura = value; }
      }

      public string Anotaciones
      {
          get { return _Anotaciones; }
          set { _Anotaciones = value; }
      }

      public int IdOrdenCompra
      {
          get { return _IdOrdenCompra; }
          set { _IdOrdenCompra = value; }
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

      public string RazonSocial
      {
          get { return _RazonSocial; }
          set { _RazonSocial = value; }
      }

      public string NombreProyecto
      {
          get { return _NombreProyecto; }
          set { _NombreProyecto = value; }
      }

      public string TipoRecepcion
      {
          get { return _TipoRecepcion; }
          set { _TipoRecepcion = value; }
      }

      public int IdProyecto
      {
          get { return _IdProyecto; }
          set { _IdProyecto = value; }
      }
      public int IdSede
      {
          get { return _IdSede; }
          set { _IdSede = value; }
      }


  }
}
