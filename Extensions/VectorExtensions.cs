using System;
using UnityEngine;

namespace Helpity
{
  public static class VectorExtensions
  {
    public static Vector3Int MapToInt(this Vector3 vector, Func<float, int> map)
    {
      return new Vector3Int(map(vector.x), map(vector.y), map(vector.z));
    }

    public static Vector3Int FloorToInt(this Vector3 vector) => MapToInt(vector, Mathf.FloorToInt);

    public static Vector3Int CeilToInt(this Vector3 vector) => MapToInt(vector, Mathf.CeilToInt);

    public static (int x, int y, int z) ToTup(this Vector3Int vec)
    {
      return (vec.x, vec.y, vec.z);
    }

    public static Quaternion ToAxisRotation(this Vector3 vec)
    {
      return Quaternion.AngleAxis(vec.magnitude * Mathf.Rad2Deg, vec);
    }

    public static Vector3 ToBirdseye(this Vector2 input)
    {
      return new Vector3(input.x, 0, input.y);
    }
  }
}
