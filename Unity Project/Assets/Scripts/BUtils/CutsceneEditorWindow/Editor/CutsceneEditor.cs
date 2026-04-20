using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CutsceneEditor : EditorWindow
{
    private string cutsceneName;
    private int cutsceneIndex = 1;
    private float cutsceneRuntime = 30.0f;
    
    public GameObject testObject;
    public Transform waypoint1;
    public Transform waypoint2;

    private float lerpAmount = 0.0f;
    

    [MenuItem("Team Fingus/Cutscenes/Cutscene Editor")]
    public static void ShowWindow()
    {
        CutsceneEditor window = GetWindow<CutsceneEditor>();
        window.titleContent = new GUIContent("Cutscene Editor");
        
    }

    private void OnGUI()
    {
        GUILayout.Label("Cutscene Editor", EditorStyles.boldLabel);
        
        cutsceneName = EditorGUILayout.TextField("Cutscene Name", cutsceneName);
        EditorGUILayout.Space();
        cutsceneIndex = EditorGUILayout.IntField("Cutscene Index", cutsceneIndex);
        cutsceneRuntime = EditorGUILayout.FloatField("Cutscene Runtime", cutsceneRuntime);
        
        testObject = EditorGUILayout.ObjectField("Test Object", testObject, typeof(GameObject), true) as GameObject;
        waypoint1 = EditorGUILayout.ObjectField("Waypoint 1", waypoint1, typeof(Transform), true) as Transform;
        waypoint2 = EditorGUILayout.ObjectField("Waypoint 2", waypoint2, typeof(Transform), true) as Transform;
        
        
        EditorGUILayout.Space();

        if (GUILayout.Button("Save Cutscene"))
        {
            SaveCutscene();
        }
        
        lerpAmount = EditorGUILayout.Slider(lerpAmount, 0.0f, 1.0f);
        
        
    }

    private void Update()
    {
        if (testObject == null || waypoint1 == null || waypoint2 == null)
            return;
        
        testObject.transform.position = Vector3.Lerp(waypoint1.position, waypoint2.position, lerpAmount);
    }
    
    
    private void SaveCutscene()
    {
        if (cutsceneName == string.Empty)
        {
            Debug.LogError("Invalid Cutscene Name");
            return;
        }

        if (cutsceneIndex <= 0)
        {
            Debug.LogError("Invalid Cutscene Runtime");
            return;
        }
        
        
    }
}
