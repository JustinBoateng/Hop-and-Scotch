using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class CharSelectArray : MonoBehaviour
{
    public CharSelectObject[] ArcadeList;

    public Sprite CurrProfile;
    public RuntimeAnimatorController CurrAnimation;

    public int Current = 0;

    public Animator PlayerSprite;
    public Image PlayerProfile;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        Current = 0;
        if (Current >= ArcadeList.Length) Current = 0;
        CurrAnimation = ArcadeList[Current].GetAnimation();
        CurrProfile = ArcadeList[Current].GetProfile();


        PlayerProfile.sprite = CurrProfile;
        PlayerSprite.runtimeAnimatorController = CurrAnimation;
    }

    public void RightSelect()
    {
        Current++;
        if (Current >= ArcadeList.Length) Current = 0;
        CurrAnimation = ArcadeList[Current].GetAnimation();
        CurrProfile = ArcadeList[Current].GetProfile();


        PlayerProfile.sprite = CurrProfile;
        PlayerSprite.runtimeAnimatorController = CurrAnimation;
    }

    public void LeftSelect()
    {
        Current--;
        if (Current < 0) Current = ArcadeList.Length-1;
        CurrAnimation = ArcadeList[Current].GetAnimation();
        CurrProfile = ArcadeList[Current].GetProfile();

        PlayerProfile.sprite = CurrProfile;
        PlayerSprite.runtimeAnimatorController = CurrAnimation;
    }

}
