using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    NavMeshAgent _navAgent;
    public Animator _animator;
    Camera mainCam;
    public float range = 1f;
    private float distance;
    private GameObject enemy;
    [HideInInspector] public bool isAttacking = false;
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                if (hit.collider.tag == "Enemy") {
                    enemy = hit.collider.gameObject;
                    StartCoroutine(initiateAttack(hit.collider.gameObject));
                }
            }
        }
    }

    IEnumerator initiateAttack(GameObject enemy) {
        while (true) {
            yield return new WaitForSeconds(0.2f);
            _navAgent.destination = enemy.transform.position;
            if (Vector3.Distance(transform.position, enemy.transform.position) < range) {
                print(Vector3.Distance(transform.position, enemy.transform.position));
                _animator.SetBool("Attack", true);
                _navAgent.destination = transform.position;
                yield return new WaitForSeconds(0.2f);
                _animator.SetBool("Attack", false);
                yield return new WaitForSeconds(0.2f);
                enemy.GetComponent<EnemyController>().gotHit = true;
                StopAllCoroutines();
            }
        }
    }
}
