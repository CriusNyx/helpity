namespace Helpity
{
  public static class StringArrayExtensions
  {
    public static string JoinLines(this string[] arr)
    {
      return string.Join("\n", arr);
    }
  }
}
