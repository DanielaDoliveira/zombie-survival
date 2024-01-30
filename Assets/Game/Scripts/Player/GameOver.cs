using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;

    void Start()
    {
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void ReloadScene()
    {
        int scene_to_reload = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(scene_to_reload);
    }
}
