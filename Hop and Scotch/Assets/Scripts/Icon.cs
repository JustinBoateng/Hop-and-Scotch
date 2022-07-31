using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public string Name;
    public Sprite Visual;
    public string Description;
    public string[] Code;

    public string getName()
    {
        return Name;
    }

    public string getDesc()
    {
        return Description;
    }

    public string getCode(int i)
    {
        return Code[i];
    }

    public Sprite getSprite()
    {
        return Visual;
    }
}
