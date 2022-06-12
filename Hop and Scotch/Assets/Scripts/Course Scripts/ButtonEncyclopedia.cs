using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEncyclopedia : MonoBehaviour
{
    [SerializeField] private Sprite[] SpriteRefType1;
    [SerializeField] private Sprite[] SpriteRefType2;
    [SerializeField] private Sprite[] SpriteRefType3;
    [SerializeField] private Sprite[] SpriteRefType4;

    public static ButtonEncyclopedia BS;

    // Start is called before the first frame update


    private void Awake()
    {

        if (BS == null)
        {
            DontDestroyOnLoad(gameObject);
            BS = this;
        }

        else if (BS != this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite RetrieveSprite(int type, int button)
    {

        if(type == 1)
            return SpriteRefType1[button];

        else if (type == 2)
            return SpriteRefType2[button];

        else if (type == 3)
            return SpriteRefType3[button];

        else return SpriteRefType4[button];

    }
}
