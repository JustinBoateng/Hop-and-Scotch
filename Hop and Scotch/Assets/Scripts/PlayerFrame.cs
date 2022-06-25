using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFrame : MonoBehaviour
{
    public Text Name;
    public Text Description;
    public string CharCode;
    public Image Visual;

    public int PlayerNumber = 0;
    public int currIcon;
    public float horizontal;
    public bool inputcheck;

    public int CharSelected = -1;

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
        horizontal = Input.GetAxisRaw("P" + PlayerNumber + " Horizontal");
        Debug.Log(horizontal);

        if(CharSelected == -1)   Movement();

        if (Input.GetButton("P" + PlayerNumber + " Submit") && CharSelected == -1)
        {
            CharSelected = currIcon;
        }

        if (Input.GetButton("P" + PlayerNumber + " Cancel") && CharSelected != -1)
        {
            CharSelected = -1;
        }

    }



    private void Movement()
    {
        if (horizontal != 0 && !inputcheck)
        {
            if (horizontal == -1)
            {
                Debug.Log("Left Detected");
                if (currIcon > 0)
                {
                    //Debug.Log("Decrementing currIcon to " + currIcon);

                    currIcon = currIcon - 1;

                    //Debug.Log("currIcon is now " + currIcon);

                }
                else
                {
                    currIcon = CharMenuManager.CMM.Characters.Length - 1;
                }

            }

            else if (horizontal == 1)
            {
                if (currIcon < CharMenuManager.CMM.Characters.Length - 1)
                    currIcon = currIcon + 1;
                else
                    currIcon = 0;
            }

            UpdateFrame(CharMenuManager.CMM.Characters[currIcon]);

            inputcheck = true;
        }

        if (horizontal == 0) inputcheck = false;
    }

    public void UpdateFrame(Icon I)
    {
        Name.text = I.getName();
        Description.text = I.getDesc();
        Visual.sprite = I.getSprite();
        CharCode = I.getCode();
    }

    public void resetFrame()
    {
        CharSelected = -1;
    }
}
