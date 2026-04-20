using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnSceneChange;

    private void Start()
    {
        OnSceneChange ??= new UnityEvent();
    }

    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        OnSceneChange.Invoke();
    }
    
    
}
