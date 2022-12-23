using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine("destroyDelay");
        }
    }
    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
