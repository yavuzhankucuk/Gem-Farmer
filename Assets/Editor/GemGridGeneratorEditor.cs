using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GemGridGenerator))]
public class GemGridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GemGridGenerator gridGenerator = (GemGridGenerator)target;

        if (GUILayout.Button("Generate Grid"))
        {
            gridGenerator.GenerateGemGrid();
        }
    }
}
