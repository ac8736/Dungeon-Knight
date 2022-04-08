using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemController : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent _agent;  
    public Animator animator;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        animator.SetFloat("Walk", 1);
        StartCoroutine(Attack());
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        
    }

    IEnumerator Attack() {
        while (true) {
            yield return new WaitForSeconds(0.3f);
            _agent.destination = player.transform.position;
            print(Vector3.Distance(player.transform.position, transform.position));
            if (Vector3.Distance(player.transform.position, transform.position) < 5) {
                animator.SetFloat("Walk", 0);
                animator.SetTrigger("Hit");
                if (Vector3.Distance(player.transform.position, transform.position) < 5) {
                    player.GetComponent<PlayerHealth>().TakeDamage(10);
                }
            }
        }
    }
}
