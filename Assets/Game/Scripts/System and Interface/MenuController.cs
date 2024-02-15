using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject BtnExit;
    private float time = 0.3f;

    private void Start()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        BtnExit.SetActive(true);
#endif
    }
    public void LoadGame()
    {
        int _currentScene = SceneManager.GetActiveScene().buildIndex + 1;

        StartCoroutine(ChangeScene(_currentScene, time));

    }

    public void QuitGame()
    {
        StartCoroutine(LoadQuitGame(time));
    }
    IEnumerator ChangeScene(int scene, float timeToLoad)
    {
        yield return new WaitForSecondsRealtime(timeToLoad);
        SceneManager.LoadScene(scene);
    }
    IEnumerator LoadQuitGame(float timeToLoad)
    {
        yield return new WaitForSecondsRealtime(timeToLoad);
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}
