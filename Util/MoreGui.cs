using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Helpity
{
  public static class MoreGui
  {
    public static void Indent(Action content) => Indent(10, content);

    public static void Indent(int indentLength, Action content)
    {
      GUILayout.BeginHorizontal();
      GUILayout.Space(indentLength);
      GUILayout.BeginVertical();

      content();

      GUILayout.EndVertical();
      GUILayout.EndHorizontal();
    }

#if UNITY_EDITOR
    public static void SceneGUI(Action content)
    {
      Handles.BeginGUI();
      content();
      Handles.EndGUI();
    }
#endif
  }
}
