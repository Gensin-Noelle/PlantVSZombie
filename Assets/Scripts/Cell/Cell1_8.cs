using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell1_8 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(1, 8));
        base.Start();
    }
}
