using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePointer : MonoBehaviour
{

    public int currentspot = 0;
    public int incRate = 1;

    public float flooroffset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPos(GameObject g)
    {
        this.gameObject.transform.position = new Vector2(g.transform.position.x, g.transform.position.y + flooroffset);
    }

    public void setyOffset(float s)
    {
        flooroffset = s;
    }

    public void setSpot(int i)
    {
        currentspot = i;
    }

    public int getSpot()
    {
        return currentspot;
    }

}
