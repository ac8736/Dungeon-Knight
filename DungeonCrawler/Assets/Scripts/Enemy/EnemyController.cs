using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Animator _animator;
    [HideInInspector] public bool gotHit = false;
    public Transform player;
    NavMeshAgent _agent;
    bool isAttacking = false;
    public float attackRange = 20f;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        _animator.SetFloat("speed", _agent.velocity.magnitude);
        if (gotHit) {
            gotHit = false;
            StopAllCoroutines();
            Destroy(this.gameObject);
        }
        if (Vector3.Distance(transform.position, player.position) < attackRange) {
            isAttacking = true;
            StartCoroutine(Attack());
        } else {
            StopAllCoroutines();
        }
        
    }
    IEnumerator Attack() {
        while (true) {
            yield return new WaitForSeconds(0.5f);
            _agent.destination = player.position;
        }
    }
}
