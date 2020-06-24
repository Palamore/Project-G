using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    private Vector3 aim;
    private Vector3 preAim;
    private float speed;
    private LineRenderer shotLineRend;
    private RaycastHit2D[] laserCasts = new RaycastHit2D[10];
    public Transform castPoint;
    private Color lineRendColor;



    void Start()
    {
        speed = 0.7f;
        Destroy(gameObject, 8.0f);
        Invoke("Fire", 1.2f);
    }

    void Awake()
    {
        shotLineRend = GetComponent<LineRenderer>();
        shotLineRend.SetPosition(0, transform.position);
        aim = Vector3.zero;
        lineRendColor = Color.red;
        lineRendColor.a = 0.5f;
        shotLineRend.startColor = lineRendColor;
        shotLineRend.endColor = lineRendColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (aim != Vector3.zero)
        {
            transform.Translate(aim * 0.2f * speed);
        }
    }

    public void SetAim(Vector3 v)
    {
        preAim = v;
        laserCasts = Physics2D.RaycastAll(transform.position, new Vector2(v.x, v.y));
        foreach(RaycastHit2D laserCast in laserCasts)
        {
            if(laserCast.collider.tag == "Wall")
            {
                castPoint.position = laserCast.point;
            }
        }
        shotLineRend.SetPosition(1, castPoint.position);
        
    }

    private void Fire()
    {
        aim = preAim;
        shotLineRend.enabled = false;
    }

    public void SetSpeed(float sp)
    {
        speed = sp;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerController.GetInstance().Hitted();
            Destroy(gameObject);
        }
    }
}
