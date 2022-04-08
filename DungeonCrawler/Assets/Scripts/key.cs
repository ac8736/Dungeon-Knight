using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GlobalVars.keys++;
            door.GetComponent<ExitSummon>().key++;
            Destroy(gameObject);
        }
    }
}
