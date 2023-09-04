using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnTech : MonoBehaviour
{
    public Vector2 TopRightCorner;
    public Vector2 BottomLeftCorner;


    public Collider2D[] results;
    public Collider2D[] resultsStored;

    public int num_colliders;

    public LayerMask chosenlayer;
    public LayerMask ALayer;
    public LayerMask BLayer;
    public LayerMask XLayer;
    public LayerMask YLayer;
    
    public int A_colliders;
    public Collider2D[] A_results;
    public int B_colliders;
    public Collider2D[] B_results;
    public int X_colliders;
    public Collider2D[] X_results;
    public int Y_colliders;
    public Collider2D[] Y_results;

    public bool LockOnActive;
    //public float LockOnSize;
    public Vector2 LockOnMaxSize = new Vector2(3,3);
    public Vector2 GrowthRate;




    private void Start()
    { 
        Clear();
    }

private void Update()
    {
        if(this.enabled)
            RectangleGrow();

        {
            Collider2D[] colliders = Physics2D.OverlapAreaAll(
                new Vector2(transform.position.x, transform.position.y) + TopRightCorner,
                new Vector2(transform.position.x, transform.position.y) + BottomLeftCorner,
                chosenlayer);


            num_colliders = Physics2D.OverlapAreaNonAlloc(
                new Vector2(transform.position.x, transform.position.y) + TopRightCorner,
                new Vector2(transform.position.x, transform.position.y) + BottomLeftCorner,
                results,
                chosenlayer);

            A_colliders = Physics2D.OverlapAreaNonAlloc(
                new Vector2(transform.position.x, transform.position.y) + TopRightCorner,
                new Vector2(transform.position.x, transform.position.y) + BottomLeftCorner,
                A_results,
                ALayer);
            B_colliders = Physics2D.OverlapAreaNonAlloc(
                new Vector2(transform.position.x, transform.position.y) + TopRightCorner,
                new Vector2(transform.position.x, transform.position.y) + BottomLeftCorner,
                B_results,
                BLayer);
            X_colliders = Physics2D.OverlapAreaNonAlloc(
                new Vector2(transform.position.x, transform.position.y) + TopRightCorner,
                new Vector2(transform.position.x, transform.position.y) + BottomLeftCorner,
                X_results,
                XLayer);
            Y_colliders = Physics2D.OverlapAreaNonAlloc(
                new Vector2(transform.position.x, transform.position.y) + TopRightCorner,
                new Vector2(transform.position.x, transform.position.y) + BottomLeftCorner,
                Y_results,
                YLayer);
        }
 
    }

    private void RectangleGrow()
    {
        if(Mathf.Abs(TopRightCorner.x) < LockOnMaxSize.x ||
            Mathf.Abs(TopRightCorner.y) < LockOnMaxSize.y ||
            Mathf.Abs(BottomLeftCorner.x) < LockOnMaxSize.x ||
            Mathf.Abs(BottomLeftCorner.y) < LockOnMaxSize.y)
        {
            TopRightCorner = TopRightCorner + GrowthRate;
            BottomLeftCorner = BottomLeftCorner - GrowthRate;
        }
    }


    private void OnDrawGizmos()
    {
        LockOnField.DrawRectangle(this.gameObject, 
            new Vector2(transform.position.x, transform.position.y) + TopRightCorner,
            new Vector2(transform.position.x, transform.position.y) + BottomLeftCorner);
    }

    public void Activate()
    {
        for (int i = 0; i < num_colliders; i++)
        {
            //Debug.Log(results[i].GetComponent<Target>().Label);
            //results[i].GetComponent<Target>().RevealRectacle();
            
        }
    }

  
    public Vector2 HomingHop(char Label, GameObject Player)
    {
        float Target1;
        float Target2;
        switch (Label)
        {
            case 'A':
                if (!A_results[0]) return Player.transform.position;

                Target1 = (Player.transform.position - A_results[0].transform.position).magnitude;

                if (!A_results[1]) return A_results[0].transform.position;

                Target2 = (Player.transform.position - A_results[1].transform.position).magnitude;

                if (Target1 <= Target2) return A_results[0].transform.position;

                else return A_results[1].transform.position;

                break;

            case 'B':
                if (!B_results[0]) return Player.transform.position;

                Target1 = (Player.transform.position - B_results[0].transform.position).magnitude;

                if (!B_results[1]) return B_results[0].transform.position;

                Target2 = (Player.transform.position - B_results[1].transform.position).magnitude;

                if (Target1 <= Target2) return B_results[0].transform.position;

                else return B_results[1].transform.position;

                break;

            case 'X':
                if (!X_results[0]) return Player.transform.position;

                Target1 = (Player.transform.position - X_results[0].transform.position).magnitude;

                if (!X_results[1]) return X_results[0].transform.position;

                Target2 = (Player.transform.position - X_results[1].transform.position).magnitude;

                if (Target1 <= Target2) return X_results[0].transform.position;

                else return X_results[1].transform.position;

                break;

            case 'Y':
                if (!Y_results[0]) return Player.transform.position;

                Target1 = (Player.transform.position - Y_results[0].transform.position).magnitude;

                if (!Y_results[1]) return Y_results[0].transform.position;

                Target2 = (Player.transform.position - Y_results[1].transform.position).magnitude;

                if (Target1 <= Target2) return Y_results[0].transform.position;

                else return Y_results[1].transform.position;

                break;
        }

        return Player.transform.position;
    }

    public void Clear()
    {
        //resultsStored = results;

        for (int i = 0; i < num_colliders; i++)
        {
            //Debug.Log(results[i].GetComponent<Target>().Label);
            //results[i].GetComponent<Target>().ConcealRectacle();
            //resultsStored[i].GetComponent<Target>().ConcealRectacle();
        }

        results = new Collider2D[4];

        
        A_results = new Collider2D[2];
        B_results = new Collider2D[2];
        X_results = new Collider2D[2];
        Y_results = new Collider2D[2];
        
        A_colliders = 0;
        B_colliders = 0;
        X_colliders = 0;
        Y_colliders = 0;

        LockOnActive = false;
        TopRightCorner = Vector2.zero;
        BottomLeftCorner = Vector2.zero;

    }

    public void EscapeLock(char label, GameObject Target)
    {
        string Targetname = Target.name;

        switch (label) {

            case 'A':
                if ( A_results[0] && A_results[0].name == Targetname)
                {
                    Debug.Log("That was an A Target 1st slot");
                    A_results[0] = null;
                }

                else if (A_results[1] && A_results[1].name == Targetname)
                {
                    Debug.Log("That was an A Target 2nd slot");
                    A_results[1] = null;
                }

                break;

            case 'B':
                if (B_results[0] && B_results[0].name == Targetname)
                {
                    Debug.Log("That was an B Target 1st slot");

                    B_results[0] = null;
                }

                else if (B_results[1] && B_results[1].name == Targetname)
                {
                    Debug.Log("That was an B Target 2st slot");

                    B_results[1] = null;
                }

                break;

            case 'X':
                if (X_results[0] && X_results[0].name == Targetname)
                {
                    Debug.Log("That was an X Target 1st slot");

                    X_results[0] = null;
                }

                else if (X_results[1] && X_results[1].name == Targetname)
                {
                    Debug.Log("That was an X Target 2st slot");

                    X_results[1] = null;
                }

                break;

            case 'Y':
                if (Y_results[0] && Y_results[0].name == Targetname)
                {
                    Debug.Log("That was an Y Target 1st slot");

                    Y_results[0] = null;
                }

                else if (Y_results[1] && Y_results[1].name == Targetname)
                {
                    Debug.Log("That was an Y Target 2nd slot");

                    Y_results[1] = null;
                }

                break;



        }
    }
}
