using System;
using System.Diagnostics;

namespace ControlApagadoPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Control de Apagado de PC");
            Console.WriteLine("========================");

            while (true)
            {
                Console.WriteLine("1. Apagar la PC");
                Console.WriteLine("2. Cancelar apagado");
                Console.WriteLine("3. Salir");
                Console.Write("Elija una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese la cantidad de minutos para apagar la PC: ");
                        int minutos = int.Parse(Console.ReadLine());
                        EjecutarComando($"shutdown -s -t {minutos * 60}");
                        break;

                    case 2:
                        EjecutarComando("shutdown -a");
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                        break;
                }
            }
        }

        static void EjecutarComando(string comando)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c " + comando);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}