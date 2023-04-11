using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectObject : MonoBehaviour
{

    [SerializeField] private string Name;
    [SerializeField] private Sprite ProfileIcon;
    [SerializeField] private RuntimeAnimatorController Animations;
    [SerializeField] private bool isUnlocked = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public RuntimeAnimatorController GetAnimation()
    {
        return Animations;
    }

    public Sprite GetProfile()
    {
        return ProfileIcon;
    }
}
