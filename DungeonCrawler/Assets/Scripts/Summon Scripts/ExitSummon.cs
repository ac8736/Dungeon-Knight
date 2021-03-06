using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ExitSummon : MonoBehaviour
{
    public int key = 1;
    public GameObject summonImage;
    public string levelToLoad;
    public Animator _animator;
    public GameObject player;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && key == 1) {
            player.GetComponent<PlayerMovement>().canMove = false;
            player.GetComponent<NavMeshAgent>().destination = transform.position;
            StartCoroutine(teleportPlayer());
        }
    }
    IEnumerator teleportPlayer() {
        yield return new WaitForSeconds(1f);
        _animator.SetTrigger("Summon");
        yield return new WaitForSeconds(2.5f);
        player.GetComponent<PlayerMovement>().canMove = true;
        SceneManager.LoadScene(levelToLoad);
    }
}
