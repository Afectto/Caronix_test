using UnityEngine;

public class ButtonNextScene : MonoBehaviour
{
    public void LoadSceneRequested(string sceneName)
    {
        SceneController.Instance.LoadNextScene(sceneName);
    }
}