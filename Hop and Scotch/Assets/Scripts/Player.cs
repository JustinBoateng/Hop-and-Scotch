using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Course CourseRef;

    char input = 'Z';
    bool inputted = false;

    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointAB;
    public Transform pointBC;
    public Transform pointAB_BC;

    GameObject temppointA;
    GameObject temppointB;
    GameObject temppointC;
    GameObject temppointAB;
    GameObject temppointBC;
    GameObject temppointAB_BC;

    public float InterpolateAmount = 0;
    public float jumpheight;

    public int endPointSpot;
    public bool Leap = false;

    public int PlayerNumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        temppointA = new GameObject();
        temppointB = new GameObject();
        temppointC = new GameObject();
        temppointAB = new GameObject();
        temppointBC = new GameObject();
        temppointAB_BC = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        InputEval();



        if (Leap)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            //process of leaping
            if (InterpolateAmount < 1)
            {
                //Debug.Log("Leaping");
                Leaping();
            }

            //if we reached the end of the leap
            else
            {
                //if we caught uo to the bounce pointer...
                if (endPointSpot == CourseRef.getBP().getSpot())
                {
                    Leap = false;
                }

                //if we havent caught up to the bounce pointer
                else
                {
                    SetPoints();
                    JumpPathTransfer();
                    InterpolateAmount = 0;
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
        InterpolateAmount = InterpolateAmount + Time.deltaTime;
    }

    public void InputEval()
    {
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

        if (inputted && (CourseRef.getBP().currentspot < CourseRef.path.Length)) {
            if (input == CourseRef.nextSpot() || CourseRef.nextSpot() == '9')
            {
                //Debug.Log("Correct");

                //increment the BouncePointer
                CourseRef.IncBouncePointer();

                if (!Leap)
                {
                    SetPoints();
                    JumpPathTransfer();
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
            pointB.position = new Vector2((pointC.position.x + pointA.position.x) / 2, jumpheight);
            
       
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
}
