using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject summonCircle;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(summonBoss());
        }
    }
    IEnumerator summonBoss() {
        yield return new WaitForSeconds(.15f);
        summonCircle.GetComponent<Animator>().SetBool("summoning", true);
        yield return new WaitForSeconds(1f);
        summonCircle.GetComponent<Animator>().SetBool("summoning", false);
        boss.SetActive(true);
        Destroy(summonCircle);
    }
}
