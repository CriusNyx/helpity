using System;
using System.Linq;

namespace Helpity.Algorithms
{
  public static class Graph
  {
    private static bool TryExpandBoundary<TNode, TDirection>(
      TNode[] boundary,
      Func<TNode, TDirection, (bool, TNode)> expansionFunc,
      TDirection direction,
      out TNode[] newBoundary
    )
    {
      newBoundary = new TNode[boundary.Length];
      for (int i = 0; i < boundary.Length; i++)
      {
        var element = boundary[i];
        if (expansionFunc(element, direction).Safe(out var result))
        {
          newBoundary[i] = result;
        }
        else
        {
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// Function to preform a boundary expansion on the graph.
    /// Should return null if the boundary cannot be expanded.
    /// </summary>
    /// <param name="initialNode"></param>
    /// <param name="expansionFunc"></param>
    /// <param name="directions"></param>
    /// <typeparam name="TNode"></typeparam>
    /// <typeparam name="TDirection"></typeparam>
    /// <returns></returns>
    public static TNode[][] SpiralSearch<TNode, TDirection>(
      TNode initialNode,
      Func<TNode, TDirection, (bool, TNode)> expansionFunc,
      TDirection[] directions
    )
    {
      (TNode[] boundaryNodes, bool live)[] boundaries = directions.Map(
        dir => (new[] { initialNode }, true)
      );

      bool done = false;

      while (!done)
      {
        for (int i = 0; i < boundaries.Length; i++)
        {
          var (boundary, live) = boundaries[i];
          var direction = directions[i];
          if (live)
          {
            if (TryExpandBoundary(boundary, expansionFunc, direction, out var newBoundary))
            {
              // Update previous boundary.
              boundaries.SafeSet(
                i - 1,
                (value) => (value.boundaryNodes.Push(newBoundary.Head()), value.live)
              );

              // Update next boundary.
              boundaries.SafeSet(
                i + 1,
                (value) => (value.boundaryNodes.Enqueue(newBoundary.Tail()), value.live)
              );

              // Update the current boundary.
              boundaries[i] = (newBoundary, true);
            }
            else
            {
              // If this boundary failed to expand mark it as dead.
              boundaries[i] = (boundaries[i].boundaryNodes, false);
            }
          }
        }

        done = boundaries.All(x => !x.live);
      }

      return boundaries.Map(x => x.boundaryNodes);
    }
  }
}
