using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotEncyclopedia : MonoBehaviour
{

    public Spot[] RooftopRushSpotArray;

    public static SpotEncyclopedia SE;

    public string ChosenSpot = "";


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

    public Spot SpotRetrieval(string Stage, int Type, char prevSpot, char nextSpot)
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


        return RooftopRushSpotArray[1];
    }
    
}
