using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneController currentSceneController;
    
    void Start()
    {
        ErrorHelper.LogNullError(currentSceneController, "Scene Controller not found in GameManager! Try checking the GameManager object");
    }

    void Update()
    {
        HandleSceneController();
    }

    public void UpdateSceneController(SceneController newSceneController)
    {
        currentSceneController = newSceneController;
    }

    private void HandleSceneController()
    {
        // Break from logic if current scene controller does not exit
        if (currentSceneController == null)
        {
            return;
        }
        
        // Scene related background logic
    }
}
