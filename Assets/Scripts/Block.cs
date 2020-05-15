using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config Variables;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject particleVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cache Variables;
    Level level;
    GameStatus status;

    // State Variables
    [SerializeField] int timesHit; //Serialized for debug propuses

    public void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        status = FindObjectOfType<GameStatus>();
        if (tag.Contains("Breakable"))
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag.Contains("Breakable"))
        {
            HandleDestoy();
        }
    }

    private void HandleDestoy()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing" + gameObject.name);
        }
    }

    private void CollisionPaticleEffect()
    {
        GameObject sparkles = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }


    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        CollisionPaticleEffect();
        Destroy(gameObject);
        status.AddScore();
        level.BlockDestroyed();
    }
}
