using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActableScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string actionStr;

    public GameObject actableSpriteObject;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            actableSpriteObject.SetActive(true);
        }
    }
    public void SetActableSpriteFalse()
    {
        actableSpriteObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
