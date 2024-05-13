using UnityEngine;

namespace Helpity
{
  /// <summary>
  /// Represents a box with a position of zero and a size of 2.
  /// The distance from the center of the box to the center of each face is 1 unit.
  /// </summary>
  public static class UnitBox
  {
    public static Vector3 mmm = new Vector3()
    {
      x = -1,
      y = -1,
      z = -1
    };

    public readonly static Vector3 pmm = new Vector3
    {
      x = 1,
      y = -1,
      z = -1
    };

    public readonly static Vector3 mpm = new Vector3()
    {
      x = -1,
      y = 1,
      z = -1
    };

    public readonly static Vector3 ppm = new Vector3()
    {
      x = 1,
      y = 1,
      z = -1
    };

    public readonly static Vector3 mmp = new Vector3()
    {
      x = -1,
      y = -1,
      z = 1
    };

    public readonly static Vector3 pmp = new Vector3()
    {
      x = 1,
      y = -1,
      z = 1
    };

    public readonly static Vector3 mpp = new Vector3()
    {
      x = -1,
      y = 1,
      z = 1
    };

    public readonly static Vector3 ppp = new Vector3()
    {
      x = 1,
      y = 1,
      z = 1
    };

    public readonly static Vector3[] vertices = new[] { mmm, pmm, mpm, ppm, mmp, pmp, mpp, ppp };

    public readonly static (Vector3, Vector3)[] edges = new[]
    {
      // Bottom Face
      (mmm, pmm),
      (mmp, pmp),
      (mmm, mmp),
      (pmm, pmp),
      // Sides
      (mmm, mpm),
      (pmm, ppm),
      (mmp, mpp),
      (pmp, ppp),
      // Top Face
      (mpm, ppm),
      (mpp, ppp),
      (mpm, mpp),
      (ppm, ppp),
    };

    public readonly static Vector3[][] faces = new[]
    {
      // Left
      new[] { mmp, mpp, mpm, mmm },
      // Right
      new[] { pmm, ppm, ppp, pmp },
      // Bottom
      new[] { mmp, mmm, pmm, pmp },
      // Top
      new[] { mpm, mpp, ppp, ppm },
      // Back
      new[] { mmm, mpm, ppm, pmm },
      // Front
      new[] { pmp, ppp, mpp, mmp },
    };
  }
}
