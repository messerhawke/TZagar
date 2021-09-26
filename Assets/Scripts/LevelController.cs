using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    int currentSceneIndex;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(currentSceneIndex - 1);
    }
    public void LoadSameScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
