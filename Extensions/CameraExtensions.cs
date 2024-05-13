using UnityEngine;

namespace Helpity
{
  public static class CameraExtensions
  {
    public static Vector3[][] Faces(this Camera camera)
    {
      var matrix = camera.cameraToWorldMatrix * camera.projectionMatrix.inverse;

      var bounds = new Bounds(Vector3.zero, Vector3.one * 2f);

      return bounds.Faces().Map(face => face.Map(matrix.MultiplyPoint));
    }
  }
}
