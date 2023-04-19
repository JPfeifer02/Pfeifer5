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
namespace GraphNS;

public class Node
{
    //Properties (attributes)
    public int Id { get; set; } // unique identifier of the node
    public bool WasVisited { get; set; } // flag to keep track of whether the node was visited during a search
    public List<bool> AdjacentNodes { get; set; } // list of adjacent nodes

    public Node(int id)
    {
        Id = id;
        WasVisited = false;
        AdjacentNodes = new List<bool>();
    }
}