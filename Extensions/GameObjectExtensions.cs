using UnityEngine;

public static class GameObjectExtensions
{
  public static GameObject CreateChild(
    this GameObject gameObject,
    string name,
    Vector3? position = null
  )
  {
    var output = new GameObject(name);
    output.transform.parent = gameObject.transform;
    output.transform.localPosition = position ?? Vector3.zero;
    return output;
  }
}
