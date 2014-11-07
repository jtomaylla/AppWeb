using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class PedidoDetalleDTO
  {

      //Propiedades
      private int _IdPedidoDetalle;
      private int _IdPedido;
      private int _IdTipoPedido;
      private int _IdTipoArticulo;
      private int _IdArticuloInventario;
      private int _NumeroLinea;
      private string _DescripcionLinea;
      private int _IdUnidadMedida;
      private Decimal   _Cantidad;
      private Decimal _PrecioReferencial;
      private Decimal _Importe;
      private DateTime _FechaNecesidad;
      private int _IdProveedor;
      private string _Cancelado;
      private int _IdUsuarioCreacion;
      private DateTime _FechaCreacion;
      private int _IdUsuarioModificacion;
      private DateTime _FechaModificacion;
      private string _EstadoPedido;
      private Decimal _CantidadDespacho;

      private string _Marca;
      private string _Modelo;

      //Extendido
      private string _CodigoArticulo;
      private string _NombreUnidadMedida;
      private string _OrdenCompra;

      //Constructor

      public PedidoDetalleDTO() { }

      public PedidoDetalleDTO(int _IdPedidoDetalle, int _IdPedido, int _IdTipoPedido, int _IdTipoArticulo, int _IdArticuloInventario, int _NumeroLinea, string _DescripcionLinea, int _IdUnidadMedida, Decimal _Cantidad, Decimal _PrecioReferencial, Decimal _Importe, DateTime _FechaNecesidad, int _IdProveedor, string _Cancelado, int _IdUsuarioCreacion, DateTime _FechaCreacion, int _IdUsuarioModificacion, DateTime _FechaModificacion )
      {
          this._IdPedidoDetalle = _IdPedidoDetalle;
          this._IdPedido = _IdPedido;
          this._IdTipoPedido = _IdTipoPedido;
          this._IdTipoArticulo = _IdTipoArticulo;
          this._IdArticuloInventario = _IdArticuloInventario;
          this._NumeroLinea = _NumeroLinea;
          this._DescripcionLinea = _DescripcionLinea;
          this._IdUnidadMedida = _IdUnidadMedida;
          this._Cantidad = _Cantidad;
          this._PrecioReferencial = _PrecioReferencial;
          this._Importe = _Importe;
          this._FechaNecesidad = _FechaNecesidad;
          this._IdProveedor = _IdProveedor;
          this._Cancelado = _Cancelado;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
          this._FechaModificacion = _FechaModificacion;
      }

      //Get y Set

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

      public int IdPedidoDetalle
      {
          get { return _IdPedidoDetalle; }
          set { _IdPedidoDetalle = value; }
      }
      public int IdPedido
      {
          get { return _IdPedido; }
          set { _IdPedido = value; }
      }
      public int IdTipoPedido
      {
          get { return _IdTipoPedido; }
          set { _IdTipoPedido = value; }
      }
      public int IdTipoArticulo
      {
          get { return _IdTipoArticulo; }
          set { _IdTipoArticulo = value; }
      }
      public int IdArticuloInventario
      {
          get { return _IdArticuloInventario; }
          set { _IdArticuloInventario = value; }
      }
      public int NumeroLinea
      {
          get { return _NumeroLinea; }
          set { _NumeroLinea = value; }
      }
      public string DescripcionLinea
      {
          get { return _DescripcionLinea; }
          set { _DescripcionLinea = value; }
      }
      public int IdUnidadMedida
      {
          get { return _IdUnidadMedida; }
          set { _IdUnidadMedida = value; }
      }
      public Decimal Cantidad
      {
          get { return _Cantidad; }
          set { _Cantidad = value; }
      }
      public Decimal PrecioReferencial
      {
          get { return _PrecioReferencial; }
          set { _PrecioReferencial = value; }
      }
      public Decimal Importe
      {
          get { return _Importe; }
          set { _Importe = value; }
      }
      public DateTime FechaNecesidad
      {
          get { return _FechaNecesidad; }
          set { _FechaNecesidad = value; }
      }
      public int IdProveedor
      {
          get { return _IdProveedor; }
          set { _IdProveedor = value; }
      }
      public string Cancelado
      {
          get { return _Cancelado; }
          set { _Cancelado = value; }
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

      public string CodigoArticulo
      {
          get { return _CodigoArticulo; }
          set { _CodigoArticulo = value; }
      }

      public string NombreUnidadMedida
      {
          get { return _NombreUnidadMedida; }
          set { _NombreUnidadMedida = value; }
      }

      public string OrdenCompra
      {
          get { return _OrdenCompra; }
          set { _OrdenCompra = value; }
      }

      public string EstadoPedido
      {
          get { return _EstadoPedido; }
          set { _EstadoPedido = value; }
      }

      public Decimal CantidadDespacho
      {
          get { return _CantidadDespacho; }
          set { _CantidadDespacho = value; }
      }
  
      
  }
}
