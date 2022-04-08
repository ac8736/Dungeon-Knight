using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisappearCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DisappearCoroutine() {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
