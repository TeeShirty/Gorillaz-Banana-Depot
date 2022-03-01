using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour
{
    Scene currentScene;

    public Text turnLabel, winLabel;
    public Button startButton, restartButton, exitButton;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        winLabel.enabled = false;
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        restartButton.enabled = false;

        if (startButton == true)
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("Level")); //add listener with specific parameters
            Time.timeScale = 1f;
        }

        if(restartButton == true)
        {
            restartButton.onClick.AddListener(() => SceneManager.LoadScene("Level"));
            Time.timeScale = 1f;
        }

        if(exitButton == true)
        {
            exitButton.onClick.AddListener(() => QuitGame());
        }


        if(currentScene.name == "Level")
        {
            startButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
        }
        
        if (currentScene.name == "MainMenu")
        {
            startButton.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current Scene is " + currentScene);

        if(GameManager.player1Turn == true)
        {
            turnLabel.text = "Turn: Player 1";
        }
        else
        {
            turnLabel.text = "Turn: Player 2";
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
