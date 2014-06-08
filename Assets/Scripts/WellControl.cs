using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class WellControl : MonoBehaviour
{
    #region Consts

    const int WELL_HEIGHT = 20;
    const int WELL_WIDTH = 10;

    //TODO: refactor, kinds of doubles Well ...
    //TODO: switch Vec2 to point(int x, int y)
    //TODO: get rid of Well[, ], use blocks only
    public Dictionary<Vector2, GameObject> blocks = new Dictionary<Vector2, GameObject>();

    public GameObject SingleBlock;

    #endregion

    /// <summary>
    /// The well.
    /// [0, 0] is left bottom corner.
    /// </summary>
    /// 
    public int[,] Well;

    public WellControl()
    {
        this.Well = new int[WELL_WIDTH, WELL_HEIGHT];
        //zero them
        for (int i = 0; i < WELL_WIDTH; i++)
        {
            for (int j = 0; j < WELL_HEIGHT; j++)
            {
                Well[i, j] = 0;
            }
        }
    }


    public void WhenDropped()
    {
        for (int i = 0; i < WELL_HEIGHT; i++)
        {
            while (CheckRow(i))
            {
                FillRowByUpper(i);
            }
        }
    }

    public bool CheckRow(int row)
    {
        for (int i = 0; i < WELL_WIDTH; i++)
        {
            if (Well[i, row] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteRow(int row)
    {
        for (int i = 0; i < WELL_WIDTH; i++)
        {
            Well[i, row] = 0;
            GameObject.Destroy(this.blocks[new Vector2(i, row)]);
            this.blocks.Remove(new Vector2(i, row));
        }
    }

    public void FillRowByUpper(int rowToFill)
    {
        for (int j = rowToFill; j < WELL_HEIGHT - 1; j++)
        {
            for (int i = 0; i < WELL_WIDTH; i++)
            {
                Well[i, j] = Well[i, j + 1];
                Vector2 d = new Vector2(i, j + 1);
                if (this.blocks.ContainsKey(d))
                {
                    GameObject g = this.blocks[d];
                    this.blocks.Remove(d);
                    this.blocks.Add(new Vector2(i, j), g);
                }
            }
        }
    }

    public bool PositionTaken(int x, int y)
    {
        if (x < 0 || y < 0 || x >= WELL_WIDTH)
        {
            return true;
        }
        try
        {
            return Well[x, y] > 0;
        }
        catch (Exception e)
        {
            Debug.Log("INDEX: " + x + ", " + y);
            return false;
        }
    }

    public void AddBlock(int x, int y)
    {
        GameObject newBlock = (GameObject)GameObject.Instantiate(this.SingleBlock, new Vector2(x, y), Quaternion.identity);
        newBlock.transform.parent = this.transform;
        this.blocks.Add(new Vector2(x, y), newBlock);
        this.Well[x, y] = 1;
    }
}
