using System;
using UnityEngine;

public class TileInfo_Dice : TileInfo
{
    public override void TileEvent()
    {
        Debug.Log($"index of this title : {index}, Increase Dice value + 1");
        DicePlayManager.instance.diceNum++;
    }
} 
        
    

