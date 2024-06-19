namespace Helpity
{
  public static class TupleExtensions
  {
    public static (T, U) To2<T, U, V>(this (T a, U b, V c) tuple)
    {
      return (tuple.a, tuple.b);
    }
  }
}
