using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Scene Transition Controller
public class TransitionController : MonoBehaviour
{
    public TransitionController Instance;

    public Scene goToScene;
    public Scene currentScene;

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
            DontDestroyOnLoad(this);
        }
        OnSceneChange.AddListener(UpdateCurrentScene);
    }

    // Overloaded GoToScene function, takes either a string or an index
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        OnSceneChange.Invoke();
    }

    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        OnSceneChange.Invoke();
    }

    // Updates currentScene on variable change
    private void UpdateCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene();
    }
}
