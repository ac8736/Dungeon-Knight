using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AttackTutorial : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("attack");
        }
    }
}
