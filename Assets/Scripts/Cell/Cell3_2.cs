using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell3_2 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(3, 2));
        base.Start();
    }
}
