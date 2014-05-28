using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class CotizacionLineaProveedorDTO
  {

      //Propiedades
      private int _IdCotizacion;
      private int _IdCotizacionLinea;
      private int _IdProveedor;
      private Decimal _Precio;
      private Decimal _Cantidad;
      private Decimal _Importe;
      private DateTime _FechaPactada;
      private string _FlagIgv;
      private string _FlagSeleccionado;
      private string _Anotaciones;
      private int _IdUsuarioCreacion;
      private DateTime _FechaCreacion;
      private int _IdUsuarioModificacion;
      private DateTime _FechaModificacion;

      private string _RazonSocial;
      private string _Ruc;
      private int _DiasEntrega;

      //Constructor
      public CotizacionLineaProveedorDTO() { }

      public CotizacionLineaProveedorDTO(int _IdCotizacion, int _IdCotizacionLinea, int _IdProveedor, Decimal _Precio, Decimal _Cantidad, Decimal _Importe, DateTime _FechaPactada, string _FlagIgv, string _FlagSeleccionado, string _Anotaciones, int _IdUsuarioCreacion, DateTime _FechaCreacion, int _IdUsuarioModificacion, DateTime _FechaModificacion)
      {
          this._IdCotizacion = _IdCotizacion;
          this._IdCotizacionLinea = _IdCotizacionLinea;
          this._IdProveedor = _IdProveedor;
          this._Precio = _Precio;
          this._Cantidad = _Cantidad;
          this._Importe = _Importe;
          this._FechaPactada = _FechaPactada;
          this._FlagIgv = _FlagIgv;
          this._FlagSeleccionado = _FlagSeleccionado;
          this._Anotaciones = _Anotaciones;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
          this._FechaModificacion = _FechaModificacion;
      }

      //Get y Set
      public int IdCotizacion
      {
          get { return _IdCotizacion; }
          set { _IdCotizacion = value; }
      }
      public int IdCotizacionLinea
      {
          get { return _IdCotizacionLinea; }
          set { _IdCotizacionLinea = value; }
      }
      public int IdProveedor
      {
          get { return _IdProveedor; }
          set { _IdProveedor = value; }
      }
      public Decimal Precio
      {
          get { return _Precio; }
          set { _Precio = value; }
      }
      public Decimal Cantidad
      {
          get { return _Cantidad; }
          set { _Cantidad = value; }
      }
      public Decimal Importe
      {
          get { return _Importe; }
          set { _Importe = value; }
      }
      public DateTime FechaPactada
      {
          get { return _FechaPactada; }
          set { _FechaPactada = value; }
      }
      public string FlagIgv
      {
          get { return _FlagIgv; }
          set { _FlagIgv = value; }
      }
      public string FlagSeleccionado
      {
          get { return _FlagSeleccionado; }
          set { _FlagSeleccionado = value; }
      }
      public string Anotaciones
      {
          get { return _Anotaciones; }
          set { _Anotaciones = value; }
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

      public string RazonSocial
      {
          get { return _RazonSocial; }
          set { _RazonSocial = value; }
      }

      public string Ruc
      {
          get { return _Ruc; }
          set { _Ruc = value; }
      }

      public int DiasEntrega
      {
          get { return _DiasEntrega; }
          set { _DiasEntrega = value; }
      }

      public Boolean FlagIgvBool
      {
          get
          {
              if (_FlagIgv == "1")
                  return true;
              else
                  return false;
          }
      }
  }
}
