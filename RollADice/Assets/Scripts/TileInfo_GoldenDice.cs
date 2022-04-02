using System;
using UnityEngine;


 public class TileInfo_GoldenDice : TileInfo
 {
    public override void TileEvent()
    {
        Debug.Log($"index of this title : {index}, Increase GoldenDcie value + 1");
        DicePlayManager.instance.diceNum++;
    }
 }
