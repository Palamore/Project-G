using UnityEngine;
using System.Collections;

public class ActableChar : ActableScript
{

    public Sprite[] actableSprites = new Sprite[3];

    public SpriteRenderer actableSprite;
    // Use this for initialization
    void Start()
    {
        actableSprite = actableSpriteObject.GetComponent<SpriteRenderer>();
        actableSpriteObject.SetActive(false);
    }

    public void SetActableSprite(int index)
    {
        actableSprite.sprite = actableSprites[index];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
