using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2_0 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(2, 0));
        base.Start();
    }
}
