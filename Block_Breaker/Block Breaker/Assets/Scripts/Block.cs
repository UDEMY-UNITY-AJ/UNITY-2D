using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config Params
    [SerializeField] AudioClip breakSound;
    [SerializeField] Sprite[] hitSprites;

    // Cached Reference
    Level level;
    GameStatus gameStatus;

    // State Vars
    [SerializeField] int timesHit; // TODO only serialized for  debugging

    private void Start() {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (gameObject.tag == "Breakable") {
            level.CountBlocks();

        }
    }

    // collision var = gameObject theat hit this object.
    private void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject.tag == "Breakable") {
            HandleHit();
        }
    }

    private void HandleHit() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
        
    }

    private void DestroyBlock() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        gameStatus.AddToScore();
        level.BlockDestroyed();
    }
}
