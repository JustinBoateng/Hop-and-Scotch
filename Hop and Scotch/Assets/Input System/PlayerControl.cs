using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float speed;
    private InputValue moveInputValue;
    private Vector2 DirectionValue;


    string output1;
    string output2;

    char Input = ' ';

    private void OnMove(InputValue Value)
    {
        moveInputValue = Value;
        Debug.Log(moveInputValue.ToString());
    }

    private void OnDirection(InputValue Value)
    {
        DirectionValue = Value.Get<Vector2>();
        Debug.Log(DirectionValue.ToString());
    }



    private void nextBlock()
    {
        output1 = DirectionValue.ToString();
        output2 = moveInputValue.ToString();
        Debug.Log(output1);
        Debug.Log(output2);
    }


    private void OnA(InputValue Value)
    {
        Input = 'A';
        Debug.Log(Input);
    }

    private void OnB(InputValue Value)
    {
        Input = 'B';
        Debug.Log(Input);
    }


    private void OnX(InputValue Value)
    {
        Input = 'X';
        Debug.Log(Input);
    }

    private void OnY(InputValue Value)
    {
        Input = 'Y';
        Debug.Log(Input);
    }


    private void OnL(InputValue Value)
    {
        Input = 'L';
        Debug.Log(Input);

    }

    private void OnR(InputValue Value)
    {
        Input = 'R';
        Debug.Log(Input);

    }

    private void FixedUpdate()
    {
    }

}
