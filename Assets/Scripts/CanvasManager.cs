using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour
{

    public Text turnLabel, winLabel;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        winLabel.enabled = false;

        if (startButton == true)
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("Level")); //add listener with specific parameters
            Time.timeScale = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.player1Turn == true)
        {
            turnLabel.text = "Turn: Player 1";
        }
        else
        {
            turnLabel.text = "Turn: Player 2";
        }
    }
}
