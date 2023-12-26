using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlMovement : MonoBehaviour
{

    [SerializedField]
    Joystick joystick;

    [SerializedField]
    Transform playerSprite;

    [SerializedField]
    Animator animator

    bool Movement;

    void FixedUpdate()
    {
        if(joystick.Horizontal != 0 || if(joystick.Vertical != 0)
        {
            playerSprite.position = new Vector3(joystick.Horizontal + transform.position.x, -1.54f,joystick.Vertical + transform.position.z);
            transform.LookAt(new Vector3(playerSprite.position.x, 0, playerSprite.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * Time.deltaTime);
            if(animator.GetBool("Walking") != true)
            {
                animator.SetBool("Walking", true);
            }
            Movement = true;
        }
        else if(Movement == true)
        {
            animator.SetBool("Walking", false);
            Movement = false;
        }
    }
}
