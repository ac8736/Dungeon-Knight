using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent _navAgent;
    Camera mainCam;
    [HideInInspector] public bool canMove = true;
    public Animator _animator;
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }
    void Update() {
        _animator.SetFloat("walk", _navAgent.velocity.magnitude);
        if (canMove) {
            if (Input.GetMouseButtonDown(1)) {
                _animator.SetBool("Attack", false);
                RaycastHit hit;
                if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) 
                    if (hit.collider.tag != "Enemy") 
                        _navAgent.destination = hit.point;
            }
        }
    }
}