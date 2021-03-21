using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private PirateController player;
    public RuntimeAnimatorController playerAC;
    public RuntimeAnimatorController botAC;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player2").GetComponent<PirateController>();
        StartCoroutine("SelfDestroy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")
            && player.isReincarnated)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = botAC;
            Debug.Log("By my will, you will be ressurected");

            Destroy(gameObject);
        }
    }
}
