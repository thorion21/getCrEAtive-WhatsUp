using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Am nimerit");
            collision.gameObject.transform.position = new Vector3(1.25f, -0.360000014f, -1);
        }
    }
}
