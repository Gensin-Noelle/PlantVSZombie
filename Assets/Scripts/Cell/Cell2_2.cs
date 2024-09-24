using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2_2 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(2, 2));
        base.Start();
    }
}
