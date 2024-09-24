using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell4_4 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(4, 4));
        base.Start();
    }
}
