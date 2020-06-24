using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public Image loadImage;

    public Sprite[] loadImages = new Sprite[12];


    // Start is called before the first frame update
    void Start()
    {
        LoadManager.GetInstance().LoadTargetScene();
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        yield return null;

        int i = 0;
        int j = 0;
        while (true)
        {
            loadImage.sprite = loadImages[i];
            i++;
            if (i == 12)
            {
                i = 0;
                j++;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

}
