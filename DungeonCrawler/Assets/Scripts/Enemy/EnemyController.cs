using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Animator _animator;
    [HideInInspector] public bool gotHit = false;
    public GameObject player;
    NavMeshAgent _agent;
    public float attackRange = 20f;
    public bool followPlayer = true;
    bool dmgPlayer = false;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        _animator.SetFloat("speed", _agent.velocity.magnitude);
        if (gotHit) {
            gotHit = false;
            StopAllCoroutines();
            player.GetComponent<DoorInteraction>().enemyCount--;
            Destroy(this.gameObject);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < attackRange) {
            if (followPlayer)
                StartCoroutine(Attack());
        } else {
            StopAllCoroutines();
        }   
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            dmgPlayer = true;
            StopAllCoroutines();
            StartCoroutine(AttackAnim());
        }
    }
    private void OnTriggerExit(Collider other) {
        dmgPlayer = false;
    }
    IEnumerator AttackAnim() {
        while (dmgPlayer) {
            _agent.destination = transform.position;
            _animator.SetBool("attack", true);
            yield return new WaitForSeconds(0.2f);
            _animator.SetBool("attack", false);
            yield return new WaitForSeconds(0.05f);
           // print(Vector3.Distance(transform.position, player.transform.position));
            if (Vector3.Distance(transform.position, player.transform.position) < 4.2f) {
                player.GetComponent<PlayerHealth>().TakeDamage(10);
            }
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(Attack());
    }
    IEnumerator Attack() {
        while (true) {
            yield return new WaitForSeconds(0.5f);
            _agent.destination = player.transform.position;
        }
    }
}
