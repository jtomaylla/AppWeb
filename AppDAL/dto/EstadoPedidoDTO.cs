using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class EstadoPedidoDTO
  {

      //Propiedades
      private string _TipoEstado;
      private string _Estado;
      private string _NombreEstado;
      //Constructor

      public EstadoPedidoDTO() { }

      public EstadoPedidoDTO(string _TipoEstado, string _Estado, string _NombreEstado)
      {
          this._TipoEstado = _TipoEstado;
          this._Estado = _Estado; 
          this._NombreEstado = _NombreEstado;

      }

      //Get y Set
      public string TipoEstado
      {
          get { return _TipoEstado; }
          set { _TipoEstado = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
      public string NombreEstado
      {
          get { return _NombreEstado; }
          set { _NombreEstado = value; }
      }
      

  }
}
