using UnityEngine;

namespace Helpity
{
  public static class Geometry
  {
    public static bool LineIntersectsFrustum(Camera camera, Ray ray)
    {
      foreach (var face in camera.Faces())
      {
        if (LineIntersectsFace(ray, face))
        {
          return true;
        }
      }
      return false;
    }

    public static bool LinePlaneIntersection(
      Vector3 linePoint,
      Vector3 lineDirection,
      Vector3 planePoint,
      Vector3 planeNormal,
      out Vector3 intersection
    )
    {
      var denom = Vector3.Dot(lineDirection, planeNormal);
      if (Mathf.Approximately(denom, 0))
      {
        intersection = linePoint;
        return Mathf.Approximately(Vector3.Dot(planeNormal, linePoint - planePoint), 0);
      }
      var numerator = Vector3.Dot(planePoint - linePoint, planeNormal);
      intersection = linePoint + lineDirection * (numerator / denom);
      return true;
    }

    public static bool LineIntersectsFace(Ray line, Vector3[] face)
    {
      var a = face[0];
      for (int i = 1; i < face.Length - 1; i++)
      {
        var (b, c) = face.Get2(i);
        if (PointInsideTriangle(line.origin, a, b, c, line.direction))
        {
          return true;
        }
      }
      return false;
    }

    public static bool PointInsideTriangle(
      Vector3 p,
      Vector3 a,
      Vector3 b,
      Vector3 c,
      Vector3? psudonormal = null
    )
    {
      // Compute the basis vector from the triangle to the point where component vectors are as follows
      // * alpha is the vector from a to b;
      // * beta is the vector from a to c;
      // * gamma is the vector from a to p;

      var l = b - a;
      var r = c - a;
      var _psudonormal = psudonormal ?? Vector3.Cross(l, r);

      // Compute gamma
      var n = Vector3.Cross(l, r).normalized;

      // We don't actually care about the value of gamma. Just that it can be computed.
      // This should be possible any time the psudonormal is not parallel to the triangle.
      if (!LinePlaneIntersection(p, _psudonormal, a, n, out var pointOnFace))
      {
        return false;
      }

      // Don't ask me how any of this works. I do not remember.

      var v = pointOnFace - a;

      var vOrthR = v - Vector3.Project(v, r);
      var vOrthL = v - Vector3.Project(v, l);

      var alpha = Vector3.Dot(vOrthR, vOrthR) / Vector3.Dot(l, vOrthR);
      var beta = Vector3.Dot(vOrthL, vOrthL) / Vector3.Dot(r, vOrthL);

      return alpha >= 0 && beta >= 0 && alpha + beta <= 1;
    }
  }
}
