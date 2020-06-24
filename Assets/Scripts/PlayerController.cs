using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    public static PlayerController GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<PlayerController>();
        }
        return instance;
    }

    public GameObject GetPlayerObject()
    {
        return gameObject;
    }


    enum eState
    {
        Hooking = 1,
        Shield = 2,
        Flying = 3
    }
    
    public Joystick joyStick;
    public LineRenderer lineRenderer;
    public Transform castPoint;
    public Transform firePoint;
    public RopeScrpt hook;
    public GameObject bullet;
    public Text stateTxt;
    public SpriteRenderer[] HPSprite = new SpriteRenderer[6];
    public GameObject unHookBtn;
    public GameObject shieldBtn;
    public GameObject shieldSprite;
    public AudioSource fireSound;
    public Sprite[] charSprites = new Sprite[3];


    private SpriteRenderer charSprite;
    private eState state;
    private RaycastHit2D laserCast;
    private int HP;
    private bool hitted;
    private bool shieldable;
    private bool shieldHitted;

    public int GetState()
    {
        return (int)state;
    }
    public void SetState(int s)
    {
        switch(s)
        {
            case 1:
                state = eState.Hooking;
                break;
            case 2:
                state = eState.Shield;
                break;
            case 3:
                state = eState.Flying;
                break;
            default: break;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        HP = 6;
        hitted = true;
        charSprite = GetComponent<SpriteRenderer>();
        shieldable = false;
        shieldHitted = false;
        fireSound = SoundManager.GetInstance().fireSound;
        charSprite.sprite = charSprites[LoadManager.GetInstance().GetCharIndex()];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (shieldable)
                Shield();
        }
        if (Input.GetKey(KeyCode.D))
        {
            UnHook();
        }

        PointerCast();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hook();
        }

        stateTxt.text = state.ToString();

    }

    void UnHit()
    {
        hitted = true;
        charSprite.color = new Color(
            charSprite.color.r,
            charSprite.color.g,
            charSprite.color.b,
            1.0f);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Hitted();   
        }
    }


    public void Hitted()
    {
        if(state == eState.Shield)
        {
            return;
        }
        if(hitted)
        {
            hitted = false;
            HP--;
            if (HP == 0)
            {
                Die();
            }
            HPSprite[HP].enabled = false;
            charSprite.color = new Color(
                charSprite.color.r,
                charSprite.color.g,
                charSprite.color.b,
                charSprite.color.a * 0.5f);
            // 반 정도 투명하게.
            Invoke("UnHit", 2.0f);
        }
    }

    void PointerCast()
    {
        if (joyStick.GetHorizontalValue() != 0.0f ||
            joyStick.GetVerticalValue() != 0.0f)
        {
            laserCast = Physics2D.Raycast((transform.position + new Vector3(joyStick.GetHorizontalValue(), joyStick.GetVerticalValue(), 0.0f)), new Vector2(joyStick.GetHorizontalValue(), joyStick.GetVerticalValue()));
        }
        else
        {
            //laserCast = Physics2D.Raycast((transform.position + new Vector3(joyStick.GetHorizontalValue(), joyStick.GetVerticalValue(), 0.0f)), Vector2.up);
        }
        castPoint.position = laserCast.point;
        firePoint.position = new Vector3(
            transform.position.x - (transform.position.x - castPoint.position.x) / 10.0f,
            transform.position.y - (transform.position.y - castPoint.position.y) / 10.0f, 0.0f);

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, castPoint.position);

    }

    public void Hook()
    {
        state = eState.Hooking;
        hook.Fire(new Vector3(joyStick.GetHorizontalValue(), joyStick.GetVerticalValue(), 0.0f));
    }

    public void UnHook()
    {
        state = eState.Flying;
        if (hook.hook != null)
        {
            shieldable = true;
            unHookBtn.SetActive(false);
            shieldBtn.SetActive(true);
            Invoke("AfterDodge", 1.5f);
        }
        hook.UnHook();
    }

    public void Shield()
    {
        state = eState.Shield;
        unHookBtn.SetActive(true);
        shieldSprite.SetActive(true);
        shieldBtn.SetActive(false);
        Invoke("AfterDodge", 1.0f);
    }

    private void AfterDodge()
    {
        shieldSprite.SetActive(false);
        unHookBtn.SetActive(true);
        shieldBtn.SetActive(false);
        state = eState.Flying;
        shieldable = false;
    }

    public void Fire()
    {
        fireSound.Play();
        GameObject b = (GameObject)Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        BulletScript bulletScript = b.GetComponent<BulletScript>();
        Vector3 aim = castPoint.position - transform.position;
        aim.Normalize();
        bulletScript.SetAim(aim);
    }

    private void Die()
    {
        GameManager.GetInstance().MakeDialouge("GAME OVER");
        GameManager.GetInstance().BackToLobby(3.0f);
        Destroy(gameObject);
    }



}
