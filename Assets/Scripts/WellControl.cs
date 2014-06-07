using UnityEngine;
using System.Collections;

public class WellControl
{
    #region Consts

    const int WELL_HEIGHT = 20;
    const int WELL_WIDTH = 10;

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
        }
    }

    public void FillRowByUpper(int rowToFill)
    {
        for (int j = rowToFill; j < WELL_HEIGHT; j++)
        {
            for (int i = 0; i < WELL_WIDTH; i++)
            {
                Well[i, j] = Well[i, j + 1];
            }
        }
    }

    public bool PositionTaken(int x, int y)
    {
        if (x < 0 || y < 0 || x > WELL_WIDTH)
        {
            return true;
        }
             
        return Well[x, y] > 0;
    }

}
