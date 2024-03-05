using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DrawComponent))]
public class DrawController : Editor
{
    private static List<GameObject> nodes = new List<GameObject>();

    private void OnSceneGUI()
    {
        if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
            TryDrawPoint();
    }

    void TryDrawPoint()
    {
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = hit.point;
            go.name = $"node_{nodes.Count}";
            nodes.Add(go);
        }
    }

    public override void OnInspectorGUI()
    {
        var id = serializedObject.FindProperty("id");
        EditorGUILayout.PropertyField(id, new GUIContent("HelloID"));
        serializedObject.Update();
        if (DrawWin.isOpen)
        {
            if (GUILayout.Button("End Draw"))
            {
                var win = EditorWindow.GetWindow<DrawWin>();
                win.Close();
            }
        }
        else
        {
            if (GUILayout.Button("Start Draw"))
            {
                var win = EditorWindow.GetWindow<DrawWin>();
                win.Show();
            }
        }
        if (GUILayout.Button("Clear All"))
        {
            ClearAllPoints();
        }
    }

    private void ClearAllPoints()
    {
        nodes.ForEach(x => { GameObject.DestroyImmediate(x); });
        nodes.Clear();
    }
}
