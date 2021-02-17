using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject player1;

    public GameObject playerText;
    public GameObject playerText1;

    int playersCounter;


    void Start()
    {
        playersCounter = 2;
    }
    void Update()
    {
        if(playersCounter==1)
        {

        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            
        }
    }



}
