using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class WinnerMenu : MonoBehaviour
{
    //winner icon
    //Winner visual sprite
    //Rematch Button
    //CharSelect Button
    //Exit Button
    //Win Dialoue Text Box

    public GameObject[] WinningIcons;
    public GameObject[] WinnerSprites;
    public GameObject RematchButton;
    public GameObject ExitConfirmationWinVer;
    public GameObject NoButton;
    public Text WinDialogueTextBox;
    public static WinnerMenu WM;

    public int Winner = -1;
    public bool IconSlides = false;
    public GameObject PointA;
    public GameObject PointB;
    public float InterAmount = 0.01f;
    public float InterRate = 0.05f;
    public float InterDecay = 0.001f;


    // Start is called before the first frame update
    void Start()
    {
        WM = this;
        gameObject.SetActive(false);
        WinningIcons[0].gameObject.SetActive(false);
        WinningIcons[1].gameObject.SetActive(false);
        WinningIcons[2].gameObject.SetActive(false);
        WinnerSprites[0].gameObject.SetActive(false);
        WinnerSprites[1].gameObject.SetActive(false);
        WinnerSprites[2].gameObject.SetActive(false);
        ExitConfirmationWinVer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IconSlides)
        {
            if(InterAmount <= 1)
                SlideTheWinner();
        }   
    }

    public void setupResults(int W)
    {
        Winner = W;
        WinningIcons[W].gameObject.SetActive(true);
        WinnerSprites[W].gameObject.SetActive(true);
        IconSlides = true;
    }

    public void SlideTheWinner()
    {
        InterAmount = InterAmount + InterRate;
        InterRate = InterRate - InterDecay;
        WinnerSprites[Winner].gameObject.transform.position = Vector3.Lerp(PointA.transform.position, PointB.transform.position, InterAmount);
    }

    public void Rematch()
    {
        string scene = SceneManager.GetActiveScene().ToString();
        Debug.Log(scene);
        if(GameManager.GM.NoofPlayers == 1)
        {
            SceneManager.LoadScene("SinglePlayer-GameScene");
        }

        else SceneManager.LoadScene("Multiplayer-GameScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene());

    }

    public void ExitConfirmation()
    {
        ExitConfirmationWinVer.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(NoButton);
    }

    public void DeExitConfirmation()
    {
        ExitConfirmationWinVer.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(RematchButton);
    }

    public void CharacterSelect()
    {
        GameManager.GM.FadeOutFlag = true;
    }
}
