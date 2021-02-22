using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    enum GameState
    {
        Start = 0,
        Gameplay = 1,
        Pause = 2,
        End = 3
    }

    public GameObject player1;
    public GameObject player2;
    public GameObject text1;
    public GameObject text2;
    public GameObject resume1;
    public GameObject resume2;
    public GameObject camera1;
    public GameObject camera2;


    bool playerSwitch;
    GameState state;


    void Start()
    {
        state = GameState.Start;
        playerSwitch = true;
        player1.GetComponent<PlayerMove>().EnablePlayer(playerSwitch);
        player2.GetComponent<PlayerMove>().EnablePlayer(!playerSwitch);
        Time.timeScale = 0;
    }
    void Update()
    {
        switch (state)
        {
            case GameState.Start: // Start
                StartState();
                break;
            case GameState.Gameplay: // Gameplay
                GameplayState();
                break;
            case GameState.Pause: // Pause
                PauseState();
                break;
            case GameState.End: ///End
                EndState();          
                break;
            default:
                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1)
        {
            text1.GetComponent<Text>().text = "You Lost!!";
            text1.SetActive(true);

            text2.GetComponent<Text>().text = "You Win!!";
            text2.SetActive(true);
            state = GameState.End;
            Time.timeScale = 0;
        }
        else if (other.gameObject == player2)
        {
            text2.GetComponent<Text>().text = "You Lost!!";
            text2.SetActive(true);

            text1.GetComponent<Text>().text = "You Win!!";
            text1.SetActive(true);
            state = GameState.End;
            Time.timeScale = 0;
        }
    }

    void StartState()
    {
        resume1.GetComponent<Text>().text = "Click T to Start";
        resume1.SetActive(true);
        resume2.GetComponent<Text>().text = "Click T to Start";
        resume2.SetActive(true);
        if (Input.GetKeyDown(KeyCode.T))
        {
            state = GameState.Gameplay;
            Time.timeScale = 1;
        }
    }

    void GameplayState()
    {
        resume1.SetActive(false);
        resume2.SetActive(false);

        if (Input.GetKeyDown(KeyCode.P))
        {
            state = GameState.Pause;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerSwitch = !playerSwitch;
            player1.GetComponent<PlayerMove>().EnablePlayer(playerSwitch);
            player2.GetComponent<PlayerMove>().EnablePlayer(!playerSwitch);

        }
    }

    void PauseState()
    {
        resume1.GetComponent<Text>().text = "Click P to Resume";
        resume1.SetActive(true);
        resume2.GetComponent<Text>().text = "Click P to Resume";
        resume2.SetActive(true);

        if (Input.GetKeyDown(KeyCode.P))
        {
            state = GameState.Gameplay;
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void EndState()
    {
        resume1.GetComponent<Text>().text = "Click R to Reset";
        resume2.GetComponent<Text>().text = "Click R to Reset";
        resume1.SetActive(true);
        resume2.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

}
