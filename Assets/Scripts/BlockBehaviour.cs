using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockBehaviour : MonoBehaviour
{
    public GameObject[] inner;
    public bool alterRotation;
    public int randXMin = 0;
    public int randXMax = 6;

    // Use this for initialization
    void Start()
    {
	    
    }

    /// <summary>
    /// Rotates 
    /// </summary>
    public void Rotate(WellControl well)
    {
        bool CanRotate = true;
        if (well != null)
        {
            foreach (GameObject g in inner)
            {
                if (g.transform.localPosition.x == 0)
                {
                    if (well.PositionTaken(Mathf.FloorToInt(this.transform.localPosition.x + g.transform.localPosition.y), Mathf.FloorToInt(this.transform.localPosition.y + 3)))
                    {
                        CanRotate = false;
                    }
                }
                else if (g.transform.localPosition.x == 1)
                {
                    if (alterRotation)
                    {
                        if (well.PositionTaken(Mathf.FloorToInt(this.transform.localPosition.x + g.transform.localPosition.y), Mathf.FloorToInt(this.transform.localPosition.y + 1)))
                        {
                            CanRotate = false;
                        }
                    }
                    else
                    {
                        if (well.PositionTaken(Mathf.FloorToInt(this.transform.localPosition.x + g.transform.localPosition.y), Mathf.FloorToInt(this.transform.localPosition.y + 2)))
                        {
                            CanRotate = false;
                        }
                    }
                }
                else if (g.transform.localPosition.x == 3)
                {
                    if (well.PositionTaken(Mathf.FloorToInt(this.transform.localPosition.x + g.transform.localPosition.y), Mathf.FloorToInt(this.transform.localPosition.y)))
                    {
                        CanRotate = false;
                    }
                }
                else if (g.transform.localPosition.x == 2)
                {
                    if (alterRotation)
                    {
                        if (well.PositionTaken(Mathf.FloorToInt(this.transform.localPosition.x + g.transform.localPosition.y), Mathf.FloorToInt(this.transform.localPosition.y + 2)))
                        {
                            CanRotate = false;
                        }
                    }
                    else
                    {
                        if (well.PositionTaken(Mathf.FloorToInt(this.transform.localPosition.x + g.transform.localPosition.y), Mathf.FloorToInt(this.transform.localPosition.y + 1)))
                        {
                            CanRotate = false;
                        }
                    }
                }
            }
        }
        if (CanRotate)
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
        }
    }

    public void TryMoveLeft(WellControl well)
    {
        bool canMoveLeft = true;
        foreach (GameObject go in this.inner)
        {
            Vector2 check = new Vector2(
                                this.transform.localPosition.x + go.transform.localPosition.x - 1, 
                                this.transform.localPosition.y + go.transform.localPosition.y
                            );
            if (well.PositionTaken(Mathf.RoundToInt(check.x), Mathf.RoundToInt(check.y)))
            {
                //boom
                canMoveLeft = false;
            }
        }
        if (canMoveLeft)
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x - 1, this.transform.localPosition.y);
        }
    }

    public void TryMoveRight(WellControl well)
    {
        bool canMoveRight = true;
        foreach (GameObject go in this.inner)
        {
            Vector2 check = new Vector2(
                                this.transform.localPosition.x + go.transform.localPosition.x + 1, 
                                this.transform.localPosition.y + go.transform.localPosition.y
                            );
            if (well.PositionTaken(Mathf.RoundToInt(check.x), Mathf.RoundToInt(check.y)))
            {
                canMoveRight = false;
            }
        }
        if (canMoveRight)
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x + 1, this.transform.localPosition.y);
        }
    }

    void Dissolve()
    {

    }

    /// <summary>
    /// Falling
    /// </summary>
    /// <param name="well">Well.</param>
    public void OnTurn(WellControl well)
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

    #if UNITY_EDITOR
    /// <summary>
    /// Used from editor
    /// </summary>
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
    #endif

}
