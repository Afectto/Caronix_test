using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    void Awake()
    {
        //Singleton
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    
    public void LoadNextScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
    {
        SceneManager.LoadSceneAsync(sceneName, mode);
        
        SaveLoadSystem.Instance.SaveGame();
    }
    
    public void UnloadOverlayScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}