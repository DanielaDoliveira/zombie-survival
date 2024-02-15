using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;
    public TextMeshProUGUI TextTimeToSurvival, TextMaxTimeToSurvival;
    private int minutes, seconds;
    private float save_points;

    void Start()
    {
        save_points = PlayerPrefs.GetFloat("SAVEPOINTS");
        GameOverPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGameOver()
    {


        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
        minutes = (int)Time.timeSinceLevelLoad / 60;
        seconds = (int)Time.timeSinceLevelLoad % 60;
        TextTimeToSurvival.text = "You Survival for: " + minutes + " min " + seconds + " sec";
        AdjustSavingPoints(minutes, seconds);
    }
    public void ReloadScene()
    {
        Debug.Log("clicked");
        int scene_to_reload = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(scene_to_reload);

    }
    private void AdjustSavingPoints(int min, int sec)
    {
        if (Time.timeSinceLevelLoad > save_points)
        {
            save_points = Time.timeSinceLevelLoad;
            TextMaxTimeToSurvival.text = string.Format("Your best time is: {0}min{1}sec", min, sec);
            PlayerPrefs.SetFloat("SAVEPOINTS", save_points);
        }
        else
        {
            min = (int)save_points / 60;
            sec = (int)save_points % 60;
            TextMaxTimeToSurvival.text = string.Format("Your best time is: {0}min{1}sec", min, sec);
        }
    }
}
