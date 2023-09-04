using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerControlType2 : MonoBehaviour
{



    //Movement Values and Collision
    private float horizontal;
    private float vertical;

    public float BaseSpeed = 2;
    public float Speed = 2;
    public float SpeedMultiplier = 2;

    private Rigidbody2D rb;
    [SerializeField] BoxCollider2D[] ColliderList;

    private Vector2 velocity;

    //BaseColliser, DashCollider, CrouchCollider, LockArea

    public bool dashState = false;
    public bool CrouchState = false;
    public bool HomingState = false;


    private bool dashing = false;
    private int facing = 1;
        
    //Animations
    Sprite Image;
    RuntimeAnimatorController Animator;
    //image flipping value
    private float originalxscale;
    private float originalgravityscale = 1;

    //jumping and falling values
    private float gravspeed; //base jumping or falling speed
    public float jumpVelocity = 6; //fine-tuned jumping speed
    private bool canjump = true;
    public bool isJumping = false;
    public float isjumpingTime = 0.2f;

    public bool Grounded = false;              //Grounded State check
    private float fallMultiplier = 6.19f;       //Fine-tuned Falling
    private float lowJumpMultiplier = 5.85f;    //Short-Jump Value

    [SerializeField] private Transform WallPoint;
    [SerializeField] private LayerMask WallLayerMask;
    public float WallPointCheckRadius;
    public bool isWallSliding;
    public float WallSlidingSpeed;

    public bool isWallJumping;
    public float WallJumpingDirection;
    public float wallJumpingTime = 0.2f;
    public float WallJumpingCounter;
    public float wallJumpingDuration = 0.2f;
    public Vector2 wallJumpingPower = new Vector2(8f, 16f);
    public float turningFreezeTimer = 2;
    public float turningFreezeTimerrate = 0.18f;


    [SerializeField] private LayerMask GroundLayerMask;
    [SerializeField] private Transform GroundPoint;           // Grounded Check
    public float GroundPointCheckRadius;    // GroundPointCircle Radius to finetune if we're grounded or not
    public Transform CeilingPoint;          // Ceiling Check
    public float CeilingPointCheckRadius;   // CeilingPointCircle Radius to finetune if there's something above the player while they're crouched


    public BoxCollider2D LockOnArea;
    //public BoxCollider2D BackLockOn;

    //public Collider2D[] FrontTargetList;
    //public Collider2D[] BackTargetList;
    public LockOnTech LockOn;
    public GameObject LockOnZoneGraphic;
    public float LockOnSize;
    public float LockOnSizeMax;
    //public bool LockOnState;
    [SerializeField] private float LockOnSizeRate = 0.085f;

    public float LockOnSpeed = 0.3f;
    public float LockOnGravity = 0.3f;
    public bool LockOnRecharged = true;

    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public float InterpolateAmount = 0.00f;
    public float HomingSpeed = 0.05f;

    //public BoxCollider2D HomingCollider;
    public float HomingHitboxRadius = 1;

    public BoxCollider2D HomingHitBox;
    public char LabelTarget = ' ';

    private InputSystem2 input = null;

    public int HP = 3;
    public float HitCooldown = 3f;
    public bool inHitstun = false;
    public float BaseHitCooldown = 3f;
    public float HitCooldownRate = 0.08f;

    private void Awake()
    {
        input = new InputSystem2();
        rb = GetComponent<Rigidbody2D>();

    }


    // Start is called before the first frame update
    void Start()
    {
        ColliderList[0].enabled = true; // Base Collider
        ColliderList[1].enabled = false; // Dash Collider
        ColliderList[2].enabled = false; // Crouch Collider
        ColliderList[4].enabled = false; // Hitbox Collider
        //LockOnArea Collider is handled seperate from these other colliders


        velocity = rb.velocity;

        originalxscale = transform.localScale.x;
        
        LockOn = GetComponent<LockOnTech>();
        LockOnDeactivate();
        LockOnZoneGraphic.GetComponent<Transform>().localScale = new Vector2(LockOnSize, LockOnSize);


        //LockOnArea.GetComponent<BoxCollider2D>().offset = new Vector2(LockOn.TopRightCorner.x / 2, 0);
        LockOnArea.GetComponent<BoxCollider2D>().size = new Vector2(LockOnSize, LockOnSize);
        //BackLockOn.GetComponent<BoxCollider2D>().offset = new Vector2(LockOn.TopRightCorner.x * -1 / 2, 0);
        //BackLockOn.GetComponent<BoxCollider2D>().size = new Vector2(LockOn.TopRightCorner.x, LockOn.TopRightCorner.x * 2);
        LockOnArea.gameObject.SetActive(false);
        //BackLockOn.gameObject.SetActive(false);
        //scale the graphic to the size of whatever the LockOn Rectangle's Vector 2 size is (Focus on TopRight Vector since it's positive and we are scaling positively)
    }

    
    private void FixedUpdate()
    {
        MovementHandler();

        CollisionHandler();
    
        Grounded = (Physics2D.OverlapCircle(GroundPoint.position, GroundPointCheckRadius, GroundLayerMask));
        if (!Grounded) canjump = false;
        else
        {
            canjump = true;
            LockOnRecharged = true;
            LabelTarget = ' ';

        }

        //CrouchCheck();

        //putting these functions in fixedupdate rather than in regular update allows them to activate ONLY when the game is unpaused (because physics time moves in fixed update rather than in regular update)
        //When moving a character with the rigidbody, we want to make sure all the physics calculations are being done correctly


        if (LockOn.enabled)
        {
            LockOnExpand();
        }

        if (HomingState) HomingHop();


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

    // Update is called once per frame
    void Update()
    {
        
    }


    //------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------


    private void MovementHandler()
    {
        if (horizontal > 0 && !isWallSliding && turningFreezeTimer <= 0 && Grounded)
        {
            facing = 1;
            transform.localScale = new Vector2(originalxscale, transform.localScale.y);
        }

        if (horizontal < 0 && !isWallSliding && turningFreezeTimer <= 0 && Grounded)
        {
            facing = -1;
            transform.localScale = new Vector2(-originalxscale, transform.localScale.y);
        }
        //turning can only be done if grounded

        if (!Grounded)
        {
            if ((int)horizontal != facing && (int)horizontal != 0)
            {
                if (dashState && turningFreezeTimer <= 0)
                    rb.velocity = new Vector2((horizontal * Speed * SpeedMultiplier) / 2, rb.velocity.y);


                else if (turningFreezeTimer <= 0) rb.velocity = new Vector2((horizontal * Speed) / 2, rb.velocity.y);
            }

            else if ((int)horizontal == facing)
            {
                if (dashState && turningFreezeTimer <= 0)
                    rb.velocity = new Vector2(horizontal * Speed * SpeedMultiplier, rb.velocity.y);


                else if (turningFreezeTimer <= 0) rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
            }
        }

        else
        {
            if (dashState) rb.velocity = new Vector2(horizontal * Speed * SpeedMultiplier, rb.velocity.y);    

            else if (CrouchState) rb.velocity = new Vector2(horizontal * Speed/2, rb.velocity.y);

            else if (turningFreezeTimer <= 0) rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
        }
        //jumping flag recovery
        //this is necessary because the jump button being pressed needs to be tracked for wall jumping
        //and the new input handler doesn't have an intuitive way to set the jump button being pressed to a boolean.
        if (isJumping)
        {
            isjumpingTime -= Time.deltaTime;
            if (isjumpingTime <= 0) isJumping = false;
        }

        WallSlide();
        WallJump();
        if (turningFreezeTimer >= 0)
            turningFreezeTimer -= turningFreezeTimerrate;


        if (vertical <= -0.57 && Grounded && !dashState)  CrouchState = true;
        else CrouchState = false;
    }

    private void CollisionHandler()
    {
        if (dashState)
        {
            ColliderList[0].enabled = false; // Base Collider
            ColliderList[1].enabled = true; // Dash Collider
            ColliderList[2].enabled = false; // Crouch Collider
            ColliderList[4].enabled = false; // Hitbox Collider
        }

        else if (CrouchState)
        {
            ColliderList[0].enabled = false; // Base Collider
            ColliderList[1].enabled = false; // Dash Collider
            ColliderList[2].enabled = true; // Crouch Collider
            ColliderList[4].enabled = false; // Hitbox Collider
        }

        else if (HomingState)
        {
            ColliderList[0].enabled = false; // Base Collider
            ColliderList[1].enabled = false; // Dash Collider
            ColliderList[2].enabled = false; // Crouch Collider
            ColliderList[4].enabled = true; // Hitbox Collider
        }

        else
        {
            ColliderList[0].enabled = true; // Base Collider
            ColliderList[1].enabled = false; // Dash Collider
            ColliderList[2].enabled = false; // Crouch Collider
            ColliderList[4].enabled = false; // Hitbox Collider
        }

        //what triggers the LockOn Collider is done outside the ColliderManager

    }

    private void Jump()
    {
        if(vertical == -1 && Grounded)
        {
            //Debug.Log("Going through floor");
            if(Physics2D.OverlapCircle(GroundPoint.position, GroundPointCheckRadius, GroundLayerMask).GetComponent<FallThorughPlatform>())
            Physics2D.OverlapCircle(GroundPoint.position, GroundPointCheckRadius, GroundLayerMask).GetComponent<FallThorughPlatform>().LetThrough();
            return;
        }

        isJumping = true;
        isjumpingTime = 0.2f;

        if (canjump)
        {

            //Debug.Log("RegularJump");
            isjumpingTime = 0.2f;
            rb.velocity = new Vector2(rb.velocity.x, 1 * jumpVelocity);
        }

        if (isWallSliding) WallJump();
    }

    private void CrouchCheck()
    {
        if (vertical < 0)
        {
            ColliderList[0].enabled = false;
            ColliderList[1].enabled = false;
            ColliderList[2].enabled = true;
        }

        else
        {
            if (vertical < 0.5 && Grounded)
            {
                //if(dashstate)
                //ColliderList[1].enabled = true;


                //else
                //ColliderList[0].enabled = true;

                ColliderList[2].gameObject.SetActive(false);
            }

        }
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(WallPoint.position, WallPointCheckRadius, WallLayerMask);
    }

    private void WallSlide()
    {
        if (isWalled() && !Grounded && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(
                rb.velocity.y, -WallSlidingSpeed, float.MaxValue
                )); 
            //clamp the rigidbody's vertical velocity between the negative value of the wall sliding speed and the float of Max Value
        }

        else isWallSliding = false;
    }


    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            WallJumpingDirection = -transform.localScale.x; //set the jump in the opposite direction of where the player is facing
            WallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
            //we cancel the potential call of StopWallJumping if isWallSliding ever becomes true again
        }

        else
        {
            if(WallJumpingCounter >= 0)
                WallJumpingCounter = WallJumpingCounter - Time.deltaTime; //allows us to turn away from the wall and still jump from the wall for a brief moment
        }

        if (isJumping && WallJumpingCounter > 0f)
        {
            isjumpingTime = 0f;
            isJumping = false;
            turningFreezeTimer = 2;
            isWallJumping = true;

            //Debug.Log("WallJump");
            rb.velocity = new Vector2(WallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            WallJumpingCounter = 0f;


            if(transform.localScale.x != WallJumpingDirection)
            {
                facing = -facing;
                Vector3 localScale = transform.localScale;
                localScale.x = localScale.x * -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
            //call the StopWallJumping function after a set amount of time (the time in question being the walljumpingduration variable
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }
   
  
    private void LockOnActivate()
    {
        //LockOnArea.gameObject.SetActive(true);
        //BackLockOn.gameObject.SetActive(true);
        //LockOnState = true;
        LockOnSize = 0.1f;
        LockOnArea.GetComponent<BoxCollider2D>().size = new Vector2(LockOnSize, LockOnSize);
        LockOn.enabled = true;
        LockOnZoneGraphic.SetActive(true);
        LockOnArea.gameObject.SetActive(true);

        rb.velocity = Vector2.up;
        Speed = LockOnSpeed;
        rb.gravityScale = LockOnGravity;

        LockOnRecharged = false;
        //BackLockOn.gameObject.SetActive(true);
    }

    private void LockOnDeactivate()
    {
        //LockOnArea.gameObject.SetActive(false);
        //BackLockOn.gameObject.SetActive(false);
        //LockOnState = false;
        LockOn.enabled = false;
        LockOnZoneGraphic.SetActive(false);
        LockOn.Clear();
        LockOnArea.gameObject.SetActive(false);
        //BackLockOn.gameObject.SetActive(false);

        //LockOnState = false;
        LockOnSize = 0.1f;
        LockOnArea.GetComponent<BoxCollider2D>().size = new Vector2(LockOnSize, LockOnSize);

        Speed = BaseSpeed;
        rb.gravityScale = originalgravityscale;
    }

    private void LockOnExpand()
    {
        if (LockOnSize < LockOnSizeMax) { 
            LockOnSize = LockOnSize + LockOnSizeRate;
            LockOnZoneGraphic.GetComponent<Transform>().localScale = new Vector2(LockOnSize, LockOnSize);
            LockOnArea.GetComponent<BoxCollider2D>().size = new Vector2(LockOnSize*2, LockOnSize*2);
            
        }
    }
    
    
    private void HomingHop()
    {
        InterpolateAmount = InterpolateAmount + HomingSpeed;
        transform.position = Vector2.Lerp(StartPosition, EndPosition, InterpolateAmount);

        if (InterpolateAmount >= 1) {
            HomingState = false;
 
            if (StartPosition != EndPosition)
            {
                //Debug.Log((StartPosition - EndPosition).magnitude);
                LockOnRecharged = true;
                rb.velocity = new Vector2(rb.velocity.x, 1 * jumpVelocity);

            }
            //If we have actually headed to a target, we pop up

            EndPosition = Vector2.zero;

        }

        if ((Physics2D.OverlapCircle(this.transform.position, HomingHitboxRadius, GroundLayerMask) ||
            Physics2D.OverlapCircle(this.transform.position, HomingHitboxRadius, WallLayerMask)) &&
            InterpolateAmount > 0.2)
        {
            if (Physics2D.OverlapCircle(this.transform.position, HomingHitboxRadius, GroundLayerMask))
                Debug.Log(Physics2D.OverlapCircle(this.transform.position, HomingHitboxRadius, GroundLayerMask).name);

            if (Physics2D.OverlapCircle(this.transform.position, HomingHitboxRadius, WallLayerMask))
                Debug.Log(Physics2D.OverlapCircle(this.transform.position, HomingHitboxRadius, WallLayerMask).name);

            HomingHopCancel();
        }
        //we track if the HomingCollider for the player connects with a wall. if it does , call HomingHopCancel
        //if you hit a Target's Collider, call HomingHopCalculation
        //We do wall checks when the interpolateAmount is above 0.2 because we don't want to check while we're grounded or something
    }

    public void HomingHopCancel()
    {
        Debug.Log("Canceling Homing");
        HomingState = false;
        EndPosition = Vector2.zero;
        LabelTarget = ' ';
    }

    public void DamageCalculation(int dmg)
    {
        HP = dmg;
        inHitstun = true;
    }
    //------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------------------------------------


    private void OnEnable()
    {
        input.Enable();
        input.PlayerOne.Movement.performed += OnMovementPerformed;
        input.PlayerOne.Movement.canceled += OnMovementCancelled;

    }

    private void OnDisable()
    {
        input.Disable();
        input.PlayerOne.Movement.performed -= OnMovementPerformed; //unsubscribe from the function. playermovement script has no need for being attached to the playerone event if it's disabled.
        input.PlayerOne.Movement.canceled -= OnMovementCancelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        horizontal = value.ReadValue<Vector2>().x;
        vertical = value.ReadValue<Vector2>().y;
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        horizontal = 0;
        vertical = 0;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Debug.Log("Jumping");
            Jump();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            //Debug.Log("Dashing");
            if (Grounded) dashState = true;
        }

        else if(context.canceled)
        {
            //Debug.Log("Dashing Canceled");
            dashState = false;
        }

    }

    public void OnLockOn(InputAction.CallbackContext context)
    {
        if (context.started && LockOnRecharged)
        {
            LockOnActivate();
        }

        if (context.canceled)
        {
            LockOnDeactivate();
        }
    }


    public void OnHomingHopA(InputAction.CallbackContext context)
    {
        //if in LockOnState
        //StartPosition = this.position
        //EndPosition = LockOnTech.HomingHopA(This.gameobject)
        if(context.started)
            if (LockOn.enabled)
            {
           
                StartPosition = this.transform.position;

                EndPosition = LockOn.HomingHop('A', this.gameObject);
                LabelTarget = 'A';

                InterpolateAmount = 0;

                HomingState = true;

                LockOnDeactivate();

            }
        //HomingHopA(GameObject S):
        //Look at the objects in A_Results
        //return the minimum of
        //Mathf.abs(S - A_results[0]) and Mathf.abs(S - A_results[1])

        //Lerp this object between StartPosition and EndPosition
    }

    public void OnHomingHopB(InputAction.CallbackContext context)
    {

        if(context.started)
            if (LockOn.enabled)
            {

                StartPosition = this.transform.position;

                EndPosition = LockOn.HomingHop('B', this.gameObject);
                LabelTarget = 'B';

                InterpolateAmount = 0;

                HomingState = true;

                LockOnDeactivate();

            }
    }
    
    public void OnHomingHopX(InputAction.CallbackContext context)
    {
     
        if(context.started)
            if (LockOn.enabled)
            {
           
                StartPosition = this.transform.position;

                EndPosition = LockOn.HomingHop('X', this.gameObject);
                LabelTarget = 'X';

                InterpolateAmount = 0;

                HomingState = true;

                LockOnDeactivate();
            }
  }

    public void OnHomingHopY(InputAction.CallbackContext context)
    {

        if(context.started)
            if (LockOn.enabled)
            {

                StartPosition = this.transform.position;

                EndPosition = LockOn.HomingHop('Y', this.gameObject);
                LabelTarget = 'Y';

                InterpolateAmount = 0;

                HomingState = true;

                LockOnDeactivate();

            }
    }

}
