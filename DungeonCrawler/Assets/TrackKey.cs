using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TrackKey : MonoBehaviour
{
    public TextMeshProUGUI key;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        key.text = "Keys: " + GlobalVars.keys;
    }
}
