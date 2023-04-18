using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEncyclopedia : MonoBehaviour
{
    public GameObject[] StageArray;


    // Start is called before the first frame update
    void Start()
    {
        //try this 
        //Retrieve(1);
        Establish();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Retrieve(int i)
    {
        GameObject s = Instantiate(StageArray[i].gameObject, new Vector2(0, 0), this.transform.rotation);
    }

    public GameObject FullRetrieve(int i)
    {
        GameObject s = Instantiate(StageArray[i].gameObject, new Vector2(0, 0), this.transform.rotation);
        return s;
    }

    public void Establish()
    {
        string s = TransitionManager.TM.currStageCode;
        GameObject Stage;
        for (int i = 0; i < StageArray.Length; i++)
            if (StageArray[i].name == s)
            {
                Stage = Instantiate(StageArray[i].gameObject, new Vector2(0, 0), this.transform.rotation);
                return;
            }
    }
}
