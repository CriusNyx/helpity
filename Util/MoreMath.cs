using System;
using UnityEngine;

namespace Helpity
{
  public static class MoreMath
  {
    public static (int, int)[] adjacencyMatrix = new[]
    {
      (-1, -1),
      (0, -1),
      (1, -1),
      (-1, 0),
      (0, 0),
      (1, 0),
      (-1, 1),
      (0, 1),
      (1, 1),
    };

    public static (int x, int y) Add2((int x, int y) a, (int x, int y) b) =>
      Combine2(a, b, (x, y) => x + y);

    public static (T x, T y) Combine2<T>((T x, T y) a, (T x, T y) b, Func<T, T, T> combine) =>
      (combine(a.x, b.x), combine(a.y, b.y));

    public static int PosMod(int x, int m)
    {
      return (x % m + m) % m;
    }

    /// <summary>
    /// Moves a value towards 0
    /// </summary>
    /// <param name="value"></param>
    /// <param name="delta"></param>
    /// <returns></returns>
    public static float UpdateLockout(float value, float delta)
    {
      return Mathf.MoveTowards(value, 0, delta);
    }
  }
}
