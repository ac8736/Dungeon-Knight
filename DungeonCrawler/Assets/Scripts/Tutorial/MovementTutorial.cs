using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MovementTutorial : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI text;
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            animator.SetTrigger("fade");
            StartCoroutine(delay());
        }
    }
    IEnumerator delay() {
        yield return new WaitForSeconds(1);
        text.GetComponent<Animator>().SetTrigger("spawn");
    }
}
