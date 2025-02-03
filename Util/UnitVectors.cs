using System.Collections.Generic;
using UnityEngine;

public enum UnitVector
{
  l = 0,
  r = 1,
  b = 2,
  f = 3,
  d = 4,
  u = 5
}

public static class UnitVectors
{
  public static (Vector3 a, Vector3 b)[] Crosshair = new (Vector3 a, Vector3 b)[]
  {
    (Vector3.left, Vector3.right),
    (Vector3.down, Vector3.up),
    (Vector3.back, Vector3.forward)
  };

  public static Vector3[] Vectors = new Vector3[]
  {
    Vector3.left,
    Vector3.right,
    Vector3.back,
    Vector3.forward,
    Vector3.down,
    Vector3.up,
  };

  public static Vector3Int[] VectorInts = new Vector3Int[]
  {
    Vector3Int.left,
    Vector3Int.right,
    Vector3Int.back,
    Vector3Int.forward,
    Vector3Int.down,
    Vector3Int.up,
  };

  public static readonly IReadOnlyDictionary<UnitVector, Vector3> UnitVecToVec = new Dictionary<
    UnitVector,
    Vector3
  >()
  {
    { UnitVector.l, Vector3.left },
    { UnitVector.r, Vector3.right },
    { UnitVector.d, Vector3.down },
    { UnitVector.u, Vector3.up },
    { UnitVector.b, Vector3.back },
    { UnitVector.f, Vector3.forward },
  };

  public static readonly IReadOnlyDictionary<UnitVector, Vector3Int> UnitVecToVecInt =
    new Dictionary<UnitVector, Vector3Int>()
    {
      { UnitVector.l, Vector3Int.left },
      { UnitVector.r, Vector3Int.right },
      { UnitVector.d, Vector3Int.down },
      { UnitVector.u, Vector3Int.up },
      { UnitVector.b, Vector3Int.back },
      { UnitVector.f, Vector3Int.forward },
    };
}
