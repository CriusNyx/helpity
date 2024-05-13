using UnityEngine;

namespace Helpity
{
  public static class BoundsExtensions
  {
    public static (Vector3, Vector3)[] Edges(this Bounds bounds)
    {
      Vector3 halfSize = bounds.size / 2f;

      return UnitBox.edges.Map(
        (edge) =>
        {
          return edge.Map((vert) => bounds.center + Vector3.Scale(halfSize, vert));
        }
      );
    }

    public static Vector3[] Vertices(this Bounds bounds)
    {
      Vector3 halfSize = bounds.size / 2f;
      return UnitBox.vertices.Map(
        (vert) =>
        {
          return bounds.center + Vector3.Scale(halfSize, vert);
        }
      );
    }

    public static Vector3[][] Faces(this Bounds bounds)
    {
      Vector3 halfSize = bounds.size / 2f;
      return UnitBox.faces.Map(
        (face) => face.Map(vertex => bounds.center + Vector3.Scale(halfSize, vertex))
      );
    }
  }
}
