using System;

namespace Helpity
{
  public static class Comparers
  {
    public static int Tuple2<T>((T, T) tuple1, (T, T) tuple2) where T : IComparable
    {
      var comp1 = tuple1.Item1.CompareTo(tuple2.Item1);
      if (comp1 != 0)
      {
        return comp1;
      }
      return tuple1.Item2.CompareTo(tuple2.Item2);
    }
  }
}
