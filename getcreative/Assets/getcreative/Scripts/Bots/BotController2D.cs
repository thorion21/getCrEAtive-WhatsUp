using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController2D : MonoBehaviour
{
    public AudioClip ouch;

    internal Collider2D _collider;
    internal AudioSource _audio;
    SpriteRenderer spriteRenderer;
    private GameObject playerEntity;

    public Bounds Bounds => _collider.bounds;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerEntity = GameObject.FindGameObjectsWithTag("Player")[1];
    }

    void Update()
    {
        Debug.Log("Eu inamic track player" + playerEntity.transform.position);
    }
}
