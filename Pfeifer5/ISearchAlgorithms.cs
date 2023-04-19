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

public interface ISearchAlgorithms
{
    public Stack<Node> Stack { get; }
    public Queue<Node> Queue { get; }
    public abstract void DepthFS(int start);
    public abstract void BreadthFS(int start);
}

