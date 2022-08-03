using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool inputcheck; //used to prevent holding left or right
    public bool buttoncheck; //used to prevent holding a button

    public GameObject IconSample; 
    public CharMenuManager CMM;

    public int CharSelected = -1; //notes the selected character in the array as well as whether or not a character is selected at all
    public string ColorSelected = ""; //notes the color that was finally selected
    public bool FullSelected = false; //becomes 1 if CharSelected and ColorSelected are both solidified

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerNumber == 1) currIcon = 0;
        else if (PlayerNumber == 2) currIcon = 1;

        UpdateFrame(CharMenuManager.CMM.Characters[currIcon]);

    }

    // Update is called once per frame
    void Update()
    {
        MenuHorizontal = (int) Input.GetAxisRaw("P" + PlayerNumber + " Horizontal");
        //Debug.Log(MenuHorizontal);

        if(!FullSelected) Movement();

        if (Input.GetButtonDown("P" + PlayerNumber + " Submit") && CharSelected == -1 && ColorSelected == "" && !buttoncheck)
        {
            CharSelected = currIcon;
            buttoncheck = true;
        }

        if (Input.GetButtonDown("P" + PlayerNumber + " Submit") && CharSelected != -1 && ColorSelected == "" && !buttoncheck)
        {
            ColorSelected = CharCode;
            buttoncheck = true;
        }

        if (Input.GetButtonDown("P" + PlayerNumber + " Cancel") && !buttoncheck)
        {
            UpdateFrame(CharMenuManager.CMM.Characters[currIcon]); //set back the SpriteSample Color
            CharSelected = -1;
            ColorSelected = "";
            FullSelected = false;
            buttoncheck = true;
        }

        if (Input.GetButtonUp("P" + PlayerNumber + " Submit") || Input.GetButtonUp("P" + PlayerNumber + " Cancel")) buttoncheck = false;



        if (CharSelected != -1 && ColorSelected != "") FullSelected = true;
        else FullSelected = false;
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
        CharSelected = -1;
    }
}
