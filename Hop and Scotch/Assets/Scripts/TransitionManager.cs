using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class TransitionManager : MonoBehaviour
{
    public static TransitionManager TM;

    public string[] PlayerAnimationCodes;

    public Image FadeScreen;
    public float FadeValue = 1;
    public float FadeRate = 0.01f;
    public bool FadeInFlag;
    public bool FadeOutFlag;

    public string NextScene = "N/A";

    private void Awake()
    {
        if (TM == null)
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(FadeScreen);
            TM = this;
        }

        else if (TM != this)
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in transform)
        {
            FadeScreen = child.transform.GetComponent<Image>();
        }

        FadeInFlag = true;
        FadeOutFlag = false;
        FadeValue = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (FadeInFlag && FadeValue > 0) FadeIn();
        if (FadeOutFlag && FadeValue <= 1) FadeOut();
        //other classes trigger the fadeIn/FadeOut flags.
        //100 means the black screen is fully there. > 0 checks for that very case.
        //0 means the black screen is completely see through. <= checks for that before fading out (fading to black)
    }

    public void SetAnimationCodes (string A, string B)
    {
        PlayerAnimationCodes[0] = A;
        PlayerAnimationCodes[1] = B;
    }

    public string GetAnimationCodes (int i)
    {
        return PlayerAnimationCodes[i];
    }

    public void FadeIn()
    {
        if ((FadeValue - FadeRate) > 0)
            FadeValue = FadeValue - FadeRate;
        else FadeValue = 0;

        FadeScreen.canvasRenderer.SetColor(new Color(1, 1, 1, FadeValue));

        if (FadeValue <= 0)
        {
            FadeInFlag = false;
            FadeScreen.gameObject.SetActive(false);
        }
    }

    public void FadeOut()
    {
        FadeScreen.gameObject.SetActive(true);
        if ((FadeValue + FadeRate) < 1)
            FadeValue = FadeValue + FadeRate;
        else FadeValue = 1;

        FadeScreen.canvasRenderer.SetColor(new Color(1, 1, 1, FadeValue));

        if (FadeValue >= 1)
        {
            FadeOutFlag = false;
            FadeInFlag = true;

            if (GameManager.GM)
            {
                if (GameManager.GM.ResetFlag && GameManager.GM.NoofPlayers == 1) GameManager.GM.ResetSinglePlayer();
                else if (GameManager.GM.ResetFlag && GameManager.GM.NoofPlayers == 2) GameManager.GM.ResetMultiPlayer();
                else
                {
                    GameObject.Destroy(GameManager.GM.gameObject);
                    SceneManager.LoadScene(NextScene);

                }

            }//if You're trying to reset the stage or move out of the scene given that the scene you're exiting had a GameManager

            else SceneManager.LoadScene(NextScene);
            //if your moving from a scene that didnt have a game manager, like, say, the MainMenu or CharMenu
        }
    }

    public void MultiPlayerTransition()
    {
        //set the Character codes to the TransitionManager

        //Go to the next Scene


        FadeOutFlag = true;
        NextScene = "MultiPlayer-GameScene";

        //The GameManager sets the Codes to the players at Start
    }

    public void SinglePlayerTransition()
    {
        //set the Character codes to the TransitionManager

        //Go to the next Scene


        FadeOutFlag = true;
        NextScene = "SinglePlayer-GameScene";

        //The GameManager sets the Codes to the players at Start
    }

    public void Exit()
    {
        FadeOutFlag = true;
        NextScene = "TitleandMain-Scene";
    }

    public void CharSelect()
    {
        FadeOutFlag = true;
        NextScene = "Character-Select-Scene";
    }

    public void SingleCharSelect()
    {
        FadeOutFlag = true;
        NextScene = "SingleCharacter-Select-Scene";
    }
}
