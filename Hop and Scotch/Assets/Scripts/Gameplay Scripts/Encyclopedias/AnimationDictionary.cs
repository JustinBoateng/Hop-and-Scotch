using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDictionary : MonoBehaviour
{
    public static AnimationDictionary AD;

    public RuntimeAnimatorController[] AnimationArray;

    private void Awake()
    {
        if (AD == null)
        {
            DontDestroyOnLoad(gameObject);
            AD = this;
        }

        else if (AD != this)
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
}
