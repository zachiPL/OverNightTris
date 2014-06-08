using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour
{


    #region Fields

    /// <summary>
    /// The block prefabs - assign in editor
    /// </summary>
    public GameObject[] BlockPrefabs;
    public GameObject RememberBlock = null;
    public BlockBehaviour CurrentBlock;

    public static BlockControl Instance;

    #endregion

    #region MonoBehaviour Methods

    void Awake()
    {
        Instance = this;
        this.CurrentBlock = this.NextBlock().GetComponent<BlockBehaviour>();
    }

    #endregion

    #region Methods

    public GameObject NextBlock()
    {
        GameObject block = (GameObject)GameObject.Instantiate(BlockPrefabs[UnityEngine.Random.Range((int)0, this.BlockPrefabs.Length)]);
        block.transform.localPosition = new Vector2(3, 19);
        return block;
    }

    #endregion
}
