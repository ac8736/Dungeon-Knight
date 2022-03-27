using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    NavMeshAgent _navAgent;
    Camera mainCam;
    public float range = 10f;
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
                _navAgent.destination = hit.point;
                if (hit.collider.tag == "Enemy") {
                    isAttacking = true;
                    enemy = hit.collider.gameObject;
                } else {
                    isAttacking = false;
                }
            }
        }
        if (isAttacking) {
            if (enemy != null) {
                if (Vector3.Distance(transform.position, enemy.transform.position) < range) {
                    print(Vector3.Distance(transform.position, enemy.transform.position));
                    Destroy(enemy);
                }
            }
        }
    }
}
