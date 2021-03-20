using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, -9.0f);
    }
}
