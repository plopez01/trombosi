using UnityEngine;
using UnityEditor;

public class DebugMenu : EditorWindow
{

    // Add menu named "My Window" to the Window menu
    [MenuItem("Debug/Anticoagulant")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        DebugMenu window = (DebugMenu) GetWindow(typeof(DebugMenu));
        window.Show();
    }

    void OnGUI()
    {
        if (Application.isPlaying)
        {
            GUILayout.Label("Test Functoins", EditorStyles.boldLabel);


           

        } else
        {
            EditorGUILayout.HelpBox("Debug utils are only available in playmode", MessageType.Info);
        }
        
    }
}
