using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockBehaviour : MonoBehaviour
{
    public GameObject[] inner;
    public bool alterRotation;

    // Use this for initialization
    void Start()
    {
	    
    }

    /// <summary>
    /// Rotates 
    /// </summary>
    public void Rotate()
    {
        foreach (GameObject g in inner)
        {
            if (g.transform.localPosition.x == 0)
            {
                g.transform.localPosition = new Vector2(g.transform.localPosition.y, 3);
            }
            else if (g.transform.localPosition.x == 1)
            {
                if (alterRotation)
                {
                    g.transform.localPosition = new Vector2(g.transform.localPosition.y, 1);
                }
                else
                {
                    g.transform.localPosition = new Vector2(g.transform.localPosition.y, 2);
                }
            }
            else if (g.transform.localPosition.x == 3)
            {
                g.transform.localPosition = new Vector2(g.transform.localPosition.y, 0);
            }
            else if (g.transform.localPosition.x == 2)
            {
                if (alterRotation)
                {
                    g.transform.localPosition = new Vector2(g.transform.localPosition.y, 2);
                }
                else
                {
                    g.transform.localPosition = new Vector2(g.transform.localPosition.y, 1);
                }
                    
            }

        }
        Normalize();
    }

    public bool CanMove(Vector2 direction)
    {
        return true;
    }

    void Dissolve()
    {

    }

    public void Turn(WellControl well)
    {
        //if can move bottom
        bool canMoveBottom = true;
        foreach (GameObject go in this.inner)
        {
            Vector2 check = new Vector2(
                                this.transform.localPosition.x + go.transform.localPosition.x, 
                                this.transform.localPosition.y + go.transform.localPosition.y - 1
                            );
            if (well.PositionTaken(Mathf.RoundToInt(check.x), Mathf.RoundToInt(check.y)))
            {
                //boom
                canMoveBottom = false;
            }
        }
        if (canMoveBottom)
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y - 1);
        }
    }

    public List<GameObject> LeftMost()
    {
        List<GameObject> LMost = new List<GameObject>();
        float min = 4f;
        foreach (GameObject go in this.inner)
        {
            if (go.transform.localPosition.x < min)
            {
                LMost.Clear();
                min = go.transform.localPosition.x;
            }
            if (go.transform.localPosition.x == min)
            {
                LMost.Add(go);
            }
        }
        return LMost;
    }

    public void Normalize()
    {
        foreach (GameObject g in inner)
        {
            g.transform.localPosition = new Vector2(
                Mathf.RoundToInt(g.transform.localPosition.x),
                Mathf.RoundToInt(g.transform.localPosition.y)
            );
        }
    }
        

}
