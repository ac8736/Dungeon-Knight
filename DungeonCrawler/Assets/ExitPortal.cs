using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class ExitPortal : MonoBehaviour
{
    public bool keyFound;
    public GameObject summonImage;
    public GameObject player;
    public float floatUntil = 7f;
    void Start()
    {
        
    }
    void Update() {
        if (Vector3.Distance(transform.position, player.transform.position) < 10) {
            if (keyFound) {
                player.GetComponent<NavMeshAgent>().destination = transform.position;
                StartCoroutine(summonPlayer());
            }
        }
    }
    IEnumerator summonPlayer() {
        yield return new WaitForSeconds(.15f);
        for (int i = 0; i < 10; i++) {
            transform.position += new Vector3(0, .1f, 0);
            summonImage.transform.Rotate(0, 0, -1);
        }
        SceneManager.LoadScene("Level 2");
    }
}
