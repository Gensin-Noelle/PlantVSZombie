using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell3_1 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(3, 1));
        base.Start();
    }
}
