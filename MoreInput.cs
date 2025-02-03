using UnityEngine;

public static class MoreInput
{
  public static float GetAxisInput(KeyCode negative, KeyCode positive)
  {
    float output = 0;
    if (Input.GetKey(negative))
    {
      output -= 1;
    }
    else if (Input.GetKey(positive))
    {
      output += 1;
    }
    return output;
  }
}
