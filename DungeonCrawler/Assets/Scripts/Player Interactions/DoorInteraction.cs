using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public TextMeshProUGUI texts;
    public Transform door;
    public string level;
    void Update()
    {
        if (Vector3.Distance(transform.position, door.position) < 10)
        {
            texts.text = "Press E to Enter";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(level);
            }
        } else {
            texts.text = "";
        }
    }
}
