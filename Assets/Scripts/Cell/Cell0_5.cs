using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell0_5 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(0, 5));
        base.Start();
    }
}
