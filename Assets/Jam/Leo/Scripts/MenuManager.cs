using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LevelSelect()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Credits()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
    }
}