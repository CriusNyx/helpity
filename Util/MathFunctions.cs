namespace Helpity
{
  public static class MathFunctions
  {
    public static float GaussianLike(float x)
    {
      return 1 / (1 + x * x);
    }
  }
}
