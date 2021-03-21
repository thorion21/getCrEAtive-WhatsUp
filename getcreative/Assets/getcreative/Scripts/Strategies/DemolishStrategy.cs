using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemolishStrategy : MonoBehaviour, IStrategy
{
    private Tracker tracker;

    public void Awake()
    {
        tracker = gameObject.GetComponentInParent<Tracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tracker.getCurrentState() == State.Demolish)
        {

        }
    }

    public void execute()
    {
        Debug.Log("Demolish Strategy exec");
    }
}
