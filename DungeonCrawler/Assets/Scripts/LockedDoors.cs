using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedDoors : MonoBehaviour
{
    GameObject player;
    public TextMeshProUGUI texts;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        texts.text = "work";
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10)
        {
            print("close");
            if (GlobalVars.keys > 0)
            {
                texts.text = "Press E to Open With Key";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GlobalVars.keys--;
                    Destroy(gameObject);
                    texts.text = "";
                }
            } else {
                texts.text = "You need a key to open this door";
            }
        } else {
            texts.text = "";
        }
    }
}
