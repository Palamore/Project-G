using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSkillScript : BossScript
{
    static int DeathCount;
    private int fireCnt;
    public GameObject mommy;
    void Start()
    {
        fireAction[0] = true;
        fireAction[1] = true;
        fireAction[2] = true;
        patternTerm = 0.0f;
        state = State.Normal;
        playerTransform = PlayerController.GetInstance().GetPlayerObject().transform;
        animator = GetComponent<Animator>();
        DeathCount = 0;
        MaxHP = 100;
        HP = 10;
    }
    protected override void NormalPatternFire(int index)
    {
        aimPoint.position = transform.position +
            (playerTransform.position - transform.position).normalized;
        switch (index)
        {
            case 1:

                for (int i = 0; i < 2; i++)
                {
                    GameObject bull = (GameObject)Instantiate(defaultBullet, transform.position, Quaternion.identity);
                    bulletScript = bull.GetComponent<BossBulletScript>();
                    bulletScript.SetAim(aimPoint.position - transform.position);
                    aimRotationPart.Rotate(0.0f, 0.0f, 15.0f);
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    GameObject bull = (GameObject)Instantiate(defaultBullet, transform.position, Quaternion.identity);
                    bulletScript = bull.GetComponent<BossBulletScript>();
                    bulletScript.SetAim(aimPoint.position - transform.position);
                    aimRotationPart.Rotate(0.0f, 0.0f, -15.0f);
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    GameObject bull = (GameObject)Instantiate(defaultBullet, transform.position, Quaternion.identity);
                    bulletScript = bull.GetComponent<BossBulletScript>();
                    bulletScript.SetAim(aimPoint.position - transform.position);
                    aimRotationPart.Rotate(0.0f, 0.0f, 15.0f);
                }
                break;
            default: break;
        }
    }

    protected override void FirstPatternFire(int index)
    {
        aimPoint.position = transform.position + new Vector3(2.0f, 0.0f, 0.0f);
        switch (index)
        {
            case 1:
                for (float i = 0.0f; i < 9.0f; i++)
                {
                    GameObject bull = (GameObject)Instantiate(defaultBullet, transform.position, Quaternion.identity);
                    bulletScript = bull.GetComponent<BossBulletScript>();
                    bulletScript.SetAim((aimPoint.position - transform.position).normalized);
                    aimRotationPart.Rotate(0.0f, 0.0f, 20.0f);
                }
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                break;
            case 2:
                transform.Rotate(0.0f, 0.0f, 10.0f);
                for (float i = 0.0f; i < 8.0f; i++)
                {
                    GameObject bull = (GameObject)Instantiate(defaultBullet, transform.position, Quaternion.identity);
                    bulletScript = bull.GetComponent<BossBulletScript>();
                    bulletScript.SetAim((aimPoint.position - transform.position).normalized);
                    aimRotationPart.Rotate(0.0f, 0.0f, 20.0f);
                }
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                break;
            case 3:
                for (float i = 0.0f; i < 9.0f; i++)
                {
                    GameObject bull = (GameObject)Instantiate(defaultBullet, transform.position, Quaternion.identity);
                    bulletScript = bull.GetComponent<BossBulletScript>();
                    bulletScript.SetAim((aimPoint.position - transform.position).normalized);
                    aimRotationPart.Rotate(0.0f, 0.0f, 20.0f);
                }
                aimRotationPart.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                break;
            default: break;
        }
    }

    protected override void SecondPatternFire(int index)
    {
        aimPoint.position = transform.position + new Vector3(2.0f, -1.0f, 0.0f);
        switch (index)
        {
            case 1:
                fireCnt = 0;
                InvokeRepeating("LeftFire", 0.0f, 0.1f);
                break;
            case 2:
                aimPoint.position = transform.position + new Vector3(-2.0f, -1.0f, 0.0f);
                fireCnt = 0;
                InvokeRepeating("RightFire", 0.0f, 0.1f);
                break;
            case 3:
                fireCnt = 0;
                InvokeRepeating("LeftFire", 0.0f, 0.1f);
                break;
            default: break;
        }
    }
    void LeftFire()
    {
        fireCnt++;
        if (fireCnt == 19)
        {
            CancelInvoke("LeftFire");
        }
        GameObject bull = (GameObject)Instantiate(defaultBullet, transform.position, Quaternion.identity);
        bulletScript = bull.GetComponent<BossBulletScript>();
        bulletScript.SetAim((aimPoint.position - transform.position).normalized);
        aimRotationPart.Rotate(0.0f, 0.0f, 12.0f);
    }

    void RightFire()
    {
        fireCnt++;
        if (fireCnt == 19)
        {
            CancelInvoke("RightFire");
        }
        GameObject bull = (GameObject)Instantiate(defaultBullet, transform.position, Quaternion.identity);
        bulletScript = bull.GetComponent<BossBulletScript>();
        bulletScript.SetAim((aimPoint.position - transform.position).normalized);
        aimRotationPart.Rotate(0.0f, 0.0f, -12.0f);
    }

    protected override int ChangeState()
    {
        float rand = Random.Range(0.0f, 10.0f);
        if (rand <= 3.5f)
        {
            return 1;
        }
        else if (rand <= 6.5f)
        {
            return 2;
        }
        else
        {
            return 3;
        }

    }

    protected override void Death()
    {
        DeathCount++;
        if(DeathCount == 2)
        {
            mommy.SetActive(true);
        }
        Destroy(gameObject);
    }

}
