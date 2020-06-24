using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossScript : MonoBehaviour
{

    protected enum State
    {
        Normal = 1,
        PatternFir = 2,
        PatternSec = 3,
        PatternTrd = 4,
        Stun = 5
    }

    public GameObject defaultBullet;
    public Transform aimPoint;
    public Transform aimRotationPart;
    public int HP;
    public int MaxHP;
    public Slider HPBar;
    public Animator animator;
    public string st;

    protected State state;
    protected float patternTimer;
    protected bool[] fireAction = new bool[3];
    protected float patternTerm;
    public Transform playerTransform;
    protected int stateIndex;
    protected BossBulletScript bulletScript;

    // Start is called before the first frame update
    void Start()
    {
        fireAction[0] = true;
        fireAction[1] = true;
        fireAction[2] = true;
        patternTerm = 0.0f;
        state = State.PatternSec;
        playerTransform = PlayerController.GetInstance().GetPlayerObject().transform;
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        st = state.ToString();
        if(HP <= 0)
        {
            Death();
        }

        HPBar.value = (float)HP / (float)MaxHP;

        patternTerm += Time.deltaTime;
        stateIndex = (int)state;

        if(patternTerm > 1.0f && fireAction[0])
        {
            fireAction[0] = false;
            Fire1(stateIndex);
        }
        if(patternTerm > 4.3f && fireAction[1])
        {
            fireAction[1] = false;
            Fire2(stateIndex);
        }
        if(patternTerm > 7.6f && fireAction[2])
        {
            fireAction[2] = false;
            Fire3(stateIndex);
        }

        if(patternTerm  > 11.0f)
        {
            patternTerm = 0.0f;
            for(int i = 0; i < 3; i++)
            {
                fireAction[i] = true;
            }
            state = (State)ChangeState();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Hitted();
    }

    void Hitted()
    {
        HP--;
        Invoke("Recover", 0.02f);
        animator.SetBool("bHitAnim", true);
    }

    void Recover()
    {
        animator.SetBool("bHitAnim", false);
    }


    protected void Fire1(int state)
    {

        switch(state)
        {
            case 1: // Normal
                NormalPatternFire(1);
                break;
            case 2: // Pat 1
                FirstPatternFire(1);
                break;
            case 3: // Pat 2
                SecondPatternFire(1);
                break;
            case 4: // Pat 3
                ThirdPatternFire(1);
                break;
            default: break;
        }
    }

    protected void Fire2(int state)
    {
        switch (state)
        {
            case 1: // Normal
                NormalPatternFire(2);
                break;
            case 2: // Pat 1
                FirstPatternFire(2);
                break;
            case 3: // Pat 2
                SecondPatternFire(2);
                break;
            case 4: // Pat 3
                ThirdPatternFire(2);
                break;
            default: break;
        }
    }

    protected void Fire3(int state)
    {
        switch (state)
        {
            case 1: // Normal
                NormalPatternFire(3);
                break;
            case 2: // Pat 1
                FirstPatternFire(3);
                break;
            case 3: // Pat 2
                SecondPatternFire(3);
                break;
            case 4: // Pat 3
                ThirdPatternFire(3);
                break;
            default: break;
        }
    }

    protected virtual void NormalPatternFire(int index) { }
    protected virtual void FirstPatternFire(int index) { }
    protected virtual void SecondPatternFire(int index) { }
    protected virtual void ThirdPatternFire(int index) { }
    protected virtual int  ChangeState() { return 0; }
    protected virtual void Death() { }
    

}
