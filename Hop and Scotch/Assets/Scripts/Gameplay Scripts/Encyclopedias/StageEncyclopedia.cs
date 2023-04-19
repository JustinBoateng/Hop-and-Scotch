using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEncyclopedia : MonoBehaviour
{
    public GameObject[] StageArray;
    public string CurrStage;

    public static StageEncyclopedia SE;


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
        //try this 
        //Retrieve(1);
        //Establish();
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

    public void Establish(string Stage, string Char)
    {
        CurrStage = TransitionManager.TM.currStageCode.Substring(0, 2);
        GameObject Background;
        for (int i = 0; i < StageArray.Length; i++)
            if (StageArray[i].name.Contains(Stage) && StageArray[i].name.Contains(Char))
            {
                Background = Instantiate(StageArray[i].gameObject, new Vector2(0, 0), this.transform.rotation);
                return;
            }
    }
}
