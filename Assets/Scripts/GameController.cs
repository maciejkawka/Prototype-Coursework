using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject text1;
    public GameObject text2;   
    public GameObject resume1;
    public GameObject resume2;

    int stage;
    bool playerSwitch;



    void Start()
    {
        stage = 0;
        playerSwitch = true;
    }
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player1)
        {
            text1.GetComponent<Text>().text = "You Lost!!";
            text1.SetActive(true);

            text2.GetComponent<Text>().text = "You Win!!";
            text2.SetActive(true);

            PauseGame();
        }
        else if(other.gameObject == player2)
        {
            text2.GetComponent<Text>().text = "You Lost!!";
            text2.SetActive(true);

            text1.GetComponent<Text>().text = "You Win!!";
            text1.SetActive(true);

            PauseGame();
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        resume1.SetActive(false);
        resume2.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        resume1.SetActive(true);
        resume2.SetActive(true);
    }


}
