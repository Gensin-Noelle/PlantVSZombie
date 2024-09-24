using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell4_5 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(4, 5));
        base.Start();
    }
}
