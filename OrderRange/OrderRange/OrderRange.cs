using System;
using System.Linq;

namespace OrderRange
{
    public class OrderRange
    {
        public string build(int[] param)
        {
            var resultado = string.Empty;

            var pares = new int[0];
            var impares = new int[0];

            var listaOrdenada = param.OrderBy(i => i).ToArray();
            for (int i = 0; i < param.Length; i++)
            {
                if (listaOrdenada[i] % 2 == 0)
                {
                    Array.Resize(ref pares, pares.Length + 1);
                    pares[pares.Length - 1] = listaOrdenada[i];
                }
                else
                {
                    Array.Resize(ref impares, impares.Length + 1);
                    impares[impares.Length - 1] = listaOrdenada[i];
                }
            }

            if (pares[0] > impares[0])
            {
                resultado = concatenarLista(impares) + concatenarLista(pares);
            }
            else
            {
                resultado = concatenarLista(pares) + concatenarLista(impares);
            }

            return resultado;
        }

        private string concatenarLista(int[] param)
        {
            var resultado = string.Empty;
            resultado += "[";
            for (int i = 0; i < param.Length; i++)
            {
                resultado += param[i].ToString() + ",";
            }
            if (param.Length > 1) resultado = resultado.Substring(0, resultado.Length - 1);
            resultado += "]";
            return resultado;
        }
    }
}