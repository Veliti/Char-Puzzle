using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LosingCard))]
public class Button : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LosingCard want = (LosingCard)target;

        if (GUILayout.Button("ButtonWanted"))
        {
            want.OnButton();
        }
    }
}
