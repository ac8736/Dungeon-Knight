using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Items : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && GlobalVars.healthPotions < 5) {
            GlobalVars.healthPotions ++;
            Destroy(gameObject);
        }
    }
}
