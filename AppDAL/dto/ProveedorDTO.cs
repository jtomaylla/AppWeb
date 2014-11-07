using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
    public class ProveedorDTO:IEquatable<ProveedorDTO>
    {
        private int _IdProveedor;
        private string _RazonSocial;
        private string _Ruc;
        private string _TipoPersona;
        private string _NombreTipoPersona;
        private string _Direccion;
        private string _Email;
        private string _Telefono;
        private string _Contacto;
        private string _Estado;
        private DateTime _FechaCreacion;
        private string _UsuarioCreacion;
        private DateTime _FechaModificacion;
        private string _UsuarioModificacion;

        public ProveedorDTO(){}

        public ProveedorDTO(int _IdProveedor, string _RazonSocial, string _Ruc, string _TipoPersona, string _NombreTipoPersona, string _Direccion, string _Email, string _Telefono, string _Contacto, string _Estado, DateTime _FechaCreacion, string _UsuarioCreacion, DateTime _FechaModificacion, string _UsuarioModificacion) 
        {
            this._IdProveedor = _IdProveedor;
            this._RazonSocial = _RazonSocial;
            this._Ruc = _Ruc;
            this._TipoPersona = _TipoPersona;
            this._NombreTipoPersona = _NombreTipoPersona;
            this._Direccion = _Direccion;
            this._Email = _Email;
            this._Telefono = _Telefono;
            this._Contacto = _Contacto;
            this._Estado = _Estado;
            this._FechaCreacion = _FechaCreacion;
            this._UsuarioCreacion = _UsuarioCreacion;
            this._FechaModificacion = _FechaModificacion;
            this._UsuarioModificacion = _UsuarioModificacion;
        }

        public int IdProveedor
        {
            get { return _IdProveedor; }
            set { _IdProveedor = value; }
        }

        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        public string Ruc
        {
            get { return _Ruc; }
            set { _Ruc = value; }
        }

        public string TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

        public string NombreTipoPersona
        {
            get { return _NombreTipoPersona; }
            set { _NombreTipoPersona = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
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

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
        public string UsuarioCreacion
        {
            get { return _UsuarioCreacion; }
            set { _UsuarioCreacion = value; }
        }
        public DateTime FechaModificacion
        {
            get { return _FechaModificacion; }
            set { _FechaModificacion = value; }
        }
        public string UsuarioModificacion
        {
            get { return _UsuarioModificacion; }
            set { _UsuarioModificacion = value; }
        }

        /*para la comparacion y funcione el metodo distinct*/

        public bool Equals(ProveedorDTO other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;

            return this.IdProveedor.Equals(other.IdProveedor);
        }

        public override int GetHashCode()
        {
            int hashDescription = this.IdProveedor == null ? 0 : this.IdProveedor.GetHashCode();

            return hashDescription;
        }
    }
}
