using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class CotizacionDTO
  {

      //Propiedades
      private int _IdCotizacion;
      private int _IdPedido;
      private DateTime _FechaCotizacion;
      private string _DescripcionCotizacion;
      private string _CodMoneda;
      private string _Estado;
      private int _IdUsuarioCreacion;
      private DateTime _FechaCreacion;
      private int _IdUsuarioModificacion;
      private DateTime _FechaModificacion;

      private string _NombreEstado;
      private string _NombreMoneda;
      private string _NombreUsuarioSolicitante;
      private string _NombreProyecto;
      private string _NombreSede;
      

      //Constructor

      public CotizacionDTO() { }

      public CotizacionDTO(int _IdCotizacion, int _IdPedido, DateTime _FechaCotizacion, string _DescripcionCotizacion, string _CodMoneda, string _Estado, int _IdUsuarioCreacion, DateTime _FechaCreacion, int _IdUsuarioModificacion, DateTime _FechaModificacion )
      {
          this._IdCotizacion = _IdCotizacion;
          this._IdPedido = _IdPedido;
          this._FechaCotizacion = _FechaCotizacion;
          this._DescripcionCotizacion = _DescripcionCotizacion;
          this._CodMoneda = _CodMoneda;
          this._Estado = _Estado;
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
      public int IdPedido
      {
          get { return _IdPedido; }
          set { _IdPedido = value; }
      }
      public DateTime FechaCotizacion
      {
          get { return _FechaCotizacion; }
          set { _FechaCotizacion = value; }
      }
      public string DescripcionCotizacion
      {
          get { return _DescripcionCotizacion; }
          set { _DescripcionCotizacion = value; }
      }
      public string CodMoneda
      {
          get { return _CodMoneda; }
          set { _CodMoneda = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
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
      public string NombreEstado
      {
          get { return _NombreEstado; }
          set { _NombreEstado = value; }
      }

      public string NombreMoneda
      {
          get { return _NombreMoneda; }
          set { _NombreMoneda = value; }
      }

      public string NombreUsuarioSolicitante
      {
          get { return _NombreUsuarioSolicitante; }
          set { _NombreUsuarioSolicitante = value; }
      }

      public string NombreSede
      {
          get { return _NombreSede; }
          set { _NombreSede = value; }
      }

      public string NombreProyecto
      {
          get { return _NombreProyecto; }
          set { _NombreProyecto = value; }
      }



  }
}
