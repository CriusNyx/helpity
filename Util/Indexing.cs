using Helpity;
using UnityEngine;

public static class Indexing
{
  public static Vector3Int ChunkIndex(this Vector3Int cellIndex, int ChunkSize)
  {
    return cellIndex.Map(x => (x - MoreMath.PosMod(x, ChunkSize)) / ChunkSize);
  }

  public static Vector3Int SubIndex(this Vector3Int cellIndex, int ChunkSize)
  {
    return cellIndex.Map(x => MoreMath.PosMod(x, ChunkSize));
  }
}
