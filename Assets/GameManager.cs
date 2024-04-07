using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        Playing,
        Pause,
        EndMenu
    }

    public GameState currentState;

    public Canvas pauseMenu;
    public Canvas mainMenu;
    public Canvas deathMenu;
    public Canvas winMenu;

    public GameObject player;
    public GameObject spawnPoint;

    void Start()
    {
        OnChangeState(GameState.Menu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && currentState == GameState.Playing)
        {
            OnChangeState(GameState.Pause);
        }
    }

    public void OnChangeState(GameState state)
    {

        switch (state)
        {
            case GameState.Menu:
                MenuState();
                break;
            case GameState.Playing:
                PlayingState();
                break;
            case GameState.Pause:
                PauseState();
                break;
            case GameState.EndMenu:
                EndMenuState();
                break;
        }

    }

    void MenuState()
    {
        currentState = GameState.Menu;
        Time.timeScale = 0;
        //player.GetComponent<Canvas>().gameObject.SetActive(false);
    }

    void PlayingState()
    {
        Time.timeScale = 1;
        mainMenu.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(false);
        currentState = GameState.Playing;
        player.GetComponent<PlayerManager>().setUI();
    }

    void PauseState()
    {
        if (currentState == GameState.Playing)
        {
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
            currentState = GameState.Pause;
        }
        else if (currentState == GameState.Pause)
        {
            pauseMenu.gameObject.SetActive(false);
            currentState = GameState.Playing;
            OnChangeState(currentState);
            
        }
    }

    void EndMenuState()
    {
        Time.timeScale = 0;
        currentState = GameState.EndMenu;
        deathMenu.gameObject.SetActive(true);
    }

    public void Win()
    {
        Time.timeScale = 0;
        winMenu.gameObject.SetActive(true);

    }
}
