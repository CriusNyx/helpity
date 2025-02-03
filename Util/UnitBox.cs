using System.Collections.Generic;
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

    public static readonly Vector3 pmm = new Vector3
    {
      x = 1,
      y = -1,
      z = -1
    };

    public static readonly Vector3 mpm = new Vector3()
    {
      x = -1,
      y = 1,
      z = -1
    };

    public static readonly Vector3 ppm = new Vector3()
    {
      x = 1,
      y = 1,
      z = -1
    };

    public static readonly Vector3 mmp = new Vector3()
    {
      x = -1,
      y = -1,
      z = 1
    };

    public static readonly Vector3 pmp = new Vector3()
    {
      x = 1,
      y = -1,
      z = 1
    };

    public static readonly Vector3 mpp = new Vector3()
    {
      x = -1,
      y = 1,
      z = 1
    };

    public static readonly Vector3 ppp = new Vector3()
    {
      x = 1,
      y = 1,
      z = 1
    };

    public static readonly Vector3[] vertices = new[] { mmm, pmm, mpm, ppm, mmp, pmp, mpp, ppp };

    public static readonly (Vector3, Vector3)[] edges = new[]
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

    public static readonly Vector3[] leftFace = new[] { mmp, mpp, mpm, mmm };
    public static readonly Vector3[] rightFace = new[] { pmm, ppm, ppp, pmp };
    public static readonly Vector3[] downFace = new[] { mmp, mmm, pmm, pmp };
    public static readonly Vector3[] upFace = new[] { mpm, mpp, ppp, ppm };
    public static readonly Vector3[] backFace = new[] { mmm, mpm, ppm, pmm };
    public static readonly Vector3[] forwardFace = new[] { pmp, ppp, mpp, mmp };

    public static readonly Vector3[][] faces = new[]
    {
      leftFace,
      rightFace,
      downFace,
      upFace,
      backFace,
      forwardFace,
    };

    public static readonly IReadOnlyDictionary<UnitVector, Vector3[]> directionToFace =
      new Dictionary<UnitVector, Vector3[]>()
      {
        { UnitVector.l, leftFace },
        { UnitVector.r, rightFace },
        { UnitVector.d, downFace },
        { UnitVector.u, upFace },
        { UnitVector.b, backFace },
        { UnitVector.f, forwardFace },
      };
  }
}
