using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell1_2 : Cell
{
    protected override void Start()
    {
        SetCurrentCellIndex(new Vector2(1, 2));
        base.Start();
    }
}
