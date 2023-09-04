using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArcadeMenuManager : MonoBehaviour
{
    //This class deals with Stage Selection

    public int currStage = 0;
    [SerializeField] private ArcadeObjects[] ArcadeList;

    [SerializeField] private TMPro.TextMeshProUGUI PresentedText;
    [SerializeField] private Image PresentedImage;
    [SerializeField] private TMPro.TextMeshProUGUI StageNumber;
    [SerializeField] private CharSelectArray CSARef;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Initialize()
    {

        PresentedText.text = ArcadeList[0].retrieveTitle();
        StageNumber.text = "STAGE " + ArcadeList[0].RetrieveStageNumber();
        PresentedImage.sprite = ArcadeList[0].retrieveImage();

    }

    public void RightShift()
    {
        if (currStage == ArcadeList.Length-1) currStage = 0;
        else currStage++;

        PresentedText.text = ArcadeList[currStage].retrieveTitle();
        StageNumber.text = "STAGE " + ArcadeList[currStage].RetrieveStageNumber();
        PresentedImage.sprite = ArcadeList[currStage].retrieveImage();

    }

    public void LeftShift()
    {
        if (currStage == 0) currStage = ArcadeList.Length-1;
        else currStage--;

        PresentedText.text = ArcadeList[currStage].retrieveTitle();
        StageNumber.text = "STAGE " + ArcadeList[currStage].RetrieveStageNumber();
        PresentedImage.sprite = ArcadeList[currStage].retrieveImage();

    }

    public void setList()
    {
        ArcadeList = CSARef.ArcadeList[CSARef.Current].GetComponent<CharSelectObject>().ArcadePath;
        currStage = 0;
        Initialize();
    } 
    // The editor cannot take a list as a parameter when the button calls it.
    //so we have to tinker a bit and call the entire CharSelectObject so we can pull their list.

    public void stageEnter()
    {
        TransitionManager.TM.SPStageTransition(ArcadeList[currStage].retrieveStageCode());
        //get the codename and put it through the Transition Manager
    }
}
