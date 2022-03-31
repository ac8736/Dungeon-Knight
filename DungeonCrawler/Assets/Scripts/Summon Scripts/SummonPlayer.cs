using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPlayer : MonoBehaviour
{
    public GameObject summonImage;
    public GameObject player;
    public float floatUntil = -160f;
    void Start()
    {
        player.SetActive(false);
    }
    private void FixedUpdate() {
        transform.position += new Vector3(0, .1f, 0);
        summonImage.transform.Rotate(0, 0, -1);
        if (transform.position.y > floatUntil)
        {
            StartCoroutine(summonPlayer());
        }
    }
    IEnumerator summonPlayer() {
        yield return new WaitForSeconds(.15f);
        player.SetActive(true);
        Destroy(gameObject);
    }
}
