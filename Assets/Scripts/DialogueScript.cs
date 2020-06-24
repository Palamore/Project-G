using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text content;

    void Start()
    {

    }

    public void SetContent(string str)
    {
        content.text = str;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
