using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameManager gameManager;


    public void PlayTheGame()
    {
        gameManager.OnChangeState(GameManager.GameState.Playing);

    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        gameManager.OnChangeState(GameManager.GameState.Pause);
    }

    public void Respawn()
    {
        
        gameManager.player.transform.position = gameManager.spawnPoint.transform.position;
        gameManager.player.GetComponent<PlayerManager>().currentLife = 5;
        gameManager.player.GetComponent<PlayerManager>().nbOfArrows = 3;
        gameManager.player.GetComponent<PlayerManager>().SetHealth();
        gameManager.OnChangeState(GameManager.GameState.Playing);
    }
}
