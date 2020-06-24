using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static LobbyManager instance;
    public static LobbyManager GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<LobbyManager>();
        }
        return instance;
    }

    void Start()
    {
        
    }

    public void LoadPlanetStr(string str)
    {
        LoadManager.GetInstance().SetTargetSceneStr(str);
        SceneManager.LoadScene("LoadingScene");
    }
}
