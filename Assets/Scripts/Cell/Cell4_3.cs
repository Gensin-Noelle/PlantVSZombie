using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell4_3 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(4, 3));
        base.Start();
    }
}
