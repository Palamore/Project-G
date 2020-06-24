using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HookBtn : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    private PlayerController player;
    private throwHook hook;
    private bool onPointer;

    public void OnPointerUp(PointerEventData eventData)
    {
            onPointer = false;
    }
    //  Hooking = 1,
    //  Dodge = 2,
    //  Flying = 3
    public void OnPointerDown(PointerEventData eventData)
    {
        if(player.GetState() != 1)
        {
            onPointer = true;
            player.Hook();
            hook = FindObjectOfType<throwHook>().GetComponent<throwHook>();
        }
        else
        {
            if(hook == null)
            {
                hook = FindObjectOfType<throwHook>().GetComponent<throwHook>();
            }
            onPointer = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(onPointer)
        {
            hook.Wind();
        }
    }
}
