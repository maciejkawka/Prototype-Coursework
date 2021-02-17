using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStage : StateMachineBehaviour
{



    GameObject[] obstacles = new GameObject[2];

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        obstacles[0] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obstacles[1] = GameObject.CreatePrimitive(PrimitiveType.Cube);

        foreach (GameObject g in obstacles)
        {
            float r = Random.Range(12f, 16f);
            float fi = Random.Range(0f, 360f);
            float x = r * Mathf.Cos(fi);
            float z = r * Mathf.Sin(fi);

            g.transform.position = new Vector3(x, 0f, z);
            g.transform.localScale = new Vector3(3f, 6f, 3f);
            g.transform.rotation = Quaternion.Euler(0,fi, 0);

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Object.Destroy(obstacles[0]);
        Object.Destroy(obstacles[1]);
    }
}
