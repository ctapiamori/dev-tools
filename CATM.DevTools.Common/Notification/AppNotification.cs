using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATM.DevTools.Common.Notification
{
    public class AppNotification
    {
        public static class Titulo
        {
            public static string Exito
            {
                get
                {
                    return "Operación Exitosa";
                }
            }

            public static string Error
            {
                get
                {
                    return "Operación Fallida";
                }
            }

            public static string Confirmacion
            {
                get
                {
                    return "Confirmación";
                }
            }

            public static string Informacion
            {
                get
                {
                    return "Información";
                }
            }

            public static string Advertencia
            {
                get
                {
                    return "Advertencia";
                }
            }
        }

        public static class Icon
        {
            public static string Exito
            {
                get
                {
                    return "glyphicon glyphicon-ok-sign";
                }
            }

            public static string Error
            {
                get
                {
                    return "glyphicon glyphicon-warning-sign";
                }
            }

            public static string Confirmacion
            {
                get
                {
                    return "glyphicon glyphicon-question-sign";
                }
            }

            public static string Informacion
            {
                get
                {
                    return "glyphicon glyphicon-info-sign";
                }
            }

            public static string Advertencia
            {
                get
                {
                    return "glyphicon glyphicon-exclamation-sign";
                }
            }
        }

        public enum TipoNotificacion
        {
            [Description("none")]
            none,
            [Description("notice")]
            notice,
            [Description("info")]
            info,
            [Description("success")]
            success,
            [Description("error")]
            error,
        }

        public enum OperationCode
        {
            [Description("Exito")]
            Exito = 200,
            [Description("Entidad no procesable")]
            UnprocessableEntity = 422,
            [Description("Error no controlado")]
            ErrorNotControl = 500,
            [Description("Usuario no existe")]
            UsuarioNoExiste = 600,
            [Description("No pudo acceder a la aplicacion")]
            LoginIncorrecto = 601,
            [Description("Recupero el password Satisfactoriamente")]
            RecuperoPasswordCorrectamente = 602,
            [Description("El correo ya esta registrado como un usuario")]
            ExisteUsuarioRegistrado = 611,
            [Description("Error de Base de Datos")]
            ErrorDataBase = 800,
            [Description("Error de aplicacion por validaciones del negocio")]
            ErrorApp = 900,
        }
    }
}
