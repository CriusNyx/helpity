using System;

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
  }
}
