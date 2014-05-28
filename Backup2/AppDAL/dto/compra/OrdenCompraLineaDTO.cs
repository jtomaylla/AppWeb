using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class OrdenCompraLineaDTO
  {

      //Propiedades
      private int _IdOrdenCompra;
      private int _IdOrdenCompraLinea;
      private int _NumeroLinea;
      private int _IdArticulo;
      private int _IdUnidadMedida;
      private string _DescripcionLinea;
      private Decimal _Precio;
      private Decimal _Cantidad;
      private Decimal _Importe;
      private int _IdCotizacionLinea;
      private int _IdPedidoLinea;
      private DateTime _FechaPactada;
      private Decimal _CantidadRecibida;
      private string _EstadoControl;

      private DateTime _FechaCreacion;
      private int _IdUsuarioCreacion;
      private DateTime _FechaModificacion;
      private int _IdUsuarioModificacion;

	  //Extendido
      private string _CodigoArticulo;
      private string _DescripcionArticulo;
      private string _NombreUnidadMedida;

      //Constructor

      public OrdenCompraLineaDTO() { }

      public OrdenCompraLineaDTO(int _IdOrdenCompra, int _IdOrdenCompraLinea, int _NumeroLinea, int _IdArticulo, int _IdUnidadMedida, string _DescripcionLinea, Decimal _Precio, Decimal _Cantidad, Decimal _Importe, int _IdCotizacionLinea, int _IdPedidoLinea, DateTime _FechaPactada, DateTime _FechaCreacion, int _IdUsuarioCreacion, DateTime _FechaModificacion, int _IdUsuarioModificacion )
      {
          this._IdOrdenCompra = _IdOrdenCompra;
          this._IdOrdenCompraLinea = _IdOrdenCompraLinea;
          this._NumeroLinea = _NumeroLinea;
          this._IdArticulo = _IdArticulo;
          this._IdUnidadMedida = _IdUnidadMedida;
          this._DescripcionLinea = _DescripcionLinea;
          this._Precio = _Precio;
          this._Cantidad = _Cantidad;
          this._Importe = _Importe;
          this._IdCotizacionLinea = _IdCotizacionLinea;
          this._IdPedidoLinea = _IdPedidoLinea;
          this._FechaPactada = _FechaPactada;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaModificacion = _FechaModificacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
      }

      //Get y Set
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
      public int NumeroLinea
      {
          get { return _NumeroLinea; }
          set { _NumeroLinea = value; }
      }
      public int IdArticulo
      {
          get { return _IdArticulo; }
          set { _IdArticulo = value; }
      }
      public int IdUnidadMedida
      {
          get { return _IdUnidadMedida; }
          set { _IdUnidadMedida = value; }
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
      public DateTime FechaPactada
      {
          get { return _FechaPactada; }
          set { _FechaPactada = value; }
      }

      public Decimal CantidadRecibida
      {
          get { return _CantidadRecibida; }
          set { _CantidadRecibida = value; }
      }

      public string EstadoControl
      {
          get { return _EstadoControl; }
          set { _EstadoControl = value; }
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

      //Extendido
      public string CodigoArticulo
      {
          get { return _CodigoArticulo; }
          set { _CodigoArticulo = value; }
      }

      public string DescripcionArticulo
      {
          get { return _DescripcionArticulo; }
          set { _DescripcionArticulo = value; }
      }

      public string NombreUnidadMedida
      {
          get { return _NombreUnidadMedida; }
          set { _NombreUnidadMedida = value; }
      }
      
  }
}
