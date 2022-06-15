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

    public bool WinnerMenuPopupFlag = false;
    public float WMPTimer;
    public float WMPTRate;
    public float MaxWMPT;
    


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
        TimerSeconds = 0;
        NoofPlayers = Players.Length;
        StartCountdown = BaseCountdown;
        WinnerDecided = false;
        P1WinnerSprite.gameObject.SetActive(false);
        P2WinnerSprite.gameObject.SetActive(false);
        DrawSprite.gameObject.SetActive(false);

        WinnerMenu.WM.gameObject.SetActive(false);

        FadeInFlag = true;
        FadeOutFlag = false;
        FadeValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeInFlag && FadeValue > 0) FadeIn();
        if (FadeOutFlag && FadeValue <= 100) FadeOut();


        //Beginning Countdown
        if (StartCountdown > 0 && !FadeInFlag && !FadeOutFlag) StartCountdown = StartCountdown - CountdownRate;
        else if (StartCountdown <= 0) PlayersCanMove = true;

        //clock is active if the game has started and has not finished.
        if (PlayersCanMove && !WinnerDecided && !PauseMenu.PM.isPaused) TimerUpdate();

        if (WinnerDecided)
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
                }

                else if (Players[1].reachedGoal && !drawflag && !Decision)
                {
                    Winner = 2;
                    PlayersCanMove = false;
                    P2WinnerSprite.gameObject.SetActive(true);
                    Decision = true;
                }
            }

            else if (Players[0].reachedGoal)
            {
                Winner = 1;
                PlayersCanMove = false;
                P1WinnerSprite.gameObject.SetActive(true);
            }


            WinnerMenuPopupFlag = true;


        }

        //it should take a bit of time for the winning screen to pop up
        if (WinnerMenuPopupFlag && WMPTimer < MaxWMPT)
        {
            WMPTimer = WMPTimer + WMPTRate;
            if(WMPTimer >= MaxWMPT)
            {
                WinnerMenu.WM.gameObject.SetActive(true);
                EventSystem.current.SetSelectedGameObject(WinnerMenu.WM.RematchButton);
                WinnerMenu.WM.setupResults(Winner);
            }
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
            SceneManager.LoadScene("Character-Select-Scene");

        }
    }
}
