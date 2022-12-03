using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("Full_R", false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("Full_R", true);
        }
    }
}
