using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Items : MonoBehaviour
{
    //AudioSource _audioSource;
    void Start()
    {
        //_audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && GlobalVars.healthPotions < 5) {
            //_audioSource.Play();
            GlobalVars.healthPotions ++;
            Destroy(gameObject);
        }
    }
}
