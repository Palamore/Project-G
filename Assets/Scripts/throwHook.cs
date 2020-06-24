using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwHook : MonoBehaviour
{

    public GameObject ropeShooter;

    GameObject curHook;
    public Vector3 FiredVector;

    private SpringJoint2D newRope;
    public LineRenderer lineRenderer;
    public Material lineMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FiredVector != Vector3.zero)
        {
            transform.Translate(FiredVector * 0.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if(newRope != null)
            {
                newRope.distance -= 0.15f;
            }
        }
        if(lineRenderer.enabled == true)
        {
            lineRenderer.SetPosition(1, ropeShooter.transform.position);
        }
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    public void Wind()
    {
        if (newRope != null)
        {
            newRope.distance -= 0.12f;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Wall")
        {
            FiredVector = Vector3.zero;
            Hit();
        }
    }

    

    void Hit()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (ropeShooter.GetComponent<SpringJoint2D>() == null)
        {
            newRope = ropeShooter.AddComponent<SpringJoint2D>();
        }
        else
        {
            newRope = ropeShooter.GetComponent<SpringJoint2D>();
        }
        newRope.enabled = true;
        newRope.enableCollision = true;
        newRope.frequency = 0.0f;
        newRope.distance = 3.0f;
        newRope.connectedAnchor = transform.position; 
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.enabled = true;
        GetComponent<CircleCollider2D>().enabled = false;
    }


}
