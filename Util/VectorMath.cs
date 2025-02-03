using System;
using UnityEngine;

namespace Helpity
{
  public static class VectorMath
  {
    public static (Vector3Int min, Vector3Int max) MinMax(Vector3Int a, Vector3Int b)
    {
      return (ComponentMin(a, b), ComponentMax(a, b));
    }

    public static Vector3Int ComponentMin(Vector3Int a, Vector3Int b) =>
      ComponentOperation(a, b, Math.Min);

    public static Vector3Int ComponentMax(Vector3Int a, Vector3Int b) =>
      ComponentOperation(a, b, Math.Max);

    public static Vector3Int ComponentMin(Vector3Int[] vectors) =>
      ComponentReduce(vectors, Math.Min);

    public static Vector3Int ComponentMax(Vector3Int[] vectors) =>
      ComponentReduce(vectors, Math.Max);

    public static Vector3Int ComponentReduce(Vector3Int[] vectors, Func<int, int, int> operation)
    {
      if (vectors.Length == 0)
      {
        throw new ArgumentException("ComponentMin.vectors cannot have a length of 0");
      }
      return vectors.Reduce(
        (vec, current) => ComponentOperation(vec, current, operation),
        vectors[0]
      );
    }

    public static Vector3Int ComponentOperation(
      Vector3Int a,
      Vector3Int b,
      Func<int, int, int> operation
    )
    {
      return new Vector3Int(operation(a.x, b.x), operation(a.y, b.y), operation(a.z, b.z));
    }

    public static Vector3 ComponentOperation(Vector3 vec, Func<float, float> operation)
    {
      return new Vector3(operation(vec.x), operation(vec.y), operation(vec.z));
    }

    public static Vector3Int ComponentOperation(Vector3 vec, Func<float, int> operation)
    {
      return new Vector3Int(operation(vec.x), operation(vec.y), operation(vec.z));
    }

    public static Vector3Int ComponentOperation(Vector3Int vec, Func<int, int> operation)
    {
      return new Vector3Int(operation(vec.x), operation(vec.y), operation(vec.z));
    }

    public static (Vector3 aligned, Vector3 perpendicular) Decompose(Vector3 vector, Vector3 axis)
    {
      axis = axis.normalized;
      var aligned = Vector3.Dot(vector, axis) * axis;
      var perpendicular = vector - aligned;
      return (aligned, perpendicular);
    }

    public static Vector3 SmoothStep(Vector3 from, Vector3 to, float t)
    {
      Vector3 offset = from - to;
      float mag = offset.magnitude;
      float newMag = Mathf.SmoothStep(mag, 0, t);
      return to + offset.normalized * newMag;
    }
  }
}
