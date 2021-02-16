using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRing : MonoBehaviour
{

    public float rotateSpeed;
    public bool clockWise;

    bool isRotating = true;

    public void EnableRotation(bool enable)
    {
        isRotating = enable;
    }


    void Update()
    {
        if(clockWise)
          transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime / rotateSpeed);
        else
          transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime / rotateSpeed);

    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            collision.gameObject.transform.parent = this.transform;
    }

}
