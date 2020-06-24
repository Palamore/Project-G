using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour
{


    private LoadManager LM;
    // Use this for initialization
    void Start()
    {
        LM = LoadManager.GetInstance();
        LM.SetTargetSceneStr("PlanetSlime");
    }

    public void LaunchToPlanet()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void ShutDown()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
