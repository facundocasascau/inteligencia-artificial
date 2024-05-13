using System;
using TP2;

class Program
{
    static void Main(string[] args)
    {
        // Se crea una lista de posiciones aleatorias para los bloques
        Random rnd = new Random();
        var blockPositions = new[] {
            (rnd.Next(10), rnd.Next(10)),
            (rnd.Next(10), rnd.Next(10)),
            (rnd.Next(10), rnd.Next(10)),
            (rnd.Next(10), rnd.Next(10)),
            (rnd.Next(10), rnd.Next(10))
        };

        for (int i = 0; i < blockPositions.Length; i++)
        {
            var block = blockPositions[i];
            Console.WriteLine($"Posición número {i + 1}: {block}");
        }
        // Se crea un nuevo robot en la posición (0,0)
        var machine = new Machine(0, 0);

        Console.WriteLine("¿Qué tipo de búsqueda desea realizar? " +
            "\n 1. Busqueda Exhaustiva" +
            "\n 2. Busqueda Heuristica");

        string opcion = Console.ReadLine().Trim().ToLower();

        switch (opcion)
        {
            case "1":
                // Busqueda Exhaustiva
                Console.WriteLine("<<< Busqueda Exhaustiva >>>");

                foreach (var position in blockPositions)
                {
                    Console.WriteLine($"El robot se encuentra en la posición: {machine.GetCurrentPosition()}");
                    Console.WriteLine($"¿Puede ubicar la pieza en el bloque en la posición actual? {machine.CanMount(position)}");

                    Search.ExhaustiveSearch(machine, position);
                    Console.WriteLine($"Posición final: {machine.GetCurrentPosition()}");
                    Console.WriteLine($"¿Puede ubicar la pieza en el bloque en la nueva posición? {machine.CanMount(position)}");
                    machine = new Machine(position.Item1, position.Item2);
                    Console.WriteLine("<<< Fin >>>\n\n");
                }
                break;
                // Busqueda Heuristica
            
            case "2":
                Console.WriteLine("<<< Busqueda Heuristica >>>");
                foreach (var position in blockPositions)
                {
                    Console.WriteLine($"El robot se encuentra en la posición: {machine.GetCurrentPosition()}");
                    Console.WriteLine($"¿Puede ubicar la pieza en el bloque en la posición actual? {machine.CanMount(position)}");

                    Search.HeuristicSearch(machine, position);
                    Console.WriteLine($"Posición final: {machine.GetCurrentPosition()}");
                    Console.WriteLine($"¿Puede ubicar la pieza en el bloque en la nueva posición? {machine.CanMount(position)}");
                    Console.WriteLine("<<< Fin >>>\n\n");

                }
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}