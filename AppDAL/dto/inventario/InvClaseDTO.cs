using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class InvClaseDTO
  {

      //Propiedades
      private int _IdClase;
      private string _CodClase;
      private string _NombreClase;
      private string _Estado;

      //Constructor
      public InvClaseDTO() { }

      public InvClaseDTO(int _IdClase, string _CodClase, string _NombreClase, string _Estado )
      {
          this._IdClase = _IdClase;
          this._CodClase = _CodClase;
          this._NombreClase = _NombreClase;
          this._Estado = _Estado;
      }

      //Get y Set
      public int IdClase
      {
          get { return _IdClase; }
          set { _IdClase = value; }
      }
      public string CodClase
      {
          get { return _CodClase; }
          set { _CodClase = value; }
      }
      public string NombreClase
      {
          get { return _NombreClase; }
          set { _NombreClase = value; }
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
