using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2_4 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(2, 4));
        base.Start();
    }
}
