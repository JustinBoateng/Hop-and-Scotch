using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMenuManager : MonoBehaviour
{
    int currentChar = 0;
    [SerializeField] ArcadeChar[] Characters;

    [SerializeField] GameObject currAnimation;
    [SerializeField] Sprite currProfile;
    [SerializeField] Sprite currArt;

    // Start is called before the first frame update
    void Start()
    {
        //FrameUpdate(currentChar)

    }

    // Update is called once per frame
    void Update()
    {

        //update the currently selected ArcadeChar depending on the input
        /*if input goes to right, 
                if(currentChar < Characters.length-1) currentChar++;    
                else currentChar = 0;
                FrameUpdate(currentChar)

          if input goes to left
                if(currentChar > 0) currentChar--;    
                else currentChar = Characters.length-1;
                FrameUpdate(currentChar)
         */

    }

    public void FrameUpdate(int i)
    {
        currProfile = Characters[i].CharacterProfile;
        currAnimation.GetComponent<Animator>().runtimeAnimatorController = AnimationDictionary.AD.SpriteRetrieval(Characters[i].AnimationCode);
        currArt = Characters[i].CharacterArt;
    }
}
