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
    public AudioClip attackSound;
    AudioSource audioSource;
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        audioSource = GetComponent<AudioSource>();
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
        if (Input.GetMouseButtonDown(1)) {
            StopAllCoroutines();
        }
    }
    IEnumerator initiateAttack(GameObject enemy) {
        while (true) {
            yield return new WaitForSeconds(0.2f);
            _navAgent.destination = enemy.transform.position;
            if (Vector3.Distance(transform.position, enemy.transform.position) < range) {
                _animator.SetBool("Attack", true);
                audioSource.PlayOneShot(attackSound, 0.2f);
                _navAgent.destination = transform.position;
                yield return new WaitForSeconds(0.2f);
                _animator.SetBool("Attack", false);
                enemy.GetComponent<EnemyController>().gotHit = true;
                StopAllCoroutines();
            }
        }
    }
}
