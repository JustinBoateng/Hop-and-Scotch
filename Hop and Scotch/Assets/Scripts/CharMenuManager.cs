using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharMenuManager : MonoBehaviour
{
    public Icon[] Characters;
    public PlayerFrame[] Players = new PlayerFrame[2];
    public int NoofPlayers;

    public static CharMenuManager CMM;

    public bool allcharsselected = false;

    public GameObject StageSelectMenu;

    public int currStage = 0;
    public MenuStages[] StageArray;
    public Image StageVisual;
    public Text StageDesc;
    public bool inputcheck = false;
    public int selectedfirst = -1;
    public float hor;

    public string StageCode = "SAMPLE";


    private void Awake()
    {
        if (CMM == null)
        {
            //DontDestroyOnLoad(gameObject);
            CMM = this;
        }

        else if (CMM != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        selectedfirst = -1;
        UpdateStage(currStage);
        StageSelectMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if((selectedfirst == 1 || selectedfirst == 2) && allcharsselected)
          hor = Input.GetAxisRaw("P" + selectedfirst + " Horizontal");

        //Revert who selected first back to -1
        if (selectedfirst != -1)
        {
            if (Input.GetButton("P" + selectedfirst + " Cancel"))
            {
                selectedfirst = -1;
                allcharsselected = false;
                StageSelectMenu.gameObject.SetActive(false);
                Players[0].resetFrame();
                Players[1].resetFrame();
            }

            if (Input.GetButton("P" + selectedfirst + " Submit") && allcharsselected)
            {
                MultiPlayerTransition();
            }

        }
        //if one player HAS chosen (!= -1) and the other player HASN'T (== -1) 
        if (Players[0].CharSelected != -1 && Players[1].CharSelected == -1)
            selectedfirst = 1;

        if (Players[1].CharSelected != -1 && Players[0].CharSelected == -1)
            selectedfirst = 2;



        if (Players[0].FullSelected && Players[1].FullSelected)        
            allcharsselected = true;
        

        if (allcharsselected)
        {
            //if(StageSelectMenu != null)
            StageSelectMenu.gameObject.SetActive(true);
        }

        if (allcharsselected)
        {
            StageMovement();
        }



    }

    public void StageMovement()
    {
        if(hor != 0 && !inputcheck)
        {
            if (hor == -1)
            {
                Debug.Log("Left Detected");
                if (currStage > 0)
                {
                    currStage = currStage - 1;
                }
                else
                {
                    currStage = StageArray.Length - 1;
                }

            }

            else if (hor == 1)
            {
                Debug.Log("Right Detected");
                if (currStage < StageArray.Length - 1)
                    currStage = currStage + 1;
                else
                    currStage = 0;
            }

            UpdateStage(currStage);

            inputcheck = true;
        }

        if ((hor != -1 && hor != 1)) inputcheck = false;
    }

    public void UpdateStage(int i)
    {
        StageVisual.sprite = StageArray[i].getVisual();
        StageDesc.text = StageArray[i].getDesc();

    }

    public void setNumofPlayers(int x)
    {
        NoofPlayers = x;
    }

    public RuntimeAnimatorController IconSampleUpdate(string CC)
    {
        return AnimationDictionary.AD.SpriteRetrieval(CC);
    }



    public void MultiPlayerTransition()
    {
        //set the Character codes to the TransitionManager
        TransitionManager.TM.SetAnimationCodes(Players[0].ColorSelected, Players[1].ColorSelected);

        //Go to the next Scene

        StageSelectMenu.gameObject.SetActive(false);
        SceneManager.LoadScene("MultiPlayer-GameScene");

        //The GameManager sets the Codes to the players at Start
    }


}
