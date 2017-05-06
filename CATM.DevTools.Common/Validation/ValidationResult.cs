using CATM.DevTools.Common.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATM.DevTools.Common.Validation
{
    public class ValidationResult
    {
        public ValidationResult()
        {
        }

        private string _message;
        private object _data;
        private int _operationCode;

        public ValidationResult(string message, AppNotification.OperationCode? operationCode)
        {
            this._message = message;
            this._data = (object)null;
            this._operationCode = operationCode.HasValue ? operationCode.Value.GetHashCode() : AppNotification.OperationCode.Exito.GetHashCode();
        }

        public ValidationResult(string message, AppNotification.OperationCode? operationCode, object data = null)
        {
            this._message = message;
            this._data = data;
            this._operationCode = operationCode.HasValue ? operationCode.Value.GetHashCode() : AppNotification.OperationCode.Exito.GetHashCode();
        }

        public ValidationResult(AppNotification.OperationCode? operationCode, object data = null)
        {
            this._message = string.Empty;
            this._data = data;
            this._operationCode = operationCode.HasValue ? operationCode.Value.GetHashCode() : AppNotification.OperationCode.Exito.GetHashCode();
        }

        public ValidationResult(Exception ex)
        {
            if (ex is Exceptions.BusinessException)
            {
                this._message = ex.Message;
                this._operationCode = AppNotification.OperationCode.ErrorApp.GetHashCode();
            }
            else if (ex is Exceptions.RepositoryException)
            {
                this._message = "Ocurrió un error en la Base de Datos, por favor intentelo nuevamente. Si el inconveniente persiste comuniquese con el Administrador.";
                this._operationCode = AppNotification.OperationCode.ErrorDataBase.GetHashCode();
                this._data = ex.Message;
            }
            else
            {
                this._message = "Ocurrió un error en la Aplicación, por favor intentelo nuevamente. Si el inconveniente persiste comuniquese con el Administrador.";
                this._operationCode = AppNotification.OperationCode.ErrorNotControl.GetHashCode();
            }
        }

        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        public object Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public int OperationCode
        {
            get { return this._operationCode; }
            set { this._operationCode = value; }
        }

        public bool Succeeded
        {
            get
            {
                return this._operationCode == AppNotification.OperationCode.Exito.GetHashCode();
            }
        }

        public string TypeMessage
        {
            get
            {
                if (this._operationCode == AppNotification.OperationCode.Exito.GetHashCode())
                    return AppNotification.TipoNotificacion.success.ToString();
                if (this._operationCode == AppNotification.OperationCode.ErrorApp.GetHashCode())
                    return AppNotification.TipoNotificacion.info.ToString();
                if (this._operationCode == AppNotification.OperationCode.ErrorDataBase.GetHashCode())
                    return AppNotification.TipoNotificacion.error.ToString();
                if (this._operationCode == AppNotification.OperationCode.ErrorNotControl.GetHashCode())
                    return AppNotification.TipoNotificacion.error.ToString();
                return AppNotification.TipoNotificacion.info.ToString();
            }
        }
    }

    public class ValidationResult<T> where T : class
    {
        public ValidationResult()
        {
        }

        private string _message;
        private T _data;
        private int _operationCode;
        private string _typeMessage;
        private bool _succeeded;

        public ValidationResult(string message, AppNotification.OperationCode? operationCode)
        {
            this._message = message;
            this._data = (T)null;
            this._operationCode = operationCode.HasValue ? operationCode.Value.GetHashCode() : AppNotification.OperationCode.Exito.GetHashCode();
        }

        public ValidationResult(string message, AppNotification.OperationCode? operationCode, T data = null)
        {
            this._message = message;
            this._data = data;
            this._operationCode = operationCode.HasValue ? operationCode.Value.GetHashCode() : AppNotification.OperationCode.Exito.GetHashCode();
        }

        public ValidationResult(AppNotification.OperationCode? operationCode, T data = null)
        {
            this._message = string.Empty;
            this._data = data;
            this._operationCode = operationCode.HasValue ? operationCode.Value.GetHashCode() : AppNotification.OperationCode.Exito.GetHashCode();
        }

        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        public T Data
        {
            get { return this._data; }
            set { this._data = value; }
        }
        
        public int OperationCode
        {
            get { return this._operationCode; }
            set { this._operationCode = value; }
        }
        
        public bool Succeeded
        {
            get
            {
                return this._operationCode == AppNotification.OperationCode.Exito.GetHashCode();
            }
            set
            {
                _succeeded = value;
            }
        }
        
        public string TypeMessage
        {
            get
            {
                if (this._operationCode == AppNotification.OperationCode.Exito.GetHashCode())
                    return AppNotification.TipoNotificacion.success.ToString();
                if (this._operationCode == AppNotification.OperationCode.ErrorApp.GetHashCode())
                    return AppNotification.TipoNotificacion.info.ToString();
                if (this._operationCode == AppNotification.OperationCode.ErrorDataBase.GetHashCode())
                    return AppNotification.TipoNotificacion.error.ToString();
                if (this._operationCode == AppNotification.OperationCode.ErrorNotControl.GetHashCode())
                    return AppNotification.TipoNotificacion.error.ToString();
                return AppNotification.TipoNotificacion.info.ToString();
            }
            set
            {
                _typeMessage = value;
            }
        }
    }
}
