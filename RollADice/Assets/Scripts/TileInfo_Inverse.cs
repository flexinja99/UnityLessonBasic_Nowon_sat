using System;
using UnityEngine;

public class TileInfo_Inverse : TileInfo
{
    public override void TileEvent()
    {
        Debug.Log($"index of this title : {index}, Increase Inverse value + 1");
        DicePlayManager.instance.direction = -1;
    }
}
    
    

