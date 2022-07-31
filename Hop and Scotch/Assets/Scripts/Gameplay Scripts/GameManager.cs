using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public static GameManager GM;

    public Player[] Players;
    public int NoofPlayers;

    public int Winner = -1;
    public bool WinnerDecided = false;
    public bool drawflag = false;
    public bool noDraw = false;
    public bool Decision = false;

    public bool PlayersCanMove;

    public float StartCountdown = 3;
    public float CountdownRate = 0.03f;
    public float BaseCountdown = 3;

    public float TimerMilliSeconds=0;
    public int TimerSeconds = 0;
    public int TimerMinutes = 0;
    //public string printedTime = "0:00:00";

    public Text Clock;

    public GameObject P1WinnerSprite;
    public GameObject P2WinnerSprite;
    public GameObject DrawSprite;
    public Image FadeToBlack;
    public float FadeValue = 1;
    public float FadeRate = 0.01f;
    public bool FadeInFlag;
    public bool FadeOutFlag;

    public WinnerMenu WM;
    public bool WinnerMenuPopupFlag = false;
    public float WMPTimer;
    public float WMPTRate;
    public float MaxWMPT;

    public bool ResetFlag = false;

    public string playeronecode;
    public string playertwocode;

    private void Awake()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }

        else if (GM != this)
            Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        EstablishPlayers();

        TimerSeconds = 0;
        NoofPlayers = Players.Length;

        StartCountdown = BaseCountdown;
        WinnerDecided = false;
        WMPTimer = 0;
        WinnerMenuPopupFlag = false;

        P1WinnerSprite.gameObject.SetActive(false);
        P2WinnerSprite.gameObject.SetActive(false);
        DrawSprite.gameObject.SetActive(false);

        //WM = WinnerMenu.WM;
        //Debug.Log("Hidding Win Screen");
        WM.Reset();
        WM.gameObject.SetActive(false);
        FadeInFlag = true;
        FadeOutFlag = false;
        FadeValue = 1;

        Winner = -1;
        Decision = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (FadeInFlag && FadeValue > 0) FadeIn();
        if (FadeOutFlag && FadeValue <= 100) FadeOut();


        //Beginning Countdown
        if (StartCountdown > 0 && !FadeInFlag && !FadeOutFlag) StartCountdown = StartCountdown - CountdownRate;
        else if (StartCountdown <= 0 && !WinnerDecided) PlayersCanMove = true;

        //clock is active if the game has started and has not finished.
        if (PlayersCanMove && !WinnerDecided && !PauseMenu.PM.isPaused) TimerUpdate();

        if (WinnerDecided && !WinnerMenuPopupFlag && (WMPTimer < MaxWMPT)) //three checks are necessary to make sure these if-else statements don't leave variables open to repeating the cycle
        {
            if (NoofPlayers > 1)
            {
                if (Players[0].reachedGoal && Players[1].reachedGoal && !Decision)
                {
                    Winner = 0;
                    PlayersCanMove = false;
                    DrawSprite.gameObject.SetActive(true);
                    drawflag = true;
                    Decision = true;
                }

                else if (Players[0].reachedGoal && !drawflag && !Decision)
                {
                    Winner = 1;
                    PlayersCanMove = false;
                    P1WinnerSprite.gameObject.SetActive(true);
                    Decision = true;
                    Players[0].Win = true;
                    Players[1].Lose = true;
                }

                else if (Players[1].reachedGoal && !drawflag && !Decision)
                {
                    Winner = 2;
                    PlayersCanMove = false;
                    P2WinnerSprite.gameObject.SetActive(true);
                    Decision = true;
                    Players[1].Win = true;
                    Players[0].Lose = true;
                }
            }

            else if (NoofPlayers == 1 && Players[0].reachedGoal)
            {
                Winner = 1;
                PlayersCanMove = false;
                P1WinnerSprite.gameObject.SetActive(true);
                Players[0].Win = true;
            }


            WinnerMenuPopupFlag = true;
            WM.setupResults(Winner);

        }

        //it should take a bit of time for the winning screen to pop up
        if (WinnerMenuPopupFlag && WMPTimer < MaxWMPT)
        {
            WMPTimer = WMPTimer + WMPTRate;
           
        }

        else if (WinnerMenuPopupFlag && WMPTimer >= MaxWMPT)
        {
            //Debug.Log("Win Screen Pops up");
            WM.gameObject.SetActive(true);
            //WM.setupResults(Winner);
            WM.SlideTheWinner();
            EventSystem.current.SetSelectedGameObject(WinnerMenu.WM.RematchButton);
            WinnerMenuPopupFlag = false;
        }


    }

    public void TimerUpdate()
    {

        if(TimerMilliSeconds < 0.98)
        TimerMilliSeconds = TimerMilliSeconds + Time.deltaTime;

        else
        {
            TimerSeconds++;
            TimerMilliSeconds = 0;
        }
        if(TimerSeconds >= 60)
        {
            TimerMinutes++;
            TimerSeconds = 0;
        }

        Clock.text = TimerMinutes.ToString() + ":" + TimerSeconds.ToString("00") + ":" + (TimerMilliSeconds * 100).ToString("00");
    }

    public void FadeIn()
    {
        if ((FadeValue - FadeRate) > 0)
            FadeValue = FadeValue - FadeRate;
        else FadeValue = 0;

        FadeToBlack.canvasRenderer.SetColor(new Color(1, 1, 1, FadeValue));

        if (FadeValue <= 0) {
            FadeInFlag = false;
            FadeToBlack.gameObject.SetActive(false);
        }
    }

    public void FadeOut()
    {
        FadeToBlack.gameObject.SetActive(true);
        if ((FadeValue + FadeRate) < 1)
            FadeValue = FadeValue + FadeRate;
        else FadeValue = 1;

        FadeToBlack.canvasRenderer.SetColor(new Color(1, 1, 1, FadeValue));

        if (FadeValue >= 1)
        {
            FadeOutFlag = false;
            //SceneManager.LoadScene("Character-Select-Scene");

            if (ResetFlag)
            {
                if (NoofPlayers == 1)
                    ResetSinglePlayer();
                else ResetMultiPlayer();
            }

            FadeInFlag = true;

        }
    }

    public void ResetSinglePlayer()
    {
        //fade out
        //put the player back at the starting position
        //put the pointer back at the starting position

        Players[0].CourseRef.InitializePos();
        Players[0].reachedGoal = false;
        ResetFlag = false;
        WM.Reset();
        Start();
        EventSystem.current.SetSelectedGameObject(null); //always set the setselectedgameobject to null when setting off the menu
                                                         //WM.gameObject.SetActive(false);

        Players[0].Win = false;
        Players[0].Lose = false;

        TimerSeconds = 0;
        TimerMinutes = 0;
        TimerMilliSeconds = 0;
        TimerUpdate();
    }

    public void ResetMultiPlayer()
    {
        //fade out
        //put the player back at the starting position
        //put the pointer back at the starting position

        Players[0].CourseRef.InitializePos();
        Players[0].reachedGoal = false;
        Players[1].CourseRef.InitializePos();
        Players[1].reachedGoal = false;

        Players[0].Win = false;
        Players[0].Lose = false;
        Players[1].Win = false;
        Players[1].Lose = false;

        ResetFlag = false;
        WM.Reset();
        Start();
        EventSystem.current.SetSelectedGameObject(null);
        //WM.gameObject.SetActive(false);

        TimerSeconds = 0;
        TimerMinutes = 0;
        TimerMilliSeconds = 0;
        TimerUpdate();

    }

    public void SetCodes(string firstplayer, string secondplayer)
    {
        playeronecode = firstplayer;
        playertwocode = secondplayer;

    }//this is activated in the CharMenu

    public void EstablishPlayers()
    {


        Players[0].GetAnimation(TransitionManager.TM.GetAnimationCodes(0));
        Players[0].SetAnimation();

        Players[1].GetAnimation(TransitionManager.TM.GetAnimationCodes(1));
        Players[1].SetAnimation();

    }//this is activated at the start of the Game Scene
}
