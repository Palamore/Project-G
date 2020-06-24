using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private GameObject Player;
    private BoxCollider2D Coll;

    void Start()
    {
        Player = LobbyController.GetInstance().GetPlayerObject();
        Coll = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y < gameObject.transform.position.y + 0.2f)
        {
            Coll.enabled = false;
        }
        else
        {
            Coll.enabled = true;
        }
    }
}
