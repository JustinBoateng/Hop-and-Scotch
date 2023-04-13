using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Title Screen Batch
    //Main Menu Batch
    //Options Batch
    //ButtonMapping Batch

    //When a button is Pressed, and Only the Title Screen Batch is Active have the Title Screen Batch be Unactive and set the Main Menu batch to be active
    //When the Cancel button is pressed and the only thing active is the Main Menu Batch, Have the Title Screen Batch Be Active

    public GameObject TitleScreenBatch;
    public GameObject MainMenuBatch;
    public GameObject OptionsBatch;
    public GameObject ButtonMappingBatch;
    public GameObject ExitConfirmationBatch;

    public GameObject ArcadeMenuBatch;
    public GameObject CharacterSelectBatch;
    public GameObject CSGraphicsBatch;
    public GameObject StageSelectBatch;

    public GameObject FirstMainMenuButton;

    public Vector2 BMBActivePosition;
    public Vector2 BMBDeactivePosition;
    public Button[] BMBList;
    public bool BMBState = false;

    // Start is called before the first frame update
    void Start()
    {
        TitleScreenBatch.SetActive(true);
        MainMenuBatch.SetActive(false);
        OptionsBatch.SetActive(false);
        ExitConfirmationBatch.SetActive(false);

        ArcadeMenuBatch.SetActive(false);
        CharacterSelectBatch.SetActive(false);
        CSGraphicsBatch.SetActive(false);
        StageSelectBatch.SetActive(false);

        DeInteract();

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void CharacterSelect(int n)
    {
        TransitionManager.TM.CharSelect(n);
    }//Multiplayer

    public void OnStart(InputAction.CallbackContext context)
    {
        if(context.canceled)
            if (!MainMenuBatch.activeSelf && !OptionsBatch.activeSelf && !BMBState)
            {
                Debug.Log("Start was Pressed");
                TitleScreenBatch.SetActive(false);
                MainMenuBatch.SetActive(true);
                EventSystem.current.SetSelectedGameObject(FirstMainMenuButton);
            }
    } // this code handles the transition from the title screen to the main menu

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            if (MainMenuBatch.activeSelf && !TitleScreenBatch.activeSelf && !BMBState && !OptionsBatch.activeSelf)
            {
                MainMenuBatch.SetActive(false);
                TitleScreenBatch.SetActive(true);
            }//from main menu to Title Screen

            if (MainMenuBatch.activeSelf && !TitleScreenBatch.activeSelf && !BMBState && !OptionsBatch.activeSelf)
            {
                MainMenuBatch.SetActive(true);
                OptionsBatch.SetActive(false);
                EventSystem.current.SetSelectedGameObject(FirstMainMenuButton);
            }//from Options to Main Menu
        }
    }

    public void DeInteract()
    {
        ButtonMappingBatch.SetActive(false);
        BMBState = false;
    }

    public void SetInteract()
    {
        ButtonMappingBatch.SetActive(true);
        BMBState = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
