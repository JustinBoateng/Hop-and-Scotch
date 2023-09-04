using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArcadeObjects : MonoBehaviour
{

    
    [SerializeField] private string TitleCodename;
    [SerializeField] private string StageCodename;
    [SerializeField] private int StageNumber;
    [SerializeField] private Sprite StageImage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int RetrieveStageNumber()
    {
        return StageNumber;
    }
    //Stage Number from ArcadeObject contains the spot in the StageENcyclopedia to get the correct stage from
    public string retrieveTitle()
    {
        return TitleCodename;
    }

    public string retrieveStageCode()
    {
        return StageCodename;
    }

    public Sprite retrieveImage()
    {
        return StageImage;
    }

}
