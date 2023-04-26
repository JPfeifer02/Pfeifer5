/********************************************************************
*** NAME        : Johnny Pfeifer                                  ***
*** CLASS       : CSc 346                                         ***
*** ASSIGNMENT  : 5                                               ***
*** DUE DATE    : 4-19-23                                         ***
*** INSTRUCTOR  : GAMRADT                                         ***
*********************************************************************
*** DESCRIPTION : This program implements a graph and a BFS and  ***
                    DFS algorithm to traverse the graph          ***
********************************************************************/
using System;
using System.Text.Json;

namespace GraphNS;
public class Graph : IProcessData, ISearchAlgorithms
{
    // Field
    private List<Node> _nodes; // list of nodes in the graph

    public Stack<Node> Stack { get; }
    public Queue<Node> Queue { get; }

    public Graph(string filePath)
    {
        _nodes = new List<Node>();
        Stack = new Stack<Node>();
        Queue = new Queue<Node>();
        ReadData(filePath);
    }
    /********************************************************************
    *** METHOD ResetVisitedSet                                        ***
    *********************************************************************
    *** DESCRIPTION : This method resets all nodes in the graph to be ***
    ***                     not visited.                              ***
    *** INPUT ARGS :                                                  ***
    *** OUTPUT ARGS:                                                  ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN : void                                                 ***
    ********************************************************************/
    private void ResetVisitedSet()
    {
        foreach (Node node in _nodes)
        {
            node.WasVisited = false;
        }
    }
    /********************************************************************
    *** METHOD FindAdjacentUnvisitedNode                              ***
    *********************************************************************
    *** DESCRIPTION : This method looks through the current nodes     ***
    ***         adjacency list to find all unvisited adjacent nodes   ***
    *** INPUT ARGS : Node node                                        ***
    *** OUTPUT ARGS:                                                  ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN : Node?                                                ***
    ********************************************************************/
    private Node? FindAdjacentUnvisitedNode(Node node)
    {
        for(int i = 0; i < node.AdjacentNodes.Count; i++)
        {
            if(node.AdjacentNodes[i] && !_nodes[i].WasVisited)
            {
                return _nodes[i];
            }
        }
        return null;
    }
    /********************************************************************
    *** METHOD ViewNode                                               ***
    *********************************************************************
    *** DESCRIPTION : This method views the ID of the node passed in  ***
    *** INPUT ARGS : Node node                                        ***
    *** OUTPUT ARGS:                                                  ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN : void                                                 ***
    ********************************************************************/
    public void ViewNode(Node node)
    {
        Console.Write($"{node.Id} ");
    }
    /********************************************************************
    *** METHOD ReadData                                               ***
    *********************************************************************
    *** DESCRIPTION : This method reads the data from the json file   ***
    *** and deserializes it into a list of nodes                      ***
    *** INPUT ARGS : Node node                                        ***
    *** OUTPUT ARGS:                                                  ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN : void                                                 ***
    ********************************************************************/
    public void ReadData(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        _nodes = JsonSerializer.Deserialize<List<Node>>(jsonString) ?? new List<Node>();
    }
    /********************************************************************
    *** METHOD DepthFS                                                ***
    *********************************************************************
    *** DESCRIPTION : This method traverses the nodes in the graph    *** 
        and performs a Depth First Search                             ***
    *** INPUT ARGS : int start                                        ***
    *** OUTPUT ARGS:                                                  ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN : void                                                 ***
    ********************************************************************/

    public void DepthFS(int start)
    {
        ResetVisitedSet();
        // Mark the start node as visited and push it to the stack
        _nodes[start].WasVisited = true;
        Stack.Push(_nodes[start]);

        // Loop until the stack is empty
        while (Stack.Count != 0)
        {
            // Pop a node from the stack
            Node currentNode = Stack.Pop();
            ViewNode(currentNode);
                  
            Node? adjacentNode = FindAdjacentUnvisitedNode(currentNode);
            while(adjacentNode != null)
            {
                adjacentNode.WasVisited = true;
                Stack.Push(adjacentNode);
                adjacentNode = FindAdjacentUnvisitedNode(currentNode);
            }
        }
    }
    /********************************************************************
    *** METHOD DepthFS                                                ***
    *********************************************************************
    *** DESCRIPTION : This method traverses the nodes in the graph    *** 
        and performs a Breadth First Search                           ***
    *** INPUT ARGS : int start                                        ***
    *** OUTPUT ARGS:                                                  ***
    *** IN/OUT ARGS :                                                 ***
    *** RETURN : void                                                 ***
    ********************************************************************/
    public void BreadthFS(int start)
    {
        ResetVisitedSet();
        // Mark the start node as visited and enqueue it
        _nodes[start].WasVisited = true;
        Queue.Enqueue(_nodes[start]);

        // Loop until the queue is empty
        while (Queue.Count != 0)
        {
            // Dequeue a node from the queue
            Node currentNode = Queue.Dequeue();
            ViewNode(currentNode);

            Node? adjacentNode = FindAdjacentUnvisitedNode(currentNode);
            while(adjacentNode != null)
            {
                adjacentNode.WasVisited = true;
                Queue.Enqueue(adjacentNode);
                adjacentNode = FindAdjacentUnvisitedNode(currentNode);
            }
        }
    }
}

