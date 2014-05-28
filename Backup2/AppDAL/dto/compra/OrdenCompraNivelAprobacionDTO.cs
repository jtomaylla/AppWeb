using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class OrdenCompraNivelAprobacionDTO
  {

      //Propiedades
      private int _IdNivelAprobacion;
      private string _NombreNivelAprobacion;
      private Decimal _LimiteInferior;
      private Decimal _LimiteSuperior;
      private int _IdUsuarioAprobacion;
      private string _CodMoneda;
      private string _Estado;

      //Constructor

      public OrdenCompraNivelAprobacionDTO() { }

      public OrdenCompraNivelAprobacionDTO(int _IdNivelAprobacion, string _NombreNivelAprobacion, Decimal _LimiteInferior, Decimal _LimiteSuperior, int _IdUsuarioAprobacion )
      {
          this._IdNivelAprobacion = _IdNivelAprobacion;
          this._NombreNivelAprobacion = _NombreNivelAprobacion;
          this._LimiteInferior = _LimiteInferior;
          this._LimiteSuperior = _LimiteSuperior;
          this._IdUsuarioAprobacion = _IdUsuarioAprobacion;
      }

      //Get y Set
      public int IdNivelAprobacion
      {
          get { return _IdNivelAprobacion; }
          set { _IdNivelAprobacion = value; }
      }
      public string NombreNivelAprobacion
      {
          get { return _NombreNivelAprobacion; }
          set { _NombreNivelAprobacion = value; }
      }
      public Decimal LimiteInferior
      {
          get { return _LimiteInferior; }
          set { _LimiteInferior = value; }
      }
      public Decimal LimiteSuperior
      {
          get { return _LimiteSuperior; }
          set { _LimiteSuperior = value; }
      }

      public int IdUsuarioAprobacion
      {
          get { return _IdUsuarioAprobacion; }
          set { _IdUsuarioAprobacion = value; }
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
