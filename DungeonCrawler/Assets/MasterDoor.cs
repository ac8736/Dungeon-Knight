using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterDoor : MonoBehaviour
{
    public int monsters;
    GameObject player;
    public TextMeshProUGUI texts;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (monsters == 0) {
            Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 10 && monsters > 0) {
            texts.text = "Kill all Enemies";
        }
    }
}
