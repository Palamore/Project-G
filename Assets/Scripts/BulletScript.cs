using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 aim;
    private float speed;

    void Start()
    {
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(aim != Vector3.zero)
        {
            transform.Translate(aim * 0.5f * speed);
        }
    }

    public void SetAim(Vector3 v)
    {
        aim = v;
    }

    public void SetSpeed(float sp)
    {
        speed = sp;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
