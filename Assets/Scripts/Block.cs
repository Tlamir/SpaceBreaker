using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip destroySound;
    [SerializeField] float DestroyDelay = 0.2f;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] Sprite[] hitSprite;
    // cached reference
    level level;
    //state variable
    [SerializeField] int timesHit; //Serialized for debug

    private void Start()
    {
        CountBreakbleBlocks();

    }

    private void CountBreakbleBlocks()
    {
        level = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag=="Breakable")
        {
            HandleHit();

        }
    }

    private void ShowNextHitSprite()
    {
        int spriteindex = timesHit - 1;
        if (hitSprite[spriteindex]!=null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteindex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array"+gameObject.name); 
        }
        
    }

    private void HandleHit()
    {
        int maxHits = hitSprite.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        FindObjectOfType<Gamestatus>().AddToScore();
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        Destroy(gameObject, DestroyDelay);
        level.BlockDestroyed();
    }
    private void TriggerSparklesVFX() 
    {
        GameObject sparkles = Instantiate(blockSparkleVFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }

}
