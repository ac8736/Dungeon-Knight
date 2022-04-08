using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Potions : MonoBehaviour
{
    public TextMeshProUGUI potions;

    void Update()
    {
        potions.text = ": " + GlobalVars.healthPotions;    
    }
}
