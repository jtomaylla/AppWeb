using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class CotizacionLineaDTO
  {

      //Propiedades
      private int _IdCotizacion;
      private int _IdCotizacionLinea;
      private int _IdPedidoLinea;
      private int _NumeroLinea;
      private int _IdUnidadMedida;
      private int _IdArticulo;
      private string _DescripcionLinea;
      private Decimal _Precio;
      private Decimal _Cantidad;
      private Decimal _Importe;
      private string _FlagIgv;
      private int _IdProveedorSeleccionado;
      
      private int _IdUsuarioCreacion;
      private DateTime _FechaCreacion;
      private int _IdUsuarioModificacion;
      private DateTime _FechaModificacion;

      private int _DiasEntrega;

      //Extendido
      private string _NombreCortoUnidadMedida;
      private string _CodigoArticulo;
      private string _RazonSocial;

      //Constructor
      public CotizacionLineaDTO() { }

      public CotizacionLineaDTO(int _IdCotizacion, int _IdCotizacionLinea, int _IdPedidoLinea, int _NumeroLinea, int _IdUnidadMedida, int _IdArticulo, string _DescripcionLinea, Decimal _Precio, Decimal _Cantidad, Decimal _Importe, string _FlagIgv, int _IdProveedorSeleccionado, int _IdUsuarioCreacion, DateTime _FechaCreacion, int _IdUsuarioModificacion, DateTime _FechaModificacion )
      {
          this._IdCotizacion = _IdCotizacion;
          this._IdCotizacionLinea = _IdCotizacionLinea;
          this._IdPedidoLinea = _IdPedidoLinea;
          this._NumeroLinea = _NumeroLinea;
          this._IdUnidadMedida = _IdUnidadMedida;
          this._IdArticulo = _IdArticulo;
          this._DescripcionLinea = _DescripcionLinea;
          this._Precio = _Precio;
          this._Cantidad = _Cantidad;
          this._Importe = _Importe;
          this._FlagIgv = _FlagIgv;
          this._IdProveedorSeleccionado = _IdProveedorSeleccionado;
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
      public int IdPedidoLinea
      {
          get { return _IdPedidoLinea; }
          set { _IdPedidoLinea = value; }
      }
      public int NumeroLinea
      {
          get { return _NumeroLinea; }
          set { _NumeroLinea = value; }
      }
      public int IdUnidadMedida
      {
          get { return _IdUnidadMedida; }
          set { _IdUnidadMedida = value; }
      }
      public int IdArticulo
      {
          get { return _IdArticulo; }
          set { _IdArticulo = value; }
      }
      public string DescripcionLinea
      {
          get { return _DescripcionLinea; }
          set { _DescripcionLinea = value; }
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
      public string FlagIgv
      {
          get { return _FlagIgv; }
          set { _FlagIgv = value; }
      }
      
      public int IdProveedorSeleccionado
      {
          get { return _IdProveedorSeleccionado; }
          set { _IdProveedorSeleccionado = value; }
      }

      public int DiasEntrega
      {
          get { return _DiasEntrega; }
          set { _DiasEntrega = value; }
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

      //Extendido
      public string NombreCortoUnidadMedida
      {
          get { return _NombreCortoUnidadMedida; }
          set { _NombreCortoUnidadMedida = value; }
      }

      public string CodigoArticulo
      {
          get { return _CodigoArticulo; }
          set { _CodigoArticulo = value; }
      }

      public string RazonSocial
      {
          get { return _RazonSocial; }
          set { _RazonSocial = value; }
      }

  }
}
