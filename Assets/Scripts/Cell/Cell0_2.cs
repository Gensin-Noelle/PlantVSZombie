using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell0_2 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(0, 2));
        base.Start();
    }
}
