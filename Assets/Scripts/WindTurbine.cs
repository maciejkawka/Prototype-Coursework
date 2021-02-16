
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : MonoBehaviour
{
    public float rotateSpeed;
    public float windPower;
    public GameObject player;
    public GameObject player1;

    public bool isWindEnabled = false;

    void EnableWind(bool enable)
    {
        isWindEnabled = enable;
    }

    void SetSpeed(float speed)
    {
        rotateSpeed = speed;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime / rotateSpeed);

        if (isWindEnabled)
            Wind();
    }


    void Wind()
    {
        Vector3 player1Pos = player1.transform.position;
        Vector3 playerPos = player.transform.position;

        Vector3 player1Dir = (player1Pos - transform.position).normalized;
        Vector3 playerDir = (playerPos - transform.position).normalized;

        RaycastHit ray;
        if (Physics.Raycast(transform.position, playerDir, out ray))
        {
            if (ray.collider.gameObject.tag == "Player")
                player.GetComponent<Rigidbody>().AddForce(windPower * playerDir);
        }

        if (Physics.Raycast(transform.position, player1Dir, out ray))
        {
            if (ray.collider.gameObject.tag == "Player")
                player1.GetComponent<Rigidbody>().AddForce(windPower * player1Dir);
        }
    }
}
