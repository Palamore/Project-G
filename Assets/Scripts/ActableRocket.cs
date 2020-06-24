using UnityEngine;
using System.Collections;

public class ActableRocket : ActableScript
{

    public GameObject stageSelector;
    
    private Transform parentCanvasTransform;



    // Use this for initialization
    void Start()
    {
        parentCanvasTransform = FindObjectOfType<Canvas>().gameObject.transform;
        actableSpriteObject.SetActive(false);
    }

    public void PopUpStageSelecter()
    {
        Instantiate(stageSelector, parentCanvasTransform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
