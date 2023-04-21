using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScene fadeScene;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToScene(string sceneName)
    {
        StartCoroutine(GoToSceneRoutine(sceneName));
    }

    public IEnumerator GoToSceneRoutine(string sceneName)
    {
        fadeScene.FadeOut();
        yield return new WaitForSeconds(fadeScene.duration);

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        float timer = 0;
        while (timer <= fadeScene.duration && !op.isDone) 
        {
            timer += Time.deltaTime;
            yield return null;
        }

        op.allowSceneActivation = true;
    }
}
