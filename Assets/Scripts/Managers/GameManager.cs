using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private static GameManager instance;

    public GameObject dialogue;

    public static GameManager GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<GameManager>();
        }

        return instance;
    }

    public void MakeDialouge(string str)
    {
        Transform parentCanvas = GameObject.FindGameObjectWithTag("WorldCanvas").transform;
        GameObject popDialouge = Instantiate(dialogue, parentCanvas) as GameObject;
        popDialouge.GetComponent<DialogueScript>().SetContent(str);
        Destroy(popDialouge, 3.0f);
    }

    public void BackToLobby(float time)
    {
        Invoke("backToLobby", time);
    }
    private void backToLobby()
    {
        LoadManager.GetInstance().SetTargetSceneStr("Lobby");
        SceneManager.LoadScene("LoadingScene");
    }

    public void PopCredit()
    {
        MakeDialouge("Made By \nPalamore");
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1280, 720, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
