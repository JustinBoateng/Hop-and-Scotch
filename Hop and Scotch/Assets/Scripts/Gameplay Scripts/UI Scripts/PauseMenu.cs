using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    //if the pause menu is pressed, set this object to active and set the Resume Button to be the currently selected button
    //if Resume is pressed, go back to the game
    //if the exit button is pressed, disable the resume and exit buttons and set the Exit Confirmation object to active, and THEN set the currently selected button to No
    //if No is pressed, enable the Resume and exit buttons, then deactivate the Exit Confirmation Object
    //if Yes is pressed, go back to Character Select

    public GameObject Menu;
    public GameObject ResumeButton;
    public GameObject ExitButton;
    public GameObject ExitConfirmation;
    public GameObject YesLeave;
    public GameObject NoStay;

    public bool isPaused;
    public static PauseMenu PM;

    public Player[] PlayerReferences;

    // Start is called before the first frame update
    void Start()
    {
        PM = this;
        ResumeButton.GetComponent<Button>().enabled = false;
        ExitButton.GetComponent<Button>().enabled = false;
        Menu.gameObject.SetActive(false);
        ExitConfirmation.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        isPaused = true;

        Debug.Log("Pausing");
        PlayerReferences[0].PIRef.SwitchCurrentActionMap("UI");
        if (PlayerReferences.Length > 1)
            PlayerReferences[1].PIRef.SwitchCurrentActionMap("UI");

        Menu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        ResumeButton.GetComponent<Button>().enabled = true;
        ExitButton.GetComponent<Button>().enabled = true;
        ExitConfirmation.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(ResumeButton);
    }

    public void Resume()
    {
        Debug.Log("using PauseMenu Function");

        isPaused = false;

        PlayerReferences[0].PIRef.SwitchCurrentActionMap("PlayerOne-Game");

        if (PlayerReferences.Length > 1)
        {
            PlayerReferences[0].PIRef.SwitchCurrentActionMap("Game");
            PlayerReferences[1].PIRef.SwitchCurrentActionMap("Game");
        }
        Debug.Log("Action Map is " + PlayerReferences[0].PIRef.currentActionMap);
        Debug.Log("Unpausing");
        EventSystem.current.SetSelectedGameObject(null); //set the selected button to null so that the game can reselect the Resume button when pausing again
        ResumeButton.GetComponent<Button>().enabled = false;
        ExitButton.GetComponent<Button>().enabled = false;
        Menu.gameObject.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ExitMenu()
    {
        ExitConfirmation.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(NoStay);
        ResumeButton.GetComponent<Button>().enabled = false;
        ExitButton.GetComponent<Button>().enabled = false;
    }


}
