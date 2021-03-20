using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReanimateStrategy : MonoBehaviour, IStrategy
{
    public void execute()
    {
        // Activate this object
        Debug.Log("ReanimateStrategy exec");
    }

    void Update()
    {
        // Instantiate monster, change behaviour
    }
}
