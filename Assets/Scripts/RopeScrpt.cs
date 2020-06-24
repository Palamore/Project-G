using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScrpt : MonoBehaviour
{
    public GameObject ropeShooter;
    public GameObject Hook; // Asset Reference
    public Joystick joystick;
    public GameObject hook; // GameObject in GameScene

    public LineRenderer lineRenderer;


    void Start()
    {

    }

    void Update()
    {

    }

    public void Fire(Vector3 HV)
    {
        if (hook != null)
        {
            Destroy(hook);
            ropeShooter.GetComponent<SpringJoint2D>().enabled = false;
        }
        
        Vector3 firePosition = transform.position;

        hook = (GameObject)Instantiate(Hook, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        
        throwHook throwHook = hook.GetComponent<throwHook>();
        throwHook.ropeShooter = ropeShooter;
        throwHook.FiredVector = HV;
        if(throwHook.FiredVector == Vector3.zero)
        {
            throwHook.FiredVector = Vector3.up;
        }
        lineRenderer.enabled = false;
        throwHook.lineRenderer = lineRenderer;
    }

    public void UnHook()
    {
        if(hook != null)
        {
            Destroy(hook);
            ropeShooter.GetComponent<SpringJoint2D>().enabled = false;
            lineRenderer.enabled = false;
        }
    }


}
