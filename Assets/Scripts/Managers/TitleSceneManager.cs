using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject upperCover;
    public GameObject lowerCover;
    private int moveCnt;

    void Start()
    {
        moveCnt = 0;
        InvokeRepeating("CoverMove", 0.0f, 1.0f / 60.0f);   
    }

    void CoverMove()
    {
        moveCnt++;
        upperCover.transform.Translate(new Vector3(0.0f, 4.1f, 0.0f) / 60.0f);
        lowerCover.transform.Translate(new Vector3(0.0f, 4.1f, 0.0f) / 60.0f);
        if(moveCnt == 60)
        {
            CancelInvoke("CoverMove");
        }
    }

    public void GameStart()
    {
        LoadManager.GetInstance().SetTargetSceneStr("Lobby");
        SceneManager.LoadScene("LoadingScene");
    }

    public void PopCredit()
    {

    }
}
