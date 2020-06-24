using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    private static LobbyController instance;

    public Joystick joystick;
    public Button actBtn;
    public Sprite[] charSprites = new Sprite[3];
    public AudioSource actSound;

    private float speed = 0.1f;
    private string targetAct;
    private string charType;
    private int charIndex;
    private LoadManager LM;
    
    public static LobbyController GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<LobbyController>();
        }
        return instance;
    }

    public GameObject GetPlayerObject()
    {
        return gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        actBtn.interactable = false;
        charType = "Char1";
        charIndex = 0;
        actSound = SoundManager.GetInstance().actSound;
        LM = LoadManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        Move();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Actable")
        {
            targetAct = coll.gameObject.GetComponent<ActableScript>().actionStr;
            actBtn.interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Actable")
        {
            targetAct = null;
            actBtn.interactable = false;
            coll.gameObject.GetComponent<ActableScript>().SetActableSpriteFalse();
        }
    }

    

    private void Move()
    {
        float v = joystick.GetVerticalValue();
        float h = joystick.GetHorizontalValue();
        transform.Translate(h * speed, 0.0f, 0.0f);
    }

    public void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 330.0f);
    }

    public void Act()
    {
        actSound.Play();
        switch(targetAct)
        {
            case "Rocket":
                GameObject nearestOne0 = FindNearestActableObject();
                ActableRocket Rocket = nearestOne0.GetComponent<ActableRocket>();
                LM.SetCharIndex(charIndex);
                Rocket.PopUpStageSelecter();
                break;
            case "Char1":
                GameObject nearestOne1 = FindNearestActableObject();
                ActableChar c1 = nearestOne1.GetComponent<ActableChar>();
                string mine1 = charType;
                charType = "Char1";
                c1.SetActableSprite(charIndex);
                charIndex = 0;
                c1.actionStr = mine1;
                c1.gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                GetComponent<SpriteRenderer>().sprite = charSprites[0];
                break;
            case "Char2":
                GameObject nearestOne2 = FindNearestActableObject();
                ActableChar c2 = nearestOne2.GetComponent<ActableChar>();
                string mine2 = charType;
                charType = "Char2";
                c2.SetActableSprite(charIndex);
                charIndex = 1;
                c2.actionStr = mine2;
                c2.gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                GetComponent<SpriteRenderer>().sprite = charSprites[1];
                break;
            case "Char3":
                GameObject nearestOne3 = FindNearestActableObject();
                ActableChar c3 = nearestOne3.GetComponent<ActableChar>();
                string mine3 = charType;
                charType = "Char3";
                c3.SetActableSprite(charIndex);
                charIndex = 2;
                c3.actionStr = mine3;
                c3.gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                GetComponent<SpriteRenderer>().sprite = charSprites[2];
                break;
            default: break;
        }
    }

    private GameObject FindNearestActableObject()
    {
        GameObject[] actables = GameObject.FindGameObjectsWithTag("Actable");
        float shortestDist = Mathf.Infinity;
        GameObject nearestOne = null;
        foreach(GameObject actable in actables)
        {
            float dist = Vector2.Distance(transform.position, actable.transform.position);
            if(dist < shortestDist)
            {
                shortestDist = dist;
                nearestOne = actable;
            }
        }
        return nearestOne;
    }

}
