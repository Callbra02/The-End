using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Debug 2D Collider Visualization
/// Utilizes DrawGizmos - In a Very VERY nasty way -TODO: unfuck that
/// Accepts Box and Polygon 2D Colliders
/// </summary>
public class BoundaryVisualizer : MonoBehaviour
{
    private GameObject[] boundaryObjects;
    private List<BoxCollider2D> boundaryColliders;
    private List<PolygonCollider2D> boundaryPolygonColliders;

    [Header("DEBUG - COLLIDER VISUALIZATION")] 
    [SerializeField] private bool ToggleVisualization = false;

    void OnDrawGizmos()
    {
        if (!ToggleVisualization)
            return;
        
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        for (int i = 0; i < rootObjects.Length; i++)
        {
            BoxCollider2D boxCollider = rootObjects[i].GetComponent<BoxCollider2D>();
            PolygonCollider2D polygonCollider = rootObjects[i].GetComponent<PolygonCollider2D>();
            
            if (boxCollider != null)
                boundaryColliders.Add(boxCollider);
            
            if (polygonCollider != null)
                boundaryPolygonColliders.Add(polygonCollider);
        }
        
        Gizmos.color = Color.red;
        foreach (BoxCollider2D boxCollider in boundaryColliders)
        {
            DrawCollider(boxCollider); 
        }

        foreach (PolygonCollider2D polygonCollider in boundaryPolygonColliders)
        {
            DrawCollider(polygonCollider);
        }
    }

    void DrawCollider(BoxCollider2D boxCollider)
    {
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }
    
    void DrawCollider(PolygonCollider2D collider)
    {
        Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
    }
}
