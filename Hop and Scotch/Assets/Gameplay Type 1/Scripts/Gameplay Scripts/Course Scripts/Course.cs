using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour
{
    public char[] path;
    public string course = "8323452401231241231230142323012421304123419";
    public string StageCode = "RR";

    public string[] courses;
    public string[] StageCodes;

    public int buttonType;
    //0-empty 1-button 2-button 3-button 4-button 5-button 6-button 7-freespace 8-start 9-end

    public BouncePointer bp;
    public float BouncePointerOffset;
    public int spaceToNextSpot = 1;


    public GameObject BlockFolder;
    public GameObject StartBlockPrefab;
    public GameObject FinishBlockPrefab;
    public Spot CurrentBlockPrefab;

    public int CurrSpotType = 1;
    public int TempCurrSpotType = 0;
    public int SpotTypeCounter = 8;

    public float SpotPosTracker;
    public float SpotOffset;
    public float buttonlabeloffset;

    public GameObject[] CourseSpotForme; //used as a reference to each spot
    public Player PlayerReference;

    public float StartSpotPosx;
    //public float StartSpotPosy;
    public float XMin;
    public float XMax;
    public CameraFollow CF;
    //These five values determine the boundaries of the camera


    public float yoffset;

    public ProgressLine PL;


    //Note: The Course Class interacts with the SpotEncyclopedia Class for SpotRetrieval and the TransitionManager for StageCode

    // Start is called before the first frame update
    void Start()
    {
        StageCode = TransitionManager.TM.currStageCode.Substring(0,2);

        //set the boundary of the camera to not go beyond the stage
        CF.SetXBoundary(XMin, XMax);

        //set the path (array of integers) to an array of chars
        path = course.ToCharArray();
        CourseSpotForme = new GameObject[path.Length];

        //setup the spotpostracker to keep track of the offset between spots
        SpotPosTracker = StartSpotPosx;
        //this.transform.position.x could work too, but then you have a void behind the character

        //set up each spot's position
        for(int i = 0; i < path.Length; i++)
        {
            if (StageCode == "RR") RooftopRushCurrSpotType(i);

            else if (StageCode == "PP") PomegranateParkCurrSpotType(i);

            //The above functions dictate what CurrSpotType will be based on the calculations in hte function

            //After which, we should have our CurrSpotType established

            //Now to check the point of the path we're in
            if (i - 1 >= 0 && i + 1 < path.Length)
                CurrentBlockPrefab = SpotEncyclopedia.SE.SpotRetrieval(StageCode, CurrSpotType, path[i - 1], path[i + 1], i);

            else if (i == 0)
                CurrentBlockPrefab = SpotEncyclopedia.SE.SpotRetrieval(StageCode, CurrSpotType, '1', path[i + 1], i);
            
            else CurrentBlockPrefab = SpotEncyclopedia.SE.SpotRetrieval(StageCode, CurrSpotType, path[i - 1], '1', i);
            

            //spawn a new block
            GameObject s = Instantiate(CurrentBlockPrefab.gameObject, new Vector2(SpotPosTracker, this.transform.position.y), this.transform.rotation);


            SpotPosTracker = SpotPosTracker + SpotOffset; //handles the x offset position

            s.GetComponent<Spot>().setButt(buttonType, path[i], yoffset, buttonlabeloffset); //sets the sprite of the spot block, and also the button prompt

            s.transform.SetParent(BlockFolder.transform);

            //s.transform.position = new Vector2(s.transform.position.x, s.transform.position.y + yoffset);

            CourseSpotForme[i] = s;

            SpotTypeCounter--;
        }
        //now the course should be built


        InitializePos();
        
    

        PL.FinishLine = CourseSpotForme[CourseSpotForme.Length - 1];
        //give the position of the finish line spot to the progress bar

    }

    // Update is called once per frame
    void Update()
    {
        //We note if the next endpoint spot is an evnet spot
        if (CourseSpotForme[PlayerReference.endPointSpot].GetComponent<Spot>().Event != "")
        {
            //run a function to take in the endpoint spot of the course
            //Note that this number represents a slot in the courseSpotForme, a currently single 1D Array of Spots
            SpecialEvent(PlayerReference, CourseSpotForme[PlayerReference.endPointSpot].GetComponent<Spot>().Event, CourseSpotForme[PlayerReference.endPointSpot].GetComponent<Spot>());
            
        }

    }

    public void IncBouncePointer()
    {
        if((bp.getSpot() + spaceToNextSpot) < path.Length)
        {
            //space to next spot is used to skip over gaps (0s) in the stage 
            bp.setSpot(bp.getSpot() + spaceToNextSpot); //these are spots in the spot array
            bp.SetPos(CourseSpotForme[bp.getSpot()]); //these are spots in the spot array
        }

    }

    public char nextSpot()
    {
        spaceToNextSpot = 1;

        while ((
                (bp.getSpot() + spaceToNextSpot) < path.Length) 
                && path[bp.getSpot() + spaceToNextSpot] == '0')
        {
            spaceToNextSpot++;
        }

        if ((bp.getSpot() + spaceToNextSpot) >= path.Length-1) return path[path.Length - 1];

        else return path[bp.getSpot() + spaceToNextSpot];
    }

    public BouncePointer getBP()
    {
        return bp;
    }

    public void InitializePos()
    {
        bp.setSpot(0);
        bp.setyOffset(BouncePointerOffset);
        bp.SetPos(CourseSpotForme[0]);
        PlayerReference.setPosition(bp.transform);
        PlayerReference.JumpReset(); //Just calls JumpPathTransfer after resetting the BP Position
    }


    public void RooftopRushCurrSpotType(int i)
    {
        //Here, i represents if the spot counter = 0, AKA, if it's over a gap


        //if you meet a gap, change the type of spot from basic to fenced (Rooftop Rush Only, since 0 = gap, and gaps exist only in RR)
        if (path[i] == '0')
        {
            if (CurrSpotType == 0) CurrSpotType = 1;
            else if (CurrSpotType == 1) CurrSpotType = 2;
            else if (CurrSpotType == 2) CurrSpotType = 0;
            else CurrSpotType = 0;
        }
        //this cycles between the three regions of floor, base, gate, fence. The type changes when we meet a gap


        //the special spot is to be placed once. revert back to the current spot type
        if (CurrSpotType != 0 && CurrSpotType != 1 && CurrSpotType != 2)
        {
            CurrSpotType = TempCurrSpotType;
            TempCurrSpotType = 0;
            SpotTypeCounter = Random.Range(7, 10);
        }

        //this is to periodically place one of the special spots with the items on it
        if (SpotTypeCounter <= 0)
        {
            TempCurrSpotType = CurrSpotType;
            CurrSpotType = Random.Range(3, 5);//A random number from 3 4 or 5
        }

        //spottypecounter is used to countdown to when we need to place a unique spot down with a special image or feature.
        //spottypecounter decrements after a spot has been placed down. Around line 96-ish

        /*when SpotTypeCounter countsdown to 0,
            TempCurrSpotType holds CurrSpotType for a bit
            CurrSpotType switches to a random number 3,4, or 5
            Then we place a special spot depending on whatever CurrSpotType wants to be
          Then, for the next spot, since CurrSpotType isn't 0,1, or 2,
            We put back TempCurrSpotType's number into CurrSpotType,
            Set TempCurrSpotType back to 0
            and finally reset the random SpotTypeCounter to some random number between 7 and 10
           
          THIS is how we set random scenery on the stage.
        */

    }

    public void PomegranateParkCurrSpotType(int s)
    {
        //here, i represents how far the spotcounter is in the stage. The further it is, the more the scenery should change.
        {
            //type 1
            //PP[0,1] == bricks and leaves
            //PP[13-15] = Trees

            //type 2
            //PP[2] = bricks only
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
        }
        if(s > 0 && s < 30)
            CurrSpotType = 10;

        else if (s >= 30 && s < 80)
            CurrSpotType = 20;

        else if (s >= 80 && s < 100)
            CurrSpotType = 30;

        else if (s >= 100 && s < 115)
            CurrSpotType = 40;

        else if (s >= 115 && s < 140)
            CurrSpotType = 50;

        else  CurrSpotType = 60;

        Debug.Log("CurrSpotType is" + CurrSpotType);

        //calculate the currspottype through region, then check if it's a special spot
        //AKA: Calculate the Tens place, THEN the One's Place
        //submit that number to the SpotEncyclopedia

        //this check occurs before checking if SpotTypeCounter <= 0, since if it were reversed, then SpotTypeCounter and CuuSpotType would just revert back
        if (CurrSpotType % 10 != 0)
        {
            CurrSpotType = TempCurrSpotType;
            TempCurrSpotType = 0;
            SpotTypeCounter = Random.Range(4, 7); //more frequent unique spots
        }

        //this is to periodically place one of the special spots with the items on it
        if (SpotTypeCounter <= 0)
        {
            TempCurrSpotType = CurrSpotType;
            CurrSpotType = CurrSpotType + Random.Range(1, 10);//A random number from 1 to 10
        }



        Debug.Log("Now, CurrSpotType is" + CurrSpotType);
    }


    public void SpecialEvent(Player P, string Event, Spot S)
    {
        // P = Player Reference
        // Event =  current Event
        // S = Endpoint Spot to reference
        
        switch (Event)
        {
            case "HOLE":
                Debug.Log(CourseSpotForme[PlayerReference.endPointSpot].GetComponent<Spot>().Event);
                //say that RelatedSpots[0] contains the other spot position to teleport to.
                //Set Player Animation to Falling
                //Play Smoke Up Animation and have the player dissapear
                //Play Smoke up Animation and have the player reappear 
                break;


            case "SWING":
                //say that RelatedSpots[0,1,2] contains the other spot position to teleport to.
                break;

            default:
                break;


                
        }

    }
}
