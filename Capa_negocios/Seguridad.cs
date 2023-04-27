using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;

namespace Capa_negocios
{
   
    public class seguridad
    {
        public string GetSHA256(string str)
           //METODO PARA ENCRIPTAR
        {
            SHA256 sha256 = SHA256Managed.Create(); 
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null; 
            StringBuilder sb = new StringBuilder(); 
            stream=sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();   
        }





    }
}
