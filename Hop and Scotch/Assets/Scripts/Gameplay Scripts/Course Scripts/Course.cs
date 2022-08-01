using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour
{
    public char[] path;
    public string course = "8323452401231241231230142323012421304123419";
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
    // Start is called before the first frame update
    void Start()
    {
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
            //Debug.Log("Placing Log #" + i);

            //if you meet a gap, change the type of spot from basic to fenced
            if(path[i] == '0')
            {
                if (CurrSpotType == 0) CurrSpotType = 1;
                else if (CurrSpotType == 1) CurrSpotType = 2;
                else if (CurrSpotType == 2) CurrSpotType = 0;
                else CurrSpotType = 0;
            }

            //the special spot is to be placed once. revert back to the current spot type
            if(CurrSpotType != 0 && CurrSpotType != 1 && CurrSpotType != 2)
            {
                CurrSpotType = TempCurrSpotType;
                TempCurrSpotType = 0;
                SpotTypeCounter = Random.Range(7,10);
            }

            //this is to periodically place one of the special spots with the items on it
            if (SpotTypeCounter <= 0)
            {
                TempCurrSpotType = CurrSpotType;
                CurrSpotType = Random.Range(3,5);//A random number from 3 4 or 5
            }


            //Now to check the point of the path we're in
            if (i - 1 >= 0 && i + 1 < path.Length)
                CurrentBlockPrefab = SpotEncyclopedia.SE.SpotRetrieval("RR", CurrSpotType, path[i - 1], path[i + 1]);

            else if (i == 0)
                CurrentBlockPrefab = SpotEncyclopedia.SE.SpotRetrieval("RR", CurrSpotType, '1', path[i + 1]);
            
            else CurrentBlockPrefab = SpotEncyclopedia.SE.SpotRetrieval("RR", CurrSpotType, path[i - 1], '1');
            

            //spawn a new block
            GameObject s = Instantiate(CurrentBlockPrefab.gameObject, new Vector2(SpotPosTracker, this.transform.position.y), this.transform.rotation);


            SpotPosTracker = SpotPosTracker + SpotOffset; //handles the x offset position

            s.GetComponent<Spot>().setButt(buttonType, path[i], yoffset); //sets the sprite of the spot block, and also the button prompt

            s.transform.SetParent(BlockFolder.transform);

            //s.transform.position = new Vector2(s.transform.position.x, s.transform.position.y + yoffset);

            CourseSpotForme[i] = s;

            SpotTypeCounter--;
        }
        //now the course should be built

        /*
        for (int i = 1; i < CourseSpotForme.Length - 2; i++)
        {
            //if the stage is rooftop rush
            CourseSpotForme[i].transform.position = new Vector2(CourseSpotForme[i].transform.position.x, CourseSpotForme[i].transform.position.y + yoffset);

        }
        */
        InitializePos();
        
    

        PL.FinishLine = CourseSpotForme[CourseSpotForme.Length - 1];
        //give the position of the finish line spot to the progress bar

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
