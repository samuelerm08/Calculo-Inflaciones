using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PracticaLogica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            string[] input = new string[0];
            string opcion;

            float[] inflacion = new float[0];
            float inflacionTotal = 0;
            float promedioInflacion = 0;
            float maximaInflacion = 0;
            float minimaInflacion = 0;

            int flagMayor = 0;
            int flagMenor = 0;

            Console.WriteLine("¡Bienvenido!, presionar enter para continuar");
            Console.ReadKey();

            do
            {
                Console.Clear();

                IngresoDatos(ref inflacion, ref input);

                CalculoFinal(ref flagMayor, ref flagMenor, ref maximaInflacion, ref minimaInflacion, ref inflacion, ref inflacionTotal, ref promedioInflacion);

                Informar(meses, inflacion, inflacionTotal, promedioInflacion, flagMayor, flagMenor, minimaInflacion, maximaInflacion);

                Console.WriteLine("Desea volver a calcular? (s/n)");
                opcion = Console.ReadLine();
                Console.Clear();

                if (opcion.Trim() == string.Empty || opcion != "s" && opcion != "n")
                {
                    Console.WriteLine("Opción inválida");
                }

            } while (opcion == "s");

            Console.WriteLine("Fin del Proceso");
        }
        static void IngresoDatos(ref float[] inflacion, ref string[] input)
        {
            Console.WriteLine("Ingresar los datos de inflación anual por mes separados por espacio:");
            input = Console.ReadLine().Split(' ');
            inflacion = new float[input.Length];
            Console.Clear();

            for (int i = 0; i < inflacion.Length; i++)
            {
                try { inflacion[i] = float.Parse(input[i].Replace(".",",")); }

                catch
                {
                    Console.WriteLine("{0}",
                    input[i].Trim() == string.Empty ?
                    "Debe llenar con valores decimales separados por espacio cada mes de inflación" :
                    "Formato incorrecto");

                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
        }
        static void CalculoFinal(ref int flagMayor, ref int flagMenor, ref float maximaInflacion, ref float minimaInflacion, ref float[] inflacion, ref float inflacionTotal, ref float promedioInflacion)
        {
            maximaInflacion = inflacion[0];
            minimaInflacion = inflacion[0];

            for (int i = 0; i < inflacion.Length; i++)
            {
                {
                    inflacionTotal += inflacion[i];

                    promedioInflacion = inflacionTotal / inflacion.Length;

                    if (maximaInflacion < inflacion[i])
                    {
                        maximaInflacion = inflacion[i];
                        flagMayor = i;
                    }

                    if (minimaInflacion > inflacion[i])
                    {
                        minimaInflacion = inflacion[i];
                        flagMenor = i;
                    }
                }
            }
        }
        static void Informar(string[] meses, float[] inflacion, float inflacionTotal, float promedioInflacion, int flagMayor, int flagMenor, float minimaInflacion, float maximaInflacion)
        {
            if (inflacion.Length < 12)
                Console.WriteLine("Datos insuficientes...");
            else if (inflacion.Length > 12)
                Console.WriteLine("Deben ingresarse hasta 12 meses para calcular la inflación anual");
            else
                Console.WriteLine($"La inflación total fue de: {inflacionTotal}\n" +
                             $"El promedio de la inflación fue de: {promedioInflacion}\n" +
                             $"La máxima inflación fue de: {maximaInflacion} y ocurrió en el mes de: {meses[flagMayor]}\n" +
                             $"La menor inflación fue de: {minimaInflacion} y ocurrió en el mes de: {meses[flagMenor]}" + Environment.NewLine);
        }
    }
}

