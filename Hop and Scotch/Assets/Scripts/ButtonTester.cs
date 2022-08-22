using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class ButtonTester : MonoBehaviour
{
    [SerializeField] int PlayerNumber = 0;

    [SerializeField] Button[] ButtonList;
    //A B X Y L R

    [SerializeField] Button ButtConfig;

    //public InputAction PlayerControls;
    //public InputActionAsset IAA;

    Color BaseColor;
    byte ChangedColorR;
    byte ChangedColorB;
    byte ChangedColorG;
    byte ChangedColorA;
    Color PressedColor;

    string input;
    // Start is called before the first frame update
    void Start()
    {
        BaseColor = new Color32(255,255,255,255); 
        if (PlayerNumber == 1)
        {
            ChangedColorR = 255;
            ChangedColorB = 103;
            ChangedColorG = 103;
            ChangedColorA = 255;

        }
        else if (PlayerNumber == 2)
        {
            ChangedColorR = 69;
            ChangedColorB = 220;
            ChangedColorG = 255;
            ChangedColorA = 255;
        }
        PressedColor = new Color32 (ChangedColorR, ChangedColorG, ChangedColorB, 255);

        //PlayerControls.a = IAA.FindActionMap("PlayerOne-Game");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetButton(PlayerNumber + "A"))
        {
            ButtonList[0].GetComponent<Image>().color = PressedColor;
        }
        else if (!Input.GetButton(PlayerNumber + "A"))
        {
            ButtonList[0].GetComponent<Image>().color = BaseColor;
        }

        if (Input.GetButton(PlayerNumber + "B"))
        {
            ButtonList[1].GetComponent<Image>().color = PressedColor;
        }
        else if (!Input.GetButton(PlayerNumber + "B"))
        {
            ButtonList[1].GetComponent<Image>().color = BaseColor;
        }

        if (Input.GetButton(PlayerNumber + "X"))
        {
            ButtonList[2].GetComponent<Image>().color = PressedColor;
        }
        else if (!Input.GetButton(PlayerNumber + "X"))
        {
            ButtonList[2].GetComponent<Image>().color = BaseColor;
        }

        if (Input.GetButton(PlayerNumber + "Y"))
        {
            ButtonList[3].GetComponent<Image>().color = PressedColor;
        }
        else if (!Input.GetButton(PlayerNumber + "Y"))
        {
            ButtonList[3].GetComponent<Image>().color = BaseColor;
        }

        if (Input.GetButton(PlayerNumber + "L"))
        {
            ButtonList[4].GetComponent<Image>().color = PressedColor;
        }
        else if (!Input.GetButton(PlayerNumber + "L"))
        {
            ButtonList[4].GetComponent<Image>().color = BaseColor;
        }

        if (Input.GetButton(PlayerNumber + "R"))
        {
            ButtonList[5].GetComponent<Image>().color = PressedColor;
        }
        else if (!Input.GetButton(PlayerNumber + "R"))
        {
            ButtonList[5].GetComponent<Image>().color = BaseColor;
        }

    

        ButtonList[0].GetComponent<Image>().color = BaseColor;
        ButtonList[1].GetComponent<Image>().color = BaseColor;
        ButtonList[2].GetComponent<Image>().color = BaseColor;
        ButtonList[3].GetComponent<Image>().color = BaseColor;
        ButtonList[4].GetComponent<Image>().color = BaseColor;
        ButtonList[5].GetComponent<Image>().color = BaseColor;
        */ 
    }

    /*
    public void OnA(InputAction.CallbackContext context)
    {
        //ButtonList[0].GetComponent<Image>().color = PressedColor;
        Debug.Log("A pressed");

        switch (context.phase)
        {
            case InputActionPhase.Started:
                Debug.Log(context.interaction + " - Started");
                ButtonList[0].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                ButtonList[0].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;
                break;
        }

    }

    public void OnB(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[1].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnX(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[2].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnY(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[3].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnL(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[4].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnR(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[5].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    */
    public void OnA1(InputAction.CallbackContext context)
    {
        //ButtonList[0].GetComponent<Image>().color = PressedColor;

        switch (context.phase)
        {
            case InputActionPhase.Started:
                Debug.Log(context.interaction + " - Started");
                ButtonList[0].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                ButtonList[0].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;
                break;
        }

    }

    public void OnB1(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[1].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnX1(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[2].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnY1(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[3].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnL1(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[4].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnR1(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[5].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnA2(InputAction.CallbackContext context)
    {
        //ButtonList[0].GetComponent<Image>().color = PressedColor;

        switch (context.phase)
        {
            case InputActionPhase.Started:
                Debug.Log(context.interaction + " - Started");
                ButtonList[0].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[0].GetComponent<Image>().color = BaseColor;
                break;
        }

    }

    public void OnB2(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[1].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[1].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnX2(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[2].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[2].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnY2(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[3].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[3].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnL2(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[4].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[4].GetComponent<Image>().color = BaseColor;
                break;
        }
    }

    public void OnR2(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Debug.Log(context.interaction + " - Started");
                ButtonList[5].GetComponent<Image>().color = PressedColor;
                break;

            case InputActionPhase.Performed:
                //Debug.Log(context.interaction + " - Performed");

                if (context.interaction is SlowTapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is TapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;
                break;

            case InputActionPhase.Canceled:
                //Debug.Log(context.interaction + " - Canceled");
                if (context.interaction is TapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;

                else if (context.interaction is SlowTapInteraction)
                    ButtonList[5].GetComponent<Image>().color = BaseColor;
                break;
        }
    }



}
