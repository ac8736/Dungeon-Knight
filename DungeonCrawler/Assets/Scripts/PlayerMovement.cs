using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent _navAgent;
    Camera mainCam;
    [HideInInspector] public bool canMove = true;
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }

    void Update() {
        if (canMove) {
            if (Input.GetMouseButtonDown(1)) {
                RaycastHit hit;
                if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                    _navAgent.destination = hit.point;
                }
            }
        }
    }
}