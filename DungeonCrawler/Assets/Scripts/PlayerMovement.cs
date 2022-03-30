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
    Vector3 pointPlace;
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        pointPlace = transform.position;
    }

    void Update() {
        if (canMove) {
            if (Input.GetMouseButtonDown(1)) {
                RaycastHit hit;
                if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                    _animator.SetTrigger("Walk");
                    pointPlace = hit.point;
                    _navAgent.destination = hit.point;
                }
            }
          //  print(Vector3.Distance(pointPlace, transform.position));
            if (Vector3.Distance(pointPlace, transform.position) < 0.1f) {
                _animator.SetTrigger("Stop");
            }
        }
    }
}