using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStage : StateMachineBehaviour
{
    public float stageTime;
    public GameObject[] tampolines;
    public GameObject[] rings;

    float timer;
 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0.0f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer >= stageTime)
            animator.SetTrigger("NextStage");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("NextStage");
    }
}
