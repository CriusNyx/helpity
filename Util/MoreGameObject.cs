using UnityEngine;

public static class MoreGameObject
{
  public static GameObject Create(
    string name,
    Vector3? position = null,
    Quaternion? rotation = null,
    Transform parent = null
  )
  {
    var output = new GameObject(name);
    output.transform.parent = parent;
    output.transform.localPosition = position ?? Vector3.zero;
    output.transform.localRotation = rotation ?? Quaternion.identity;
    return output;
  }
}
