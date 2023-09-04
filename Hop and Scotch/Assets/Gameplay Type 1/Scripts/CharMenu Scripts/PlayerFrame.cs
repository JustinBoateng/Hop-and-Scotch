using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerFrame : MonoBehaviour
{
    public Text Name;
    public Text Description;
    public Image Visual;
    public Icon SelectedIcon; //a reference to the actual icon

    public int currCode = 0;
    public string CharCode;

    public int PlayerNumber = 0;
    public int currIcon; //cycles through the array of icons. Is a number
    public int MenuHorizontal;
    public int MenuVertical;
    public float KeyboardMenuVal;
    public Vector2 DirNavValue;
    public bool inputcheck; //used to prevent holding left or right
    public bool buttoncheck; //used to prevent holding a button

    public GameObject IconSample; 
    public CharMenuManager CMM;

    public int CharSelected = -1; //notes the selected character in the array as well as whether or not a character is selected at all
    public string ColorSelected = ""; //notes the color that was finally selected
    public bool FullSelected = false; //becomes 1 if CharSelected and ColorSelected are both solidified

    public InputAction playerControls;
    public bool canMove;
    public bool choosingStage;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerNumber == 1) currIcon = 0;
        else if (PlayerNumber == 2) currIcon = 1;

        UpdateFrame(CharMenuManager.CMM.Characters[currIcon]);

        canMove = true;
        choosingStage = false;
        buttoncheck = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (canMove || choosingStage)
        {
            if (playerControls.ReadValue<Vector2>().x > 0.4)
                MenuHorizontal = 1;
            else if (playerControls.ReadValue<Vector2>().x < -0.4f)
                MenuHorizontal = -1;
            else MenuHorizontal = 0;

        
        }

        Movement();
    

        if (CharSelected != -1 && ColorSelected != "" && canMove && !choosingStage)
        {
            FullSelected = true;
            MoveFlag(false);
        }

  
    }



    private void Movement()
    {
        if (MenuHorizontal != 0 && !inputcheck)
        {
            if (MenuHorizontal == -1)
            {
                //Debug.Log("Left Detected");

                if (CharSelected == -1)
                {
                    if (currIcon > 0)
                        currIcon = currIcon - 1;
                    else
                        currIcon = CharMenuManager.CMM.Characters.Length - 1;
                    UpdateFrame(CharMenuManager.CMM.Characters[currIcon]);
                }

                if (CharSelected != -1)
                {
                    //Debug.Log("Updating Color");
                    UpdateColor(-1);
                }
            }

            else if (MenuHorizontal == 1)
            {
                //Debug.Log("Right Detected");

                if (CharSelected == -1)
                {
                    if (currIcon < CharMenuManager.CMM.Characters.Length - 1)
                        currIcon = currIcon + 1;
                    else
                        currIcon = 0;
                    UpdateFrame(CharMenuManager.CMM.Characters[currIcon]);
                }

                if (CharSelected != -1)
                {
                    //Debug.Log("Updating Color");
                    UpdateColor(1);
                }

            }

            inputcheck = true;
        }

        if (MenuHorizontal == 0) inputcheck = false;
    }

    public void UpdateFrame(Icon I)
    {
        Name.text = I.getName();
        Description.text = I.getDesc();
        Visual.sprite = I.getSprite();

        currCode = 0;
        CharCode = I.getCode(currCode);

        SelectedIcon = I;

        RuntimeAnimatorController Test = CharMenuManager.CMM.IconSampleUpdate(CharCode);
        IconSample.GetComponent<Animator>().runtimeAnimatorController = Test;
    }

    public void UpdateColor(int i)
    {
        if (i == 1)
        {
            currCode++;
            //Debug.Log("currCode = " + currCode);
            if (currCode > SelectedIcon.Code.Length-1) currCode = 0;
            CharCode = SelectedIcon.getCode(currCode);
            IconSample.GetComponent<Animator>().runtimeAnimatorController = AnimationDictionary.AD.SpriteRetrieval(CharCode);
        }

        if (i == -1)
        {
            currCode--;
            //Debug.Log("currCode = " + currCode);

            if (currCode < 0) currCode = SelectedIcon.Code.Length - 1;
            CharCode = SelectedIcon.getCode(currCode);
            IconSample.GetComponent<Animator>().runtimeAnimatorController = AnimationDictionary.AD.SpriteRetrieval(CharCode);

        }
    }

    public void resetFrame()
    {
        UpdateFrame(CharMenuManager.CMM.Characters[currIcon]); //set back the SpriteSample Color
        CharSelected = -1;
        ColorSelected = "";
        FullSelected = false;
        buttoncheck = false;
        MoveFlag(true);
        choosingStage = false;
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
        if (context.started && !buttoncheck)
        {
            Debug.Log("Selected");
        
            if (CharSelected != -1 && ColorSelected == "" && !buttoncheck)
            {
                ColorSelected = CharCode;
                buttoncheck = true;
            }

            if (CharSelected == -1 && ColorSelected == "" && !buttoncheck)
            {
                CharSelected = currIcon;
                buttoncheck = true;
            }
        }

        if (context.canceled)
        {
            buttoncheck = false;
        }

        switch (context.phase)
        {
            case InputActionPhase.Started:
                Debug.Log(context.interaction + " - Started");
                break;

            case InputActionPhase.Performed:
                Debug.Log(context.interaction + " - Performed");
                break;

            case InputActionPhase.Canceled:
                Debug.Log(context.interaction + " - Canceled");
                break;
        }
    }

    public void OnCancel(InputAction.CallbackContext context)
    {

        if (context.started)
        {

            {
                UpdateFrame(CharMenuManager.CMM.Characters[currIcon]); //set back the SpriteSample Color
                CharSelected = -1;
                ColorSelected = "";
                FullSelected = false;
                buttoncheck = false;
                MoveFlag(true);
                choosingStage = false;
            }
        }
    }

    private void OnDirection(InputValue Value)
    {
        if (canMove || choosingStage)
        {
            DirNavValue = Value.Get<Vector2>();

            if (Value.Get<Vector2>().x > 0.5f)
                MenuHorizontal = 1;
            else if (Value.Get<Vector2>().x < -0.5f)
                MenuHorizontal = -1;
            else MenuHorizontal = 0;
            /*
            if (Value.Get<Vector2>().y > 0.8f)
                MenuVertical = 1;
            else if (Value.Get<Vector2>().y < -0.8f)
                MenuVertical = -1;
            else MenuVertical = 0;

            Debug.Log("Hor: " + MenuHorizontal);
            Debug.Log("Ver: " + MenuVertical);
            */
        }
    }

    public void MoveFlag(bool flag)
    {
        canMove = flag;
    }


    public void OnSubmit1(InputAction.CallbackContext context)
    {
            Debug.Log("Selected - Submit 1");
        if (context.started && !buttoncheck)
        {
            if (CharSelected != -1 && ColorSelected == "" && !buttoncheck)
            {
                ColorSelected = CharCode;
                buttoncheck = true;
            }

            if (CharSelected == -1 && ColorSelected == "" && !buttoncheck)
            {
                CharSelected = currIcon;
                buttoncheck = true;
            }
        }

        if (context.canceled)
        {
            buttoncheck = false;
        }
    }

    public void OnCancel1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            {
                UpdateFrame(CharMenuManager.CMM.Characters[currIcon]); //set back the SpriteSample Color
                CharSelected = -1;
                ColorSelected = "";
                FullSelected = false;
                buttoncheck = false;
                MoveFlag(true);
                choosingStage = false;
            }
        }

    }

    public void OnSubmit2(InputAction.CallbackContext context)
    {

        Debug.Log("Selected - Submit 2");

        if (context.started && !buttoncheck)
        {
            if (CharSelected != -1 && ColorSelected == "" && !buttoncheck)
            {
                ColorSelected = CharCode;
                buttoncheck = true;
            }

            if (CharSelected == -1 && ColorSelected == "" && !buttoncheck)
            {
                CharSelected = currIcon;
                buttoncheck = true;
            }

        }
        if (context.canceled)
        {
            buttoncheck = false;
        }

    }

    public void OnCancel2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            {
                UpdateFrame(CharMenuManager.CMM.Characters[currIcon]); //set back the SpriteSample Color
                CharSelected = -1;
                ColorSelected = "";
                FullSelected = false;
                buttoncheck = false;
                MoveFlag(true);
                choosingStage = false;
            }
        }
    }
    //all the On--- Methods deal only with inputs. They usually access functions that do the real heavy lifting.
    //keep this ideology when using On--- Functions with the input manager


}
