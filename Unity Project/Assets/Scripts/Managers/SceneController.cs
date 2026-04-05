using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public SceneController Instance;

    [HideInInspector] public UnityEvent OnSceneChange;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(this);
        }
        
        OnSceneChange ??= new UnityEvent();
    }

    private void ChangeScene(string sceneName)
    {
        OnSceneChange.Invoke();
        SceneManager.LoadScene(sceneName);
    }
    
    
}
