using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Text winLabel;
    CanvasManager canvasManager;

    private void Start()
    {
        canvasManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            gameObject.SetActive(false);

            whoIsTheWinner();
        }

        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            //Destroy(gameObject);
            gameObject.SetActive(false);

            whoIsTheWinner();
        }
    }

    void whoIsTheWinner()
    {
        if (gameObject.CompareTag("PlayerOne"))
        {
            winLabel.enabled = true;
            winLabel.text = "Winner: Player 2";
            canvasManager.restartButton.gameObject.SetActive(true);
            canvasManager.exitButton.gameObject.SetActive(true);
            canvasManager.restartButton.enabled = true;

        }

        if (gameObject.CompareTag("PlayerTwo"))
        {
            winLabel.enabled = true;
            winLabel.text = "Winner: Player 1";
        }
    }
}