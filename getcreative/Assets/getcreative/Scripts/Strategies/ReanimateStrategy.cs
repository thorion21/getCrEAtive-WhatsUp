using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReanimateStrategy : MonoBehaviour, IStrategy
{
    private Tracker tracker;

    public void Awake()
    {
        tracker = gameObject.GetComponentInParent<Tracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tracker.getCurrentState() == State.Reanimate)
        {

        }
    }

    public void execute()
    {
        Debug.Log("ReanimateStrategy exec");
    }
}
