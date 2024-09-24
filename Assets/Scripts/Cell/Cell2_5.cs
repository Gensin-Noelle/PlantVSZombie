using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2_5 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(2, 5));
        base.Start();
    }
}
