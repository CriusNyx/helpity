using UnityEngine;

namespace Helpity
{
  public static class MoreDebug
  {
    public static void DrawLineRay(
      Ray ray,
      Color? color = null,
      float distance = 100f,
      float duration = -1
    )
    {
      var _color = color ?? Color.white;
      var dir = ray.direction.normalized;

      Debug.DrawRay(ray.origin, dir.normalized * distance, _color, duration);
      Debug.DrawRay(ray.origin, dir.normalized * -distance, _color, duration);
    }

    public static void DrawCross(Vector3 point, float size = 1f, Color? color = null)
    {
      var _color = color ?? Color.white;
      Debug.DrawLine(point + Vector3.left * size, point + Vector3.right * size, _color);
      Debug.DrawLine(point + Vector3.down * size, point + Vector3.up * size, _color);
      Debug.DrawLine(point + Vector3.back * size, point + Vector3.forward * size, _color);
    }

    public static void DrawBounds(Bounds bounds)
    {
      foreach (var (a, b) in bounds.Edges())
      {
        Debug.DrawLine(a, b);
      }
    }

    public static void DrawMatrix(Matrix4x4 matrix, Bounds? bounds = null, Color? color = null)
    {
      var _bounds = bounds ?? new Bounds(Vector3.zero, Vector3.one * 2f);
      var _color = color ?? Color.white;

      foreach (var (a, b) in _bounds.Edges())
      {
        var _a = matrix.MultiplyPoint(a);
        var _b = matrix.MultiplyPoint(b);

        Debug.DrawLine(_a, _b, _color);
      }
    }

    public static void DrawMatrixVertices(
      Matrix4x4 matrix,
      Bounds? bounds = null,
      Color? color = null
    )
    {
      var _bounds = bounds ?? new Bounds(Vector3.zero, Vector3.one * 2f);
      var _color = color ?? Color.white;

      foreach (var vert in _bounds.Vertices())
      {
        DrawCross(matrix.MultiplyPoint(vert), 1f, _color);
      }
    }

    public static void DrawFace(Vector3[] vertices, Color? color = null)
    {
      for (int i = 0; i < vertices.Length; i++)
      {
        var j = (i + 1) % vertices.Length;
        Debug.DrawLine(vertices[i], vertices[j], color ?? Color.white);
      }
    }

    public static void DrawBox(
      Vector3 position,
      Vector3? size = null,
      Quaternion? rotation = null,
      Color? color = null
    )
    {
      var rot = rotation ?? Quaternion.identity;
      var s = size ?? Vector3.one;
      foreach (var face in UnitBox.faces)
      {
        DrawFace(face.Map(x => rot * Vector3.Scale(s, x * 0.5f) + position), color);
      }
    }
  }
}
