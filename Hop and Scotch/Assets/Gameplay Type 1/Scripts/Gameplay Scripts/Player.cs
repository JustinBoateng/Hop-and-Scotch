using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Course CourseRef;

    public char input = 'Z';
    bool inputted = false;

    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointAB;
    public Transform pointBC;
    public Transform pointAB_BC;

    public GameObject temppointA;
    public GameObject temppointB;
    public GameObject temppointC;
    public GameObject temppointAB;
    public GameObject temppointBC;
    public GameObject temppointAB_BC;

    public float InterpolateAmount = 0;
    public float Speed = 0.05f;
    public float BaseSpeed = 0.05f;    
    public float jumpheight;
    public int successfulHops = 0;
    public int MaxSuccessfulHops = 10;

    public int endPointSpot;
    public bool Leap = false;
    public bool trip = false;
    public float basetriplag = 5;
    public float triplag = 5;
    public float triplagrate = 0.2f;

    public int PlayerNumber = 0;
    public bool reachedGoal = false;
    public bool paused = false;


    public Animator animator;

    public bool Midair = false;
    public int HopLevel = 0;
    public bool Win = false;
    public bool Lose = false;
    public bool Tripped = false;

    public string AnimationCode;

    public PlayerInput PIRef;

    public bool PauseFlag = false;

    public bool HalfwayLeap = false;

    public float LandCooldown = 1.0f;
    public float LandCooldownRate = 0.1f;

    public GameObject DustReference;
    public GameObject SmokeReference;

    // Start is called before the first frame update
    void Start()
    {
     
        Win = false;
        Lose = false;

        for (int i = 0; i < AnimationDictionary.AD.AnimationArray.Length; i++) {
            //Debug.Log("Comparing " + AnimationDictionary.AD.AnimationArray[i].name + " to " + AnimationCode);
            if (AnimationDictionary.AD.AnimationArray[i].name == AnimationCode)
            {              
                animator.runtimeAnimatorController = AnimationDictionary.AD.AnimationArray[i];
                break;
            }
        }

        //Leap = true;
        //Midair = false;
        //HopLevel = 0;
        //Tripped = false;

        //JumpReset();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();

        if (!Midair) landCalc();
      


        if (!PauseMenu.PM.isPaused)
        {
            //if both the player and bouncepointer are at the end goal, then the player has reached the goal
            if (CourseRef.getBP().currentspot == CourseRef.path.Length-1 && !Leap) {
                reachedGoal = true;
                GameManager.GM.WinnerDecided = true;
            }

            //inputs are registered if player hasm't tripped, the game isn't paused, and it is after the countdown but before a winner has been decided
            //if (!trip && GameManager.GM.PlayersCanMove)
            //    InputEval();
            //The Inputs are handled here///////////////////////////////////////////////////////////////


            else if (trip) tripCalc();

            if (Leap)
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
                //process of leaping
                if (InterpolateAmount < 1)
                {
                    Leaping();
                } //interpolateamount is changed in this function

                //if we reached the end of the leap
                else
                {
                    //if we caught uo to the bounce pointer...
                    if (endPointSpot == CourseRef.getBP().getSpot())
                    {
                        Leap = false;
                        JumpPathTransfer();
                        Speed = BaseSpeed;
                        LandCooldown = 1;


                        HopLevel = 0;
                    }

                    //if we havent caught up to the bounce pointer
                    else if (endPointSpot != CourseRef.getBP().getSpot() && LandCooldown > 0)
                    {
                        SetPoints();
                        JumpPathTransfer();
                        landCalc();
                    }

                    else
                    {
                            SetPoints();
                            JumpPathTransfer();
                            InterpolateAmount = 0;
                            LandCooldown = 1;

                            if (successfulHops <= MaxSuccessfulHops)
                            {
                                successfulHops++;
                                Speed = BaseSpeed + (successfulHops / 80);
                            }
                    }
                    //if the spot the player is at is the same as the slot the bp is at, put leap to false
                    //else, set pointB to where bp is currently at and Leap again

                    InterpolateAmount = 0;

                }
            }


            //if the correct button is pressed
            else
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        } 
    }

    public void SetAnimation()
    {
        animator.SetBool("Hopping", Leap);
        animator.SetBool("Midair", Midair);
        animator.SetInteger("Hop Level", HopLevel);
        animator.SetBool("Win", Win);
        animator.SetBool("Lose", Lose);
        animator.SetBool("Tripped", trip && !Midair);
        animator.SetFloat("TripLag", triplag);
        animator.SetBool("HalfwayLeap", HalfwayLeap);

        //Debug.Log("Reached SetAnimation function in Player Class");
    }

    public void GetAnimation(string code)
    {
       AnimationCode = code;
       //GetComponent<Animator>().runtimeAnimatorController = AnimationDictionary.AD.SpriteRetrieval(code);
    }


    public void JumpReset()
    {
        JumpPathTransfer();
        InterpolateAmount = 0;
        Leap = false;
        Midair = false;
        HopLevel = 0;
        Tripped = false;
    }

    public void setPosition(Transform t)
    {
        this.transform.position = t.position;
    }

    public void Leaping()
    {
        temppointAB.transform.position = Vector3.Lerp(temppointA.transform.position, temppointB.transform.position, InterpolateAmount);
        temppointBC.transform.position = Vector3.Lerp(temppointB.transform.position, temppointC.transform.position, InterpolateAmount);
        temppointAB_BC.transform.position = Vector3.Lerp(temppointAB.transform.position, temppointBC.transform.position, InterpolateAmount);

        this.transform.position = temppointAB_BC.transform.position;
        InterpolateAmount = InterpolateAmount + BaseSpeed;

        if (InterpolateAmount < 0.01) Instantiate(DustReference, new Vector3(transform.position.x-0.5f, transform.position.y, transform.position.z), transform.rotation);

        if (InterpolateAmount > 0.02 && InterpolateAmount < 0.98) Midair = true;
        else Midair = false;

        if (InterpolateAmount < 0.5) HalfwayLeap = false;
        else HalfwayLeap = true;
    }//sets the midair movement and also checks if the player is in the midair state

    public void InputEval()
    {
        /*
        if (Input.GetButtonDown(PlayerNumber + "A") && !inputted)
        {
            input = '1';
            inputted = true;
        }

        else if (Input.GetButtonDown(PlayerNumber + "B") && !inputted)
        {
            input = '2';
            inputted = true;
        }

        else if (Input.GetButtonDown(PlayerNumber + "X") && !inputted)
        {
            input = '3';
            inputted = true;
        }

        else if (Input.GetButtonDown(PlayerNumber + "Y") && !inputted)
        {
            input = '4';
            inputted = true;
        }

        else if (Input.GetButtonDown(PlayerNumber + "L") && !inputted)
        {
            input = '5';
            inputted = true;
        }

        else if (Input.GetButtonDown(PlayerNumber + "R") && !inputted)
        {
            input = '6';
            inputted = true;
        }
        */

        if (inputted && (CourseRef.getBP().currentspot < CourseRef.path.Length)) {
            if (input == CourseRef.nextSpot() || CourseRef.nextSpot() == '7' || CourseRef.nextSpot() == '9')
            {
                //Debug.Log("Correct");

                //increment the BouncePointer
                CourseRef.IncBouncePointer();

                if (!Leap)
                {
                    SetPoints(); //set the destination (from, To, And inbetween)
                    JumpPathTransfer();//store that information so that subsequent presses can be stored without changing current trajectory
                    Leap = true;
                }

                else
                {
                    //you want to increment the bp value as you're in midair, 
                    //but NOT bring the player to that position
                    //this will require setting down the points necessary, while still keeping track of bp as it advances.
                    //perhaps if we set points A,B,C, yadda yadda to a temporary variable and store the actual bp 
                    //and update the previous jump path with the new jump path once interpolaterate >= 1

                    SetPoints();
                }
                input = 'Z';
            }

            else
            {
                //Debug.Log("Incorrect");
                trip = true;
                JumpPathNegate();
                successfulHops = 0;
                Speed = BaseSpeed;
            }

            inputted = false;
            //Debug.Log("Inputted");
        }


    }

    private void SetPoints()
    {
        //note the position of the bounce pointer and the player
        //but only if the player isn't already in the air
            pointA = this.transform;
            pointC = CourseRef.getBP().transform;
            pointB.position = new Vector2((pointC.position.x + pointA.position.x) / 2, CourseRef.transform.position.y + jumpheight);
        //JumpHeight is relative to the position of the course

        //HopLevel keeps track of the animation to use while hoping
            HopLevel = (int) Mathf.Abs(pointC.transform.position.x - pointA.transform.position.x);
            
    }

    private void JumpPathTransfer()
    {
        temppointA.transform.position = pointA.transform.position;
        temppointB.transform.position = pointB.transform.position;
        temppointC.transform.position = pointC.transform.position;
        temppointAB.transform.position = pointAB.transform.position;
        temppointBC.transform.position = pointBC.transform.position;
        temppointAB_BC.transform.position = pointAB_BC.transform.position;

        //store the endpoint once per jump
        endPointSpot = CourseRef.getBP().getSpot();

    }

    private void JumpPathNegate()
    {
        pointA.transform.position = temppointA.transform.position;
        pointB.transform.position = temppointB.transform.position;
        pointC.transform.position = temppointC.transform.position;
        pointAB.transform.position = temppointAB.transform.position;
        pointBC.transform.position = temppointBC.transform.position;
        pointAB_BC.transform.position = temppointAB_BC.transform.position;

        //set the bouncepointer to what the current endpointspot is        
        CourseRef.getBP().setSpot(endPointSpot);
    }

    private void tripCalc()
    {
        //you recover from tripping ONLY when you're not jumping
        if (!Leap)
        {
            triplag = triplag - triplagrate;
            if (triplag <= 0)
            {

                trip = false;
                triplag = basetriplag;
            }
        }
    }

    private void landCalc()
    {
        if(LandCooldown > 0 )
        LandCooldown = LandCooldown - LandCooldownRate;
    }


    public void OnA1(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 1) return;
        if(context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
            {
                input = '1';
                //Debug.Log(input);
                inputted = true;
                InputEval();
            }
    }

    public void OnB1(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 1) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '2';
            //Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }


    public void OnX1(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 1) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '3';
            //Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }

    public void OnY1(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 1) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '4';
            //Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }


    public void OnL1(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 1) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '5';
            //Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }

    public void OnR1(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 1) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '6';
            //Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }

    public void OnA2(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 2) return;

        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '1';
            Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }

    public void OnB2(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 2) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '2';
            Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }


    public void OnX2(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 2) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '3';
            Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }

    public void OnY2(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 2) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '4';
            Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }


    public void OnL2(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 2) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '5';
            Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }

    public void OnR2(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 2) return;
        if (context.performed)
            if (!trip && GameManager.GM.PlayersCanMove)
        {
            input = '6';
            Debug.Log(input);
            inputted = true;
            InputEval();
        }
    }

    public void OnPause1(InputAction.CallbackContext context)
    {

        //Debug.Log("using Player Function");

        if (PlayerNumber != 1) return;
        //Debug.Log("P1 context: " + context);
        if (context.performed)
        {
            if (!PauseMenu.PM.isPaused && !GameManager.GM.WinnerDecided)
            {
                PauseMenu.PM.Pause();
                //Debug.Log("Paused P1");
                PIRef.SwitchCurrentActionMap("UI");
                //Debug.Log("Current Action Map is: " + PIRef.currentActionMap);
            }
            else if (PauseMenu.PM.isPaused)
            {
                PauseMenu.PM.Resume();
                //Debug.Log("Paused P1");

                //if (GameManager.GM.NoofPlayers == 1)
                 //   PIRef.SwitchCurrentActionMap("PlayerOne-Game");
                //else
                //    PIRef.SwitchCurrentActionMap("Game");

                //Debug.Log("Current Action Map is: " + PIRef.currentActionMap);
            }
        }
    }


    public void OnPause2(InputAction.CallbackContext context)
    {
        if (PlayerNumber != 2) return;
        Debug.Log("P2 context: " + context);

        if (context.performed)
        {
            if (!PauseMenu.PM.isPaused && !GameManager.GM.WinnerDecided)
            {
                PauseMenu.PM.Pause();
                Debug.Log("Paused P2");
                PIRef.SwitchCurrentActionMap("UI");
                PauseFlag = true;
                //Debug.Log("Current Action Map is: " + PIRef.currentActionMap);
            }
            else if (PauseMenu.PM.isPaused)
            {
                PauseMenu.PM.Resume();
                Debug.Log("UnPaused P2");
                PIRef.SwitchCurrentActionMap("Game");
                PauseFlag = true;
                //Debug.Log("Current Action Map is: " + PIRef.currentActionMap);
            }
        }

        if (context.canceled) PauseFlag = false;
    }

    public void ExitingSceneUnPause()
    {
            PauseMenu.PM.Resume();
            Debug.Log("Paused Exit");
            PIRef.SwitchCurrentActionMap("Game");
            Debug.Log("Current Action Map is: " + PIRef.currentActionMap);
            TransitionManager.TM.Exit();
    }//this function is for the purpose of unpausing the game before changing screens

}
