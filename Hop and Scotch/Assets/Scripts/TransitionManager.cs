using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager TM;

    public string[] PlayerAnimationCodes;


    private void Awake()
    {
        if (TM == null)
        {
            DontDestroyOnLoad(gameObject);
            TM = this;
        }

        else if (TM != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
