using System;
using System.Text.RegularExpressions;

namespace ChangeString
{
    public class ChangeString
    {
        public string build(string param)
        {
            var resultado = string.Empty;
            var abecedario = new string[] { "A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h", "I", "i", "J", "j", "K", "k", "L", "l", "M", "m", "N", "n", "Ñ", "ñ", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T", "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z" };

            for (int i = 0; i < param.Length; i++)
            {
                Regex reg = new Regex((@"^[a-zA-Z]+$"));
                if (reg.Match(param[i].ToString()).Success)
                {
                    var indice = Array.IndexOf(abecedario, param[i].ToString());
                    if (indice + 2 < abecedario.Length)
                        resultado += abecedario[indice + 2];                   
                }
                else
                {
                    resultado += param[i];
                }
            }
            return resultado;
        }
    }
}
