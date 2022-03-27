using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyHunter : MonoBehaviour
{
    NavMeshAgent _navAgent;
    GameObject player;
    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FindPlayer());
    }
    IEnumerator FindPlayer() {
        while (true) {
            yield return new WaitForSeconds(1);
            _navAgent.destination = player.transform.position;
        }
    }
}