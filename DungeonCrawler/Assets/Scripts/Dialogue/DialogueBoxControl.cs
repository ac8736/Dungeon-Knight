using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxControl : MonoBehaviour
{
    public Animator animator;
    public void open() {
        animator.SetBool("isOpen", true);
    }

    public void close() {
        animator.SetBool("isOpen", false);
    }
}
