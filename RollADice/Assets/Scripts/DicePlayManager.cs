
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePlayManager : MonoBehaviour
{
    private int currentTileIndex;
    private int _diceNum;

    public int diceNum
    {
        set
        {
            _diceNum = value;
            diceText.text = _diceNum.ToString();
          
        }
        get
        {
            return _diceNum;
        }
    }
    public Text diceText;
    public int diceNumlnit;
    private int _goldenDiceNum;
    public int goldenDiceNum
    {
        set
        {
            if(value >= 0)
            {
                _goldenDiceNum = value;
                goldenDiceText.text = _goldenDiceNum.ToString();
            }

        }
        get
        {
            return _goldenDiceNum;

        }
    }
    public Text goldenDiceText;
    public int goldenDiceNumlnit;
    public int starScore
    {
        set
        {
            if(starScore >= 0)
            {
                _starScore = value;
                starScoreText.text = _starScore.ToString();
            }
        }
        get
        {
            return starScore;
        }
    }

    public Text starScoreText;
    private int _starScore;

    public List<Transform> mapTiles;

    private void Awake()
    {
        diceNum = diceNumlnit;
        goldenDiceNum = goldenDiceNumlnit;
    }
    public void RollADice()
    {
        if (diceNum < 1) return;

        diceNum--;
        int diceValue = Random.Range(1, 7);
        MovePlayer(diceValue);
       
       
        
    }

    private void MovePlayer(int diceValue)
    {
        int previousTileIndex = currentTileIndex;
        currentTileIndex += diceValue;

        if (currentTileIndex >= mapTiles.Count)
            currentTileIndex -= mapTiles.Count;

        Player.instance.Move(GetTilePosition(currentTileIndex));
    }
    private Vector3 GetTilePosition(int tilelndex)
    {
        return mapTiles[tilelndex].position;
    }
}
