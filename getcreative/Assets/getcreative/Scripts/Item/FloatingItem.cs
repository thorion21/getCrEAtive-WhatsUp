using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    [Range(0f, 3f)]
    public float frequency;

    [Range(0f, 3f)]
    public float amplitude;

    private void Start()
    {
        frequency = 1.2f;
        amplitude = 0.06f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude,
            0f);
    }
}
