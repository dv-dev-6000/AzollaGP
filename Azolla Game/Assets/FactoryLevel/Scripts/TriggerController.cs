using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameObject animator;
    Animator doorAnimation;

    private void Start()
    {
        doorAnimation = animator.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trigger"))
        {
            doorAnimation.SetBool("Trigger", true);
            doorAnimation.Play("Door", 0);
        }
    }
}
