using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    private List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer sr;

    private float spriteDelayTime;
    private float delayTime = 0f;

    private int spriteAnimationIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprites.Count == 0)
            return;

        delayTime += Time.deltaTime;
        if (delayTime > spriteDelayTime)
        {
            delayTime = 0;
            sr.sprite = sprites[spriteAnimationIndex];
            spriteAnimationIndex++;

            if (spriteAnimationIndex > sprites.Count - 1)
            {
                spriteAnimationIndex = 0;
            }
        }
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime)
    {
        this.delayTime = float.MaxValue;
        spriteAnimationIndex = 0;
        sprites = argSprites;
        spriteDelayTime = delayTime;
    }
}