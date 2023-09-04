using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotEncyclopedia : MonoBehaviour
{

    public Spot[] RooftopRushSpotArray;

    public Spot[] PomegranateParkSpotArray;


    public static SpotEncyclopedia SE;

    public string ChosenSpot = "";

    //Note: The SpotEncyclopedia Class interacts with the Course Class


    private void Awake()
    {
        if (SE == null)
        {
            DontDestroyOnLoad(gameObject);
            SE = this;
        }

        else if (SE != this)
            Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Spot SpotRetrieval(string Stage, int Type, char prevSpot, char nextSpot, int spotnumber)
    {
        //TODO:
        //return the appropriate spot according to the information given

        if(Stage == "RR")
        {
            {
                //if the next spot is an empty spot
                //return Ledge Right
                //but WHICH RightLedge?
                //depends on the type of the previous spot
                //Course will take care of that, and it'll be represented in the value of Type

                //so a right ledge of type, say... fence, will produce a fenced right ledge
                //for Rooftop Rush, there will be 
                /*
                 * Base
                 * Fence
                 * Tall Fence
                 * Water Basin
                 * Advertisement
                 * Lamp
                 * 
                 */
            }

            //Type = Base
            if (Type == 0)
            {
                if (nextSpot == '0')
                {
                    //return Base Right Ledge
                    return RooftopRushSpotArray[6];
                }

                if (prevSpot == '0')
                {
                    //return Base Left Ledge
                    return RooftopRushSpotArray[5];
                }

                //return basic floors between the five slots 0 through 4, which should be the first types of floor for Rooftop Rush
                else return RooftopRushSpotArray[0 + (nextSpot % 5)];
            }

            //Type = Fence
            if (Type == 1)
            {
                if (nextSpot == 0)
                {
                    //return Fence Right Ledge
                    return RooftopRushSpotArray[13];

                }

                if (prevSpot == 0)
                {
                    //return Fence Left Ledge
                    return RooftopRushSpotArray[12];
                }

                else return RooftopRushSpotArray[7 + (nextSpot % 5)];
            }

            //Type = TallFence
            if (Type == 2)
            {
                //return the sprite with the tall fence
                return RooftopRushSpotArray[23];
            }

            //Type = WaterBasin
            if (Type == 3)
            {
                //return the sprite with the water basin

                return RooftopRushSpotArray[24];
            }

            //Type = Advertisement
            if (Type == 4)
            {
                //return the sprite with the Advertisement

                return RooftopRushSpotArray[14];
            }

            //Type = Lamp
            if (Type == 5)
            {
                //Based on the value of the curr spot 1-7, place the appropriate lamp spot
                //array of spot [15 + prevSpot - 1]

                return RooftopRushSpotArray[15 + prevSpot -1];

            }

            
        }

        else if (Stage == "PP")
        {
            { 
            /*type 1
            //PP[0,1] == bricks and leaves
            //PP[13-15] = Trees
            //PP[2] = bricks only

            //type 2
            //PP[2] = bricks only
            //PP[13-15] = Trees
            //PP[0,1] == bricks and leaves
            //PP[3] = bushes
            //PP[7] = potholes [bricks]
            //PP[11] = swings [bricks]

            //Type 3
            //PP[5] = leaves only
            //PP[6] = plain

            //type 4
            //PP[6] = plain

            //Type 5
            //PP[4] = grass lite 

            //type 6
            //PP[9,10] = red grass
            //PP[8] = potholes [redgrass]
            //PP[12] = swings [redgrass]

            //i should be some 2-digit number
            //tens place determines the region
            //ones place determines if the spot is plain or special
            */
            }
            //Debug.Log("SpotType is " + Type);
            //TYPE 1
            if (Type >= 10 && Type < 20)
            {
                if(Type % 10 != 0)
                {
                    return PomegranateParkSpotArray[Random.Range(13, 15)];
                }

                if(spotnumber % 2 == 1)  
                    return PomegranateParkSpotArray[1];
                else if (spotnumber % 2 == 0)
                    return PomegranateParkSpotArray[0];
            }

            //TYPE 2
            if (Type >= 20 && Type < 30)
            {

                if (spotnumber == 33 || spotnumber == 45 || spotnumber == 52 || spotnumber == 75)
                    return PomegranateParkSpotArray[7]; // potholes

                else if (spotnumber == 40 || spotnumber == 60)
                    return PomegranateParkSpotArray[11]; // swings


                if (Type % 10 != 0)
                {
                    if (spotnumber % 2 == 1)
                        return PomegranateParkSpotArray[3]; //bushes
                    else if (spotnumber % 2 == 0)
                        return PomegranateParkSpotArray[0]; // bricks and leaves
                }

                if (spotnumber % 2 == 1)
                    return PomegranateParkSpotArray[1]; //bricks and leaves
                else if (spotnumber % 2 == 0)
                    return PomegranateParkSpotArray[2]; //bricks only

            }

            //TYPE 3
            if (Type >= 30 && Type < 40)
            {
                if (Type % 10 != 0)
                {
                    return PomegranateParkSpotArray[5]; //leaves only
                }

                else
                    return PomegranateParkSpotArray[6]; //plain
            }

            //TYPE 4
            if (Type >= 40 && Type < 50)
            {
                    return PomegranateParkSpotArray[6]; // plain
            }

            //TYPE 5
            if (Type >= 50 && Type < 60)
            {
                return PomegranateParkSpotArray[4]; //grass lite
            }

            //TYPE 6 - Red Grass Zone
            if (Type >= 60 && Type < 70)
            {

                if (spotnumber == 133 || spotnumber == 145 || spotnumber == 152 || spotnumber == 175)
                    return PomegranateParkSpotArray[8]; // potholes

                else if (spotnumber == 140 || spotnumber == 160)
                    return PomegranateParkSpotArray[12]; // swings
                

                if (spotnumber % 2 == 1)
                    return PomegranateParkSpotArray[9]; //Reg Grass 1
                else if (spotnumber % 2 == 0)
                    return PomegranateParkSpotArray[10]; //red grass 2

            }

        }//You'll need to make custom rules for different stages since you don't know the types of spots or the context of the spots that can spawn


        return RooftopRushSpotArray[1];
    }
    
}
