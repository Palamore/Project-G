using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    private static LoadManager instance;
    public static LoadManager GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<LoadManager>();
        }
        return instance;
    }

    private string TargetSceneStr;
    private int charIndex;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1280, 720, true);

    }

    public void SetTargetSceneStr(string str)
    {
        TargetSceneStr = str;
    }

    public void LoadTargetScene()
    {
        SceneManager.LoadSceneAsync(TargetSceneStr);
    }

    public void SetCharIndex(int index)
    {
        charIndex = index;
    }

    public int GetCharIndex()
    {
        return charIndex;
    }



}
