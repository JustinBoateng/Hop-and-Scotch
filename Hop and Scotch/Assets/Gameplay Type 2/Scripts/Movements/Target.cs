using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public char Label;
    public RuntimeAnimatorController Animator;
    public float GravityAffector = 0;
    public int HP = 3;
    public float HitCooldown = 3f;
    public bool inHitstun = false;

    public float BaseHitCooldown = 3f;
    public float HitCooldownRate = 0.08f;
    public Rigidbody2D rb;

    public BoxCollider2D collider;

    public GameObject Recticle;

    //public Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<Rigidbody2D>())
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = GravityAffector;

        collider = GetComponent<BoxCollider2D>();

   

    }

    // Update is called once per frame
    void Update()
    {
        if(rb)
             rb.gravityScale = GravityAffector;


        if (inHitstun)
        {
            HitCooldown = HitCooldown - HitCooldownRate;
            if (HitCooldown < 0)
            {
                inHitstun = false;
                HitCooldown = BaseHitCooldown;
            }
        }
    }

    public void RevealRectacle()
    {
        Recticle.SetActive(true);
    }

    public void ConcealRectacle(GameObject PlayerLockOn)
    {
        Recticle.SetActive(false);

        //PlayerLockOn.GetComponent<LockOnTech>().EscapeLock(Label, this.gameObject);        
    }

    private void DamageCalculation(int dmg)
    {
        HP = HP - dmg;
        inHitstun = true;
    }

    private void DamageCalculation(PlayerControlType2 Player)
    {
        if (Label == Player.LabelTarget)
        {
            DamageCalculation(1);
        }

        else
        {
            Player.DamageCalculation(1);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);


        //Debug.Log(Label + " Entered a Trigger");
        if (other.gameObject.tag == "LockOnZone")
        {
            RevealRectacle();
           //returns the player gameobject because it is the only parent with the PlayerControType2 Class

        }
        //the gameObject in this case is the Player's LockOn BoxCollider

        if(other.gameObject.tag == "HitBox" && !inHitstun)
        {
            //only applies if there is a hitbox
            if (other.gameObject.GetComponentInParent<PlayerControlType2>())
                DamageCalculation(other.gameObject.GetComponentInParent<PlayerControlType2>());

            else
                DamageCalculation(1);


        }

    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(Label + " Is In Lock On");
        if (other.gameObject.tag == "LockOnZone")
        {
            RevealRectacle();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(Label + " Exited " + other.name);
        if (other.gameObject.tag == "LockOnZone")
        {
            other.GetComponentInParent<LockOnTech>().EscapeLock(Label, this.gameObject);
            //check the parent of the collider.
            //remember that the LockOnCollider is a CHILD of the ACTUAL PLAYER GAME OBJECT
            ConcealRectacle(other.gameObject);
        }
    }
}
