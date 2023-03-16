using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject controller;
    public void LoadScene(string sceneName)
    {
        //Debug.Log("WE loading");
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        controller.SetActive(false);
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}