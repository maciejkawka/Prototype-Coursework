using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Vector3 force = new Vector3(900, 400, 0);
    public float disableTime = 0.5f;

    Animator animator;
    float timer = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"&& timer<=0)
        {
            timer=disableTime;
            Vector3 kickOff = transform.rotation * force;
            
            collision.gameObject.GetComponent<Rigidbody>().AddForce(kickOff, ForceMode.Impulse);
            collision.gameObject.GetComponent<PlayerMove>().SetJumping(true);

            animator.SetTrigger("Stepped");
        }
    }
}
