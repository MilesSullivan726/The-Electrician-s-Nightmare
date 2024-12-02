using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayDeathSound();
        StartCoroutine(DestroyAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
