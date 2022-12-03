using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Map"))
        {
            Destroy(gameObject);
        }

        else if (other.CompareTag("Target"))
        {
            Animator animator = other.GetComponent<Animator>();
            animator.SetBool("hit", !animator.GetBool("hit"));
            Destroy(gameObject);
        }
    }
}
