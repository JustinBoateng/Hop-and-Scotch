using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //use to use the UI elements
using UnityEngine.InputSystem; //use to use the Input System Code and allow rebinding to occur
using UnityEngine.EventSystems; //use  to use the events of buttons

public class RebindScript : MonoBehaviour
{
    [SerializeField] private InputActionReference ActionToRemap;
    //use to store the action you want to remap. you'll need 1 of these per action to be remapped

    [SerializeField] private Text buttonText;
    //get rid of the text from the button in our scene

    [SerializeField] private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    //stores the rebinding class that acts as a config interface and controller while rebind is ongoing. use for garbage collection

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRebinding()
    {
        GameObject ButtonRef = EventSystem.current.currentSelectedGameObject;
        EventSystem.current.SetSelectedGameObject(null);
        //this deselects the currently selected UI button to prevent the rebinding operation from trigger again when a button is pressed

        ActionToRemap.action.Disable();
        //Action needs to be disabled first to be able to allow rebinding

        string originalText = buttonText.text;
        buttonText.text = "?";
        //setting text of button to give player message


        //storing our interactive rebind class to dispose later. This is for garbage collection
        rebindingOperation = ActionToRemap.action.PerformInteractiveRebinding()


            //once a match is found for the rebinding, wait this period of time to search if this is a better match before committing the change
            .OnMatchWaitForAnother(0.1f)

            //this will run after the rebinding is completed
            .OnComplete(

                //this is a Lambda Expression
                operation =>
                {
                    //set the text of the button to display the new button mapped
                    buttonText.text = InputControlPath.ToHumanReadableString(
                                                            ActionToRemap.action.bindings[0].effectivePath,
                                                            InputControlPath.HumanReadableStringOptions.OmitDevice);
                    
                    //dispose of the rebinding operation to help with garbage collection
                    rebindingOperation.Dispose();

                    //need to renable the action to be able to use
                    ActionToRemap.action.Enable();
                }
            )

            .Start();
        EventSystem.current.SetSelectedGameObject(ButtonRef);
    }
}
