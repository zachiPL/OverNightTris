using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    public WellControl well;

    void OnMouseUpAsButton()
    {
        BlockBehaviour bc = BlockControl.Instance.CurrentBlock;
        if (this.name.Equals ("ArrBottom")) {
            //currentBlock.FastDown()
            bc.OnTurn (this.well);
        } else if (this.name.Equals ("ArrRight")) {
            bc.TryMoveRight (this.well);
        } else if (this.name.Equals ("ArrLeft")) {
            bc.TryMoveLeft (this.well);
        } else if (this.name.Equals ("Rotate")) {
            bc.Rotate (this.well);
        }
    }


}
