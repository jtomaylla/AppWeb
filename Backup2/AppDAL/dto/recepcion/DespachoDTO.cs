using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class DespachoDTO
  {

      //Propiedades
      private int _IdDespacho;
      private string _TipoOrigen;
      private int _IdOrigen;
      private DateTime _FechaDespacho;
      private string _Observaciones;
      private string _Estado;
      private int _IdGuiaRemision;
      private int _IdUsuarioCreacion;
      private DateTime _FechaCreacion;
      private int _IdUsuarioModificacion;
      private DateTime _FechaModificacion;

      //Constructor

      public DespachoDTO() { }

      public DespachoDTO(int _IdDespacho, string _TipoOrigen, int _IdOrigen, DateTime _FechaDespacho, string _Observaciones, string _Estado, int _IdGuiaRemision, int _IdUsuarioCreacion, DateTime _FechaCreacion, int _IdUsuarioModificacion, DateTime _FechaModificacion)
      {
          this._IdDespacho = _IdDespacho;
          this._TipoOrigen = _TipoOrigen;
          this._IdOrigen = _IdOrigen;
          this._FechaDespacho = _FechaDespacho;
          this._Observaciones = _Observaciones;
          this._Estado = _Estado;
          this._IdGuiaRemision = _IdGuiaRemision;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
          this._FechaModificacion = _FechaModificacion;
      }

      //Get y Set
      public int IdDespacho
      {
          get { return _IdDespacho; }
          set { _IdDespacho = value; }
      }
      public string TipoOrigen
      {
          get { return _TipoOrigen; }
          set { _TipoOrigen = value; }
      }
      public int IdOrigen
      {
          get { return _IdOrigen; }
          set { _IdOrigen = value; }
      }
      public DateTime FechaDespacho
      {
          get { return _FechaDespacho; }
          set { _FechaDespacho = value; }
      }
      public string Observaciones
      {
          get { return _Observaciones; }
          set { _Observaciones = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
      public int IdGuiaRemision
      {
          get { return _IdGuiaRemision; }
          set { _IdGuiaRemision = value; }
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
