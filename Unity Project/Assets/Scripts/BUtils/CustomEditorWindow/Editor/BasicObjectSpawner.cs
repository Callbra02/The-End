using UnityEngine;
using UnityEditor;

public class BasicObjectSpawner : EditorWindow
{
    private string objectBaseName = "";
    private int objectID = 1;
    private GameObject objectToSpawn;
    private float objectScale;
    private float spawnRadius = 5.0f;

    [MenuItem("Team Fingus/Basic Object Spawner")]
    public static void ShowWindow()
    {
        GetWindow(typeof(BasicObjectSpawner)); // GetWindow inherited from EditorWindow
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);
        
        objectBaseName = EditorGUILayout.TextField("Object Base Name", objectBaseName);
        objectID = EditorGUILayout.IntField("Object ID", objectID);
        objectScale = EditorGUILayout.Slider("Object Scale", objectScale, 0.5f, 3.0f);
        spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);
        objectToSpawn = EditorGUILayout.ObjectField("Object To Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Object"))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("Error: Assign object to spawn.");
            return;
        }

        if (objectBaseName == string.Empty)
        {
            Debug.LogError("Error: Assign object name to spawn.");
        }
        
        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(spawnCircle.x, 0.0f, spawnCircle.y);

        GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        newObject.name = objectBaseName + objectID;
        newObject.transform.localScale = Vector3.one * objectScale;

        objectID++;
    }
}
