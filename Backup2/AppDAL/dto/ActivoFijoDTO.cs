using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class ActivoFijoDTO
  {

      //Propiedades
      private int _IdActivoFijo;
      private string _Codigo;
      private string _Observacion1;
      private DateTime _FechaBaja;
      private string _Descripcion;
      private string _Marca;
      private string _Modelo;
      private string _Serie;
      private string _Estado;
      private string _Factura;
      private DateTime _FechaFactura;
      private int _IdProveedor;
      private string _Proveedor;
      private string _RucProveedor;
      private Decimal _PrecioSoles;
      private Decimal _PrecioDolares;
      private string _Observacion2;
      private string _LocalOrigen;
      private string _Ubicacion;
      private string _AreaProyecto;
      private string _UsuarioAsignacion;
      private int _IdUsuarioCreacion;
      private DateTime _FechaCreacion;
      private int _IdUsuarioModificacion;
      private DateTime _FechaModificacion;

      //Constructor

      public ActivoFijoDTO() { }

      public ActivoFijoDTO(int _IdActivoFijo, string _Codigo, string _Observacion1, DateTime _FechaBaja, string _Descripcion, string _Marca, string _Modelo, string _Serie, string _Estado, string _Factura, DateTime _FechaFactura, int _IdProveedor, string _Proveedor, string _RucProveedor, Decimal _PrecioSoles, Decimal _PrecioDolares, string _Observacion2, string _LocalOrigen, string _Ubicacion, string _AreaProyecto, string _UsuarioAsignacion, int _IdUsuarioCreacion, DateTime _FechaCreacion, int _IdUsuarioModificacion, DateTime _FechaModificacion)
      {
          this._IdActivoFijo = _IdActivoFijo;
          this._Codigo = _Codigo;
          this._Observacion1 = _Observacion1;
          this._FechaBaja = _FechaBaja;
          this._Descripcion = _Descripcion;
          this._Marca = _Marca;
          this._Modelo = _Modelo;
          this._Serie = _Serie;
          this._Estado = _Estado;
          this._Factura = _Factura;
          this._FechaFactura = _FechaFactura;
          this._IdProveedor = _IdProveedor;
          this._Proveedor = _Proveedor;
          this._RucProveedor = _RucProveedor;
          this._PrecioSoles = _PrecioSoles;
          this._PrecioDolares = _PrecioDolares;
          this._Observacion2 = _Observacion2;
          this._LocalOrigen = _LocalOrigen;
          this._Ubicacion = _Ubicacion;
          this._AreaProyecto = _AreaProyecto;
          this._UsuarioAsignacion = _UsuarioAsignacion;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
          this._FechaModificacion = _FechaModificacion;
      }

      //Get y Set
      public int IdActivoFijo
      {
          get { return _IdActivoFijo; }
          set { _IdActivoFijo = value; }
      }
      public string Codigo
      {
          get { return _Codigo; }
          set { _Codigo = value; }
      }
      public string Observacion1
      {
          get { return _Observacion1; }
          set { _Observacion1 = value; }
      }
      public DateTime FechaBaja
      {
          get { return _FechaBaja; }
          set { _FechaBaja = value; }
      }
      public string Descripcion
      {
          get { return _Descripcion; }
          set { _Descripcion = value; }
      }
      public string Marca
      {
          get { return _Marca; }
          set { _Marca = value; }
      }
      public string Modelo
      {
          get { return _Modelo; }
          set { _Modelo = value; }
      }
      public string Serie
      {
          get { return _Serie; }
          set { _Serie = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
      public string Factura
      {
          get { return _Factura; }
          set { _Factura = value; }
      }
      public DateTime FechaFactura
      {
          get { return _FechaFactura; }
          set { _FechaFactura = value; }
      }
      public int IdProveedor
      {
          get { return _IdProveedor; }
          set { _IdProveedor = value; }
      }
      public string Proveedor
      {
          get { return _Proveedor; }
          set { _Proveedor = value; }
      }
      public string RucProveedor
      {
          get { return _RucProveedor; }
          set { _RucProveedor = value; }
      }
      public Decimal PrecioSoles
      {
          get { return _PrecioSoles; }
          set { _PrecioSoles = value; }
      }
      public Decimal PrecioDolares
      {
          get { return _PrecioDolares; }
          set { _PrecioDolares = value; }
      }
      public string Observacion2
      {
          get { return _Observacion2; }
          set { _Observacion2 = value; }
      }
      public string LocalOrigen
      {
          get { return _LocalOrigen; }
          set { _LocalOrigen = value; }
      }
      public string Ubicacion
      {
          get { return _Ubicacion; }
          set { _Ubicacion = value; }
      }
      public string AreaProyecto
      {
          get { return _AreaProyecto; }
          set { _AreaProyecto = value; }
      }
      public string UsuarioAsignacion
      {
          get { return _UsuarioAsignacion; }
          set { _UsuarioAsignacion = value; }
      }
      public int IdUsuarioCreacion
      {
          get { return _IdUsuarioCreacion; }
          set { _IdUsuarioCreacion = value; }
      }
      public DateTime FechaCreacion
      {
          get { return _FechaCreacion; }
          set { _FechaCreacion = value; }
      }
      public int IdUsuarioModificacion
      {
          get { return _IdUsuarioModificacion; }
          set { _IdUsuarioModificacion = value; }
      }
      public DateTime FechaModificacion
      {
          get { return _FechaModificacion; }
          set { _FechaModificacion = value; }
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
  }
}
