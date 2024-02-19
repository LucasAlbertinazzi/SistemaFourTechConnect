using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFourTechConnect.Classes.Uteis
{
    public static class InfoGlobal
    {
        //Informaçõess do usuario
        public static int? idUser;
        public static string? user;
        public static string? password;
        public static string? function;

        //Informações do App
        public static double? version;
        public static bool? isMenuOpen;

        //Informações da API
        public static string apiAppDev = "http://192.168.10.94:5000/api";
        public static string apiEstoqueDev = "http://192.168.10.94:5001/api";

        public static string apiApp = "http://192.168.85.3:6565/api";
        public static string apiEstoque = "http://192.168.85.3:6566/api";

        public static string apk = "http://192.168.85.3:25434/";

        // Método para ajustar as URLs das APIs com base no ambiente de execução
        public static void AjustarUrlsParaDebug()
        {
            if (Debugger.IsAttached)
            {
                apiApp = apiAppDev;
                apiEstoque = apiEstoqueDev;
            }
        }

        public static void ClearData()
        {
            user = string.Empty;
            password = string.Empty;
            function = string.Empty;
        }
    }
}
