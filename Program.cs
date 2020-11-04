using System;
using System.Diagnostics; // para ej 1.4
using System.Globalization;
using System.Text;

namespace PracticaCadenas
{
    class Program
    {
        static void Main(string[] args)
        {
            #region StringBuilder
            //Ej 1
            string mensaje = "Bienvenido al sistema";
            mensaje = "Vuelve pronto";
            //Ej 2
            StringBuilder sb = new StringBuilder("Bienvenido al sistema");
            //Ej 3 public StringBuilder(string? value, int startIndex, int length, int capacity);
            StringBuilder sb2 = new StringBuilder(5, 5); //capacity and max capacity
            //sb2.Append(sb);// marca error
            //Ej 4 comparacion
            Stopwatch sw = new Stopwatch();
            int ciclos = 50000;

            string str = "";
            sw.Start();
            for (int i = 0; i < ciclos; i++)
                str += i.ToString();
            sw.Stop();
            Console.WriteLine("Tiempo string: {0} milisegundos", sw.ElapsedMilliseconds);
            //Console.WriteLine(str);

            StringBuilder sb3 = new StringBuilder();
            sw.Restart();
            for (int i = 0; i < ciclos; i++)
            {
                sb3.Append(i.ToString());
            }
                
            sw.Stop();
            Console.WriteLine("Tiempo stringBuilder: {0} milisegundos", sw.ElapsedMilliseconds);
            //Console.WriteLine(sb3);
            #endregion

            #region StrinInterpolation
            //ej 1
            string un = "Noemi";
            DateTime dt = DateTime.Now;
            Console.WriteLine($"Bienvenido {un}, Acceso: dia {dt.Date} , hora {dt.TimeOfDay}");
            //Ej 2
            Console.WriteLine($"Redondeo {Math.Round(5.6)}");
            #endregion

            #region 2.3 String Methods for validation
            string nombre = String.Empty;
            //Ej 1 IsNullOrEmpty
            do
            {
                Console.WriteLine("Escribe tu nombre completo");
                nombre = Console.ReadLine();
            } while (String.IsNullOrEmpty(nombre));//Ej 2 sustituir por IsNullOrWhiteSpace 

            //Ej 3
            string subc = "noe"; //subcadena
            if (nombre.Contains(subc))
            {
                var i = nombre.IndexOf(subc);
                Console.WriteLine($"El nombre contiene la subcadena en la posición {i}");
            }
            else
                Console.WriteLine("El nombre no contine la subcadena");
            #endregion

            #region other string methods
            //Ej 4
            string entrada = "GGCG";
            string cadena = "GGcgCGUGGGCUAGCGCCACUCAAAAGGCCCAU";
            
            int coincideInicio = 0;
            int coincideFin = 0;
            for (int i = 0; i<cadena.Length-1; i+=4)
            {
                var c = cadena.Substring(i, 4);
                //Console.WriteLine(c);
                if (c.StartsWith(entrada[0]))
                    coincideInicio += 1;
                if (c.EndsWith(entrada[3]))
                    coincideFin += 1;

                //Format Ej 2
                //-10 agrega 10 caract a la derecha
                string imprime = string.Format("{0,-10}: {1}", i.ToString(), c.ToUpper());
                Console.WriteLine(imprime);
            }
            Console.WriteLine($"Inicio coindice '{coincideInicio}' veces");
            Console.WriteLine($"Fin coindice '{coincideFin}' veces");
            #endregion

            #region Format
            //Ej 1
            string coincideInicioBD = string.Format("Inicio coindice: {0} veces", coincideInicio);
            Console.WriteLine(coincideInicioBD);

            //Ej 2 en tema antrior (ARN)

            //Ej 3
            //pais, casos total, recuperados, muertes, fecha inicio
            //Pte 1
            Tuple<string, int, int, int, DateTime>[] casosCovid =
                { Tuple.Create("Estados Unidos", 
                                9380000, 8000000, 231000,
                               new DateTime(2020, 1, 12)),
                  Tuple.Create("India",
                                8270000, 6000000, 123000,
                               new DateTime(2020, 3, 23)),
                  Tuple.Create("Brasil",
                                5550000, 5000000, 160000,
                               new DateTime(2020, 2, 8)),
                 };
            //Pte 2
            Console.WriteLine("Casos COVID-19");
            string[] titulos = { "País", "Casos", "Recuperados", "Muertes", "Fecha inicio"}; 
            string encabezado = string.Format("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5}", 
                                                titulos[0], titulos[1], titulos[2], titulos[3], titulos[4], "% Recup" );

            Console.WriteLine(encabezado);
            //Pte 3
            foreach (var caso in casosCovid)
            {
                double porcentajeRecup = caso.Item3 / (double)caso.Item2; //90.09 Brasil
                string imprime = string.Format("{0, -15} {1, -15:N0} {2, -15:N0} {3, -15:N0} {4, -15:MMMM} {5:P1}", //{5:F2} o {5, 15:P1}
                                 caso.Item1, caso.Item2, caso.Item3, caso.Item4, caso.Item5, porcentajeRecup);
                Console.WriteLine(imprime);

                /*------------------------
                 * Para SIG VIDEO custom numeric format strings
                 * Ej 2*
                 * --------------------------*/
                Console.WriteLine(porcentajeRecup.ToString("0.0"));
                //podria ser tambien 
                Console.WriteLine(String.Format("{0:0.0}", porcentajeRecup));
             
                //y si queremos dar formarto a las cantidades por cultura: usar system.globalization
                CultureInfo esEs = CultureInfo.CreateSpecificCulture("es-ES");
                Console.WriteLine(caso.Item2.ToString("0,0", esEs));

                //Ej 3 formato condicional - SE DEBE AGREGAR en las columnas, NO AQUI
                Console.WriteLine(porcentajeRecup);
                string msj = String.Format("#0.##%" + (porcentajeRecup > 0.8 ? " Bueno" : " Malo"), porcentajeRecup);
                Console.WriteLine(porcentajeRecup.ToString(msj));

            }
            #endregion

            #region Custom numeric format strings
            //Ej 1
            long tel = 15512349900;
            Console.WriteLine(tel.ToString("+# (##) ####-####"));
          

            

            #endregion
        }
    }
}
