using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class InvUnidadMedidaDTO
  {

      //Propiedades
      private int _IdUnidadMedida;
      private string _NombreUnidadMedida;
      private string _NombreCorto;
      private string _Estado;

      //Constructor

      public InvUnidadMedidaDTO() { }

      public InvUnidadMedidaDTO(int _IdUnidadMedida, string _NombreUnidadMedida, string _NombreCorto, string _Estado )
      {
          this._IdUnidadMedida = _IdUnidadMedida;
          this._NombreUnidadMedida = _NombreUnidadMedida;
          this._NombreCorto = _NombreCorto;
          this._Estado = _Estado;
      }

      //Get y Set
      public int IdUnidadMedida
      {
          get { return _IdUnidadMedida; }
          set { _IdUnidadMedida = value; }
      }
      public string NombreUnidadMedida
      {
          get { return _NombreUnidadMedida; }
          set { _NombreUnidadMedida = value; }
      }
      public string NombreCorto
      {
          get { return _NombreCorto; }
          set { _NombreCorto = value; }
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
