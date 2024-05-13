using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2;

public class Search
{
    public static void ExhaustiveSearch(Machine robot, (int, int) blockPosition, (int, int)? limit = null)
    {
        int iteration = 0;
        if (limit == null)
            limit = (0, 10);

        for (int x = limit.Value.Item1; x < limit.Value.Item2; x++)
        {
            for (int y = limit.Value.Item1; y < limit.Value.Item2; y++)
            {
                robot.SetPosition(x, y);
                iteration++;
                if (robot.CanMount(blockPosition))
                {
                    Console.WriteLine($"Bloque ubicado en la posición {blockPosition}, luego de {iteration} intentos");
                    return;
                }
            }
        }
        Console.WriteLine("No se encontró el bloque.");
    }

    public static void HeuristicSearch(Machine robot, (int, int) blockPosition, (int, int)? limit = null)
    {
        int iteration = 0;
        if (limit == null)
            limit = (0, 10);

        // Inicializa la cola de prioridad con la posición actual del robot
        var queue = new SortedSet<(int, (int, int))>(Comparer<(int, (int, int))>.Create((a, b) => a.Item1.CompareTo(b.Item1)));
        queue.Add((ManhattanDistance(robot.GetCurrentPosition(), blockPosition), robot.GetCurrentPosition()));

        // Posiciones visitadas
        var visited = new HashSet<(int, int)>();

        while (queue.Count > 0)
        {
            // Obtener la posición con el menor valor heurístico
            var (_, currentPosition) = queue.Min;
            queue.Remove(queue.Min);

            // Ignoramos posiciones visitadas
            if (visited.Contains(currentPosition))
                continue;

            // Agregamos la posición actual como visitadas
            visited.Add(currentPosition);

            // Movemos el robot a la posición actual
            robot.SetPosition(currentPosition.Item1, currentPosition.Item2);

            iteration++;
            // Puede montar el bloque?
            if (robot.CanMount(blockPosition))
            {
                Console.WriteLine($"Encontrado el bloque en la posición {blockPosition}, numero de iteraciones {iteration}");
                return;
            }

            // Agregamos posiciones vecinas a la cola
            foreach (var (dx, dy) in new[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
            {
                var newPosition = (currentPosition.Item1 + dx, currentPosition.Item2 + dy);

                // Consideramos posiciones dentro del límite y que aún no hayamos visitado
                if (limit.Value.Item1 <= newPosition.Item1 && newPosition.Item1 < limit.Value.Item2 && limit.Value.Item1 <= newPosition.Item2 && newPosition.Item2 < limit.Value.Item2)
                {
                    var heuristicValue = ManhattanDistance(newPosition, blockPosition);
                    queue.Add((heuristicValue, newPosition));
                }
            }
        }

        Console.WriteLine("No se ha podido ubicar el bloque.");
    }

    public static int ManhattanDistance((int, int) position1, (int, int) position2)
    {
        return Math.Abs(position1.Item1 - position2.Item1) + Math.Abs(position1.Item2 - position2.Item2);
    }
}