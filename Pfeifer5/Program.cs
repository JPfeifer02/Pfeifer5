using System;

namespace GraphNS;
class Program
{
    static void Main(string[] args)
    {
        // Create a new graph object
        Graph graph = new Graph("graph.json");
        // Perform depth-first search
        Console.WriteLine("Performing depth-first search...");
        graph.DepthFS(0);
        Console.WriteLine("");

        // Perform breadth-first search
        Console.WriteLine("Performing breadth-first search...");
        graph.BreadthFS(0);
        Console.WriteLine("");

        Console.ReadLine();

    }
}
