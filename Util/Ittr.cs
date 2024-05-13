using System;
using System.Collections.Generic;

namespace Helpity
{
  public static class Ittr
  {
    private static Func<int, bool> GenerateCond(int length, bool inclusive)
    {
      return inclusive ? (i) => i < length : (i) => i <= length;
    }

    public static IEnumerable<int> Range(int length, bool inclusive = false)
    {
      Func<int, bool> Cond = GenerateCond(length, inclusive);

      for (int i = 0; Cond(i); i++)
      {
        yield return i;
      }
    }

    public static IEnumerable<(int, int)> Range2(int len1, int len2, bool inclusive = false)
    {
      Func<int, bool> Cond1 = GenerateCond(len1, inclusive);
      Func<int, bool> Cond2 = GenerateCond(len2, inclusive);

      for (int i = 0; Cond1(i); i++)
      {
        for (int j = 0; Cond2(j); j++)
        {
          yield return (i, j);
        }
      }
    }

    public static IEnumerable<(int, int)> Span2(int start1, int end1, int start2, int end2)
    {
      for (int i = start1; i <= end1; i++)
      {
        for (int j = start2; j <= end2; j++)
        {
          yield return (i, j);
        }
      }
    }
  }
}
