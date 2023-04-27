using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_negocios
{
    public class Validaciones
    {
        public bool ValidarEmail(string comprobarEmai1)
        {
            string emailFormato;
            emailFormato = "\\w+([-+.']\\w+)@\\w+([-.]\\w+)\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(comprobarEmai1, emailFormato))
            {
                if (Regex.Replace(comprobarEmai1, emailFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void SoloNum(KeyPressEventArgs P)
        {
            if (Char.IsDigit(P.KeyChar)) // Busca si el Char del evento es un numero.
            {
                P.Handled = false; // Si es un numero, permite la digitacion.
            }
            else if (Char.IsControl(P.KeyChar)) // Busca si el char es un control.
            {
                P.Handled = false; // Si es un control, permite la digitacion.
            }
            else
            {
                P.Handled = true; // Si el Char es una letra, no permite la digitacion.
                MessageBox.Show("Error, solo numeros");
            }
        }
        public void SoloLetras(KeyPressEventArgs P)
        {
            if (Char.IsLetter(P.KeyChar)) // Busca si el Char del evento es una letra
            {
                P.Handled = false; // Si es una letra, permite la digitacion.
            }
            else if (Char.IsControl(P.KeyChar)) // Busca si el char es un control.
            {
                P.Handled = false; // Si es un control, permite la digitacion.
            }
            else
            {
                P.Handled = true; // Si el Char es un numero, no permite la digitacion.
                MessageBox.Show("Error, solo letras");
            }
        }
    }
}

