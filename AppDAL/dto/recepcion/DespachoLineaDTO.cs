using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class DespachoLineaDTO
  {

      //Propiedades
      private int _IdDespachoLinea;
      private int _IdDespacho;
      private int _NumeroLinea;
      private int _IdArticulo;
      private int _IdOrigen;
      private int _IdOrigenLinea;
      private Decimal _CantidadDespacho;
      private Decimal _PrecioUnitario;
      private int _IdUsuarioCreacion;
      private DateTime _FechaCreacion;
      private int _IdUsuarioModificacion;
      private DateTime _FechaModificacion;

      //Constructor

      public DespachoLineaDTO() { }

      public DespachoLineaDTO(int _IdDespachoLinea, int _IdDespacho, int _NumeroLinea, int _IdArticulo, int _IdOrigen, int _IdOrigenLinea, Decimal _CantidadDespacho, Decimal _PrecioUnitario, int _IdUsuarioCreacion, DateTime _FechaCreacion, int _IdUsuarioModificacion, DateTime _FechaModificacion )
      {
          this._IdDespachoLinea = _IdDespachoLinea;
          this._IdDespacho = _IdDespacho;
          this._NumeroLinea = _NumeroLinea;
          this._IdArticulo = _IdArticulo;
          this._IdOrigen = _IdOrigen;
          this._IdOrigenLinea = _IdOrigenLinea;
          this._CantidadDespacho = _CantidadDespacho;
          this._PrecioUnitario = _PrecioUnitario;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
          this._FechaModificacion = _FechaModificacion;
      }

      //Get y Set
      public int IdDespachoLinea
      {
          get { return _IdDespachoLinea; }
          set { _IdDespachoLinea = value; }
      }
      public int IdDespacho
      {
          get { return _IdDespacho; }
          set { _IdDespacho = value; }
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
      public int IdOrigen
      {
          get { return _IdOrigen; }
          set { _IdOrigen = value; }
      }
      public int IdOrigenLinea
      {
          get { return _IdOrigenLinea; }
          set { _IdOrigenLinea = value; }
      }
      public Decimal CantidadDespacho
      {
          get { return _CantidadDespacho; }
          set { _CantidadDespacho = value; }
      }
      public Decimal PrecioUnitario
      {
          get { return _PrecioUnitario; }
          set { _PrecioUnitario = value; }
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
  }
}
