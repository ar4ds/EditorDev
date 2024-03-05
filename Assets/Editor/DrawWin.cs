using UnityEngine;
using UnityEditor;

public class DrawWin : EditorWindow
{
    public static bool isOpen = false;
    private GameObject nodeMgr;
    private void OnGUI()
    {
        titleContent = new GUIContent("»æÖÆÖÐ...");
        minSize = maxSize = new Vector2(200, 50);
        EditorGUILayout.BeginVertical();
        if (GUILayout.Button("Done!"))
            Close();
        EditorGUILayout.EndVertical();
    }

    private void Update()
    {
        Selection.activeObject = nodeMgr;
    }

    private void CreateGUI()
    {
        isOpen = true;
        nodeMgr = FindObjectOfType<DrawComponent>().gameObject;
    }

    private void OnDestroy()
    {
        isOpen = false;
    }
}
