using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class IntroDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject player;
    public TextMeshProUGUI textDisplay;
    string npcName;
    private Queue<string> sentences;
    private bool initialDelay = true;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        dialogueBox.GetComponent<DialogueBoxControl>().open();
        sentences.Clear();
        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        npcName = dialogue.name;
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        if (initialDelay) {
            yield return new WaitForSeconds(.4f);
            initialDelay = false;
        }
        textDisplay.text = npcName + '\n';
        foreach (char letter in sentence.ToCharArray()) {
            textDisplay.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        initialDelay = true;
        player.GetComponent<PlayerMovement>().canMove = true;
        GetComponent<DialogueTrigger>().inDialogue = false;
        dialogueBox.GetComponent<DialogueBoxControl>().close();
        player.GetComponent<NavMeshAgent>().isStopped = false;
    }
}
