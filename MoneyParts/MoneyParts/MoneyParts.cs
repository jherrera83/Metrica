using System;

namespace MoneyParts
{
    public class MoneyParts
    {
        public string build(decimal param)
        {
            var resultado = string.Empty;

            var denominaciones = new decimal[] { 0.05m, 0.1m, 0.2m, 0.5m, 1, 2, 5, 10, 20, 50, 100, 200 };

            resultado += "[";
            for (int i = 0; i < denominaciones.Length; i++)
            {
                var total = 0m;
                var iteraciones = param / denominaciones[i];

                var dato = iteraciones % 1;

                if (iteraciones % 1 == 0)
                {
                    resultado += "[";
                    for (int j = 0; j < iteraciones; j++)
                    {
                        resultado += denominaciones[i] + ",";
                        total += denominaciones[i];
                        if (total == param)
                        {
                            resultado = resultado.Substring(0, resultado.Length - 1);
                            resultado += "]";
                            break;
                        }
                    }
                }
                else
                {
                    if ((int)iteraciones > 0 && param == (param / denominaciones[i]))
                    {

                        var entero = (int)iteraciones;
                        var dec = iteraciones - Math.Truncate(iteraciones);

                        var indiceEntero = Array.IndexOf(denominaciones, entero);
                        var indiceDec = Array.IndexOf(denominaciones, dec);

                        resultado += "[" + denominaciones[indiceEntero] + "," + denominaciones[indiceDec] + "]";
                    }
                }
            }
            resultado += "]";
            return resultado;
        }
    }
}
