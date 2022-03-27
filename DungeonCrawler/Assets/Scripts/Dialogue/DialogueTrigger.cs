using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;
    [HideInInspector] public bool inDialogue = false;
    private bool triggered = false;
    private NavMeshAgent _navAgent;

    void Start()
    {
        _navAgent = player.GetComponent<NavMeshAgent>();
    }
    private void Update() {
        if (!triggered) {
            if (Vector3.Distance(player.transform.position, transform.position) < 10) {
                TriggerDialogue();
                triggered = true;
                _navAgent.isStopped = true;
            }
        }
        if (inDialogue) {
            if (Input.GetKeyDown(KeyCode.E)) {
                FindObjectOfType<IntroDialogue>().DisplayNextSentence();
            }
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<IntroDialogue>().StartDialogue(dialogue);
        inDialogue = true;
        player.GetComponent<PlayerMovement>().canMove = false;
    }
}
