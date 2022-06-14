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
    public GameObject BlockPrefab;
    public float StartSpotPosx;
    public float StartSpotPosy;
    public float SpotPosTracker;
    public float SpotOffset;

    public GameObject[] CourseSpotForme; //used as a reference to each spot
    public Player PlayerReference;


    public float XMin;
    public float XMax;
    public CameraFollow CF;


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

        //set up each spot's position
        for(int i = 0; i < path.Length; i++)
        {
            //Debug.Log("Placing Log #" + i);

            GameObject s = Instantiate(BlockPrefab, new Vector2(SpotPosTracker, StartSpotPosy), this.transform.rotation);
            SpotPosTracker = SpotPosTracker + SpotOffset;

            s.GetComponent<Spot>().setButt(buttonType, path[i]);
            s.transform.SetParent(BlockFolder.transform);

            CourseSpotForme[i] = s;
        }
        //now the course should be built

        bp.setSpot(0);       
        bp.setyOffset(BouncePointerOffset);
        bp.SetPos(CourseSpotForme[0]);

        PlayerReference.setPosition(bp.transform);

        PL.FinishLine = CourseSpotForme[CourseSpotForme.Length - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncBouncePointer()
    {
        if((bp.getSpot() + spaceToNextSpot) < path.Length)
        {
            bp.setSpot(bp.getSpot() + spaceToNextSpot);
            bp.SetPos(CourseSpotForme[bp.getSpot()]);
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
}
