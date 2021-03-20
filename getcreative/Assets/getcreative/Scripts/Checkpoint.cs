using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject trackerObj;
    private Tracker tracker;
    public State stateValue;
    

    void Start()
    {
        tracker = trackerObj.GetComponent<Tracker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            tracker.announceEvent(stateValue);
            
        }
    }
}
