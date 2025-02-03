using UnityEngine;

/// <summary>
/// Integer polygon
/// </summary>
public class IPoly
{
  public readonly Vector3Int[] vertices;

  public IPoly(Vector3Int[] vertices)
  {
    this.vertices = vertices;
  }

  public (Vector3Int a, Vector3Int b)[] Edges()
  {
    return vertices.Edges();
  }
}
