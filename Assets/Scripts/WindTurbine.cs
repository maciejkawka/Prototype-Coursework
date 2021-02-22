
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : MonoBehaviour
{
    public float rotateSpeed;
    public float windPower;
    public GameObject player1;
    public GameObject player2;

    public bool isWindEnabled = false;

    void EnableWind(bool enable)
    {
        isWindEnabled = enable;
    }

    void SetSpeed(float speed)
    {
        rotateSpeed = speed;
    }

    void Start()
    {
        rotateSpeed = 0f;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

        if (isWindEnabled)
            Wind();
    }


    void Wind()
    {
        Vector3 player2Pos = player2.transform.position;
        Vector3 player1Pos = player1.transform.position;

        Vector3 player2Dir = (player2Pos - transform.position).normalized;
        Vector3 player1Dir = (player1Pos - transform.position).normalized;

        RaycastHit ray;
        if (Physics.Raycast(transform.position, player1Dir, out ray))
        {
            if (ray.collider.gameObject.tag == "Player")
                player1.GetComponent<Rigidbody>().AddForce(windPower * player1Dir);
        }

        if (Physics.Raycast(transform.position, player2Dir, out ray))
        {
            if (ray.collider.gameObject.tag == "Player")
                player2.GetComponent<Rigidbody>().AddForce(windPower * player2Dir);
        }
    }
}
