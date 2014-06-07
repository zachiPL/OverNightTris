using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour
{

    #region Fields

    /// <summary>
    /// The block prefabs - assign in editor
    /// </summary>
    public GameObject[] BlockPrefabs;
    private GameObject RememberBlock = null;

    #endregion

    #region Methods

    public GameObject NextBlock()
    {
        return BlockPrefabs[UnityEngine.Random.Range((int)0, this.BlockPrefabs.Length)];
    }

    #endregion
}
