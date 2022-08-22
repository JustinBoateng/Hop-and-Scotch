using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
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

    public InputAction playerControls;
    public PlayerInput PIReference;

    public float StageSelectFlag = 1f;

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
        //Sure we can have PlayerControls go left and right to change what stage to go to
        //as well as having the CMM seek PlayerInput
        //but the problem is choosing which player gets to move the menu.
        //one needs to be active while the other is disabled
        //it seems that the PlayerControl can contain more than one Vector2 variable..

        //we can simply borrow the menuhorizontal value of the selectedfirst player
        if ((selectedfirst == 0 || selectedfirst == 1) && allcharsselected)
            hor = Players[selectedfirst].MenuHorizontal;


        //also it's probably best to ggive the CharMenuManager the actual PlayerInput component
        //the way it looks now, it seems that all three have some clone of the component in one way or another

        //if one player HAS chosen (!= -1) and the other player HASN'T (== -1) 
        if (Players[0].FullSelected && !Players[1].FullSelected) selectedfirst = 0;

        else if (Players[1].FullSelected && !Players[0].FullSelected) selectedfirst = 1;
        
        else if (Players[0].FullSelected && Players[1].FullSelected) allcharsselected = true;

        else selectedfirst = -1;


        if (allcharsselected)
        {
            //if(StageSelectMenu != null)
            StageSelectMenu.gameObject.SetActive(true);
            Players[selectedfirst].MoveFlag(true);
            Players[selectedfirst].choosingStage = true;
        }

        if (allcharsselected)
        {
            StageMovement();
        }



    }

    public void StageMovement()
    {
        if (hor != 0 && !inputcheck)
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

        if (StageSelectFlag >= 0)
            StageSelectFlag = StageSelectFlag - 0.05f; 
        //a buffer for the stage select to show up without accidentally going into a stage
        //the countdown only occurs when StageMovement happens, which only happens when allcharsselected, as shown in Update()
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

        TransitionManager.TM.MultiPlayerTransition();

        //The GameManager sets the Codes to the players at Start
    }


    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (allcharsselected && StageSelectFlag <= 0)
            {
                MultiPlayerTransition();
            }

    }//press enter on a stage to choose the stage and go to it

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (allcharsselected)
        {
                selectedfirst = -1;
                allcharsselected = false;
                StageSelectMenu.gameObject.SetActive(false);
                Players[0].resetFrame();
                Players[1].resetFrame();

                StageSelectFlag = 1f;
        }//press b to revert back to char select when stage menu is up



    }



    public void OnSubmit1(InputAction.CallbackContext context)
    {
        if(selectedfirst == 0)//0 is player 1 in the array
            if (allcharsselected && StageSelectFlag <= 0 && context.started)
        {
            MultiPlayerTransition();
        }

    }//press enter on a stage to choose the stage and go to it

    public void OnCancel1(InputAction.CallbackContext context)
    {
        if (allcharsselected)
        {
            selectedfirst = -1;
            allcharsselected = false;
            StageSelectMenu.gameObject.SetActive(false);
            Players[0].resetFrame();
            Players[1].resetFrame();

            StageSelectFlag = 1f;
        }//press b to revert back to char select when stage menu is up



    }

    public void OnSubmit2(InputAction.CallbackContext context)
    { 
        if(selectedfirst == 1) //1 is player 2 in the array
        if (allcharsselected && StageSelectFlag <= 0 && context.started)
        {
            MultiPlayerTransition();
        }

    }//press enter on a stage to choose the stage and go to it

    public void OnCancel2(InputAction.CallbackContext context)
    {
        
        if (allcharsselected)
        {
            selectedfirst = -1;
            allcharsselected = false;
            StageSelectMenu.gameObject.SetActive(false);
            Players[0].resetFrame();
            Players[1].resetFrame();

            StageSelectFlag = 1f;
        }//press b to revert back to char select when stage menu is up



    }
}
