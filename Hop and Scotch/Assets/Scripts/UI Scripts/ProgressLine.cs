using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressLine : MonoBehaviour
{
    public GameObject PlayerRef;
    public GameObject StartZone;
    public GameObject FinishZone;
    public GameObject CharIcon;
    public GameObject FinishLine;

    public float OriginalStarttoFinishDistance;
    public bool DistanceLock = true;

    //finishline is the physical finishline of the course
    //finish zone is the end zone in the ui representing the finishline

    //attach this progressline object to the corresponding player's corresponding course.
    //then constantly track the x distance between the player and the finish line
    //from (1-distance/distance) to (1-distance/distance)


    // Start is called before the first frame update
    void Start()
    {
        CharIcon.transform.position = StartZone.transform.position;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanceLock)
        {
            OriginalStarttoFinishDistance = FinishLine.transform.position.x - PlayerRef.transform.position.x;
            DistanceLock = false;
        } //this should be done after Course is set up. Sur I can just set the creation of the course and therefore the finish line location in an Awake() function, but Im too tired and this works.

        CharIcon.transform.position = Vector3.Lerp(
            StartZone.transform.position, 
            FinishZone.transform.position, 
            (1-
                    (FinishLine.transform.position.x - PlayerRef.transform.position.x) 
                   /(OriginalStarttoFinishDistance)                 
            )
        );

    }
}
