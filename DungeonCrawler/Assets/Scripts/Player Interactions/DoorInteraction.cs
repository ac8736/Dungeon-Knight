using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public TextMeshProUGUI texts;
    public int enemyCount;
    public Transform door;
    public string level;
    private void Start() {
        if (SceneManager.GetActiveScene().name != "Intro") {
            texts.text = "";
        } else {
            StartCoroutine(Text());
        }
    }
    void Update()
    {   
        if (Vector3.Distance(transform.position, door.position) < 10)
        {
            if (enemyCount > 0)
            {
                texts.text = "You have to kill all the enemies first";
            }
            else
            {
                texts.text = "Press E to Enter";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(level);
                }
            }
        } else {
            texts.text = "";
        }
    }

    IEnumerator Text() {
        yield return new WaitForSeconds(2);
        texts.text = "";
    }
}
