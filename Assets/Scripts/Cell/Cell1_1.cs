using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell1_1 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(1, 1));
        base.Start();
    }
}
