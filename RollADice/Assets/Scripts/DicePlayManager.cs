
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePlayManager : MonoBehaviour
{
    public static DicePlayManager instance;

    private int currentTileIndex; // ���� ĭ �ε���
    private int _diceNum; //  ���� �ֻ��� �� ����

    public int diceNum
    {
        set
        {
            if (value >= 0) // ���� �ֻ��� ������ 0 �̻����θ� �°���
            {


                _diceNum = value;
                diceText.text = _diceNum.ToString(); // Text ������Ʈ
            }
          
        }
        get
        {
            return _diceNum;
        }
    }
    public Text diceText; // ���� �ֻ��� ���� �ؽ�Ʈ UI
    public int diceNumlnit; // �ֻ��� �ʱⰪ
    private int _goldenDiceNum; // Ȳ�� �ֻ��� ���� ����
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
    public int _starScore;
    private int _direction;

    public int direction
    {
        set
        {
            _direction = value;
            if (_direction > 0)
                inversePanel.SetActive(false);
            else
                inversePanel.SetActive(true);
        }
        get
        {
            return direction;
        }
    }
    public GameObject inversepanel;


    public List<Transform> mapTiles;
   
    public Coroutine animation
    private void Awake()
    {
        instance = this;
        diceNum = diceNumlnit;
        goldenDiceNum = goldenDiceNumlnit;
        starScore = 0;
    }
    public void RollADice()
    {
        if (diceNum < 1) return;
        if (animationCoroutine != null) return;

        diceNum--;
        int diceValue = Random.Range(1, 7);
        StartCoroutine(DiceAnimationUI.Instance.E_DiceAnimation(diceValue,this, MovePlayer));
       
       
        
    }
    public void RollAGoldenDice()
    {
        if(diceNum < 1) return; 

        goldenDiceNum++;
        int diceValue = Random.Range(1,7);
        StartCoroutine(DiceAnimationUI.Instance.E_DiceAnimation(diceValue,this,MovePlayer));
    }

    private void MovePlayer(int diceValue)
    {
        int previousTileIndex = currentTileIndex;
        currentTileIndex += diceValue * direction;

        CheckPlayerPassedStarTile(previousTileIndex, currentTileIndex);

        if (currentTileIndex >= mapTiles.Count)
            currentTileIndex -= mapTiles.Count;
        Debug.Log($"move to {currentTileIndex},{direction}");
        Player.instance.Move(GetTilePosition(currentTileIndex));
        mapTiles[currentTileIndex].GetComponent<TileInfo>().TileEvent();
        direction = 1;
    }
   
    private void CheckPlayerPassedStarTile(int previousIndex, int currentIndex)
    {
        
        for(int i = previousIndex + 1; i <= currentIndex; i++)
        {
            int tmpIndex = i;
            if(tmpIndex >= mapTiles.Count)
                tmpIndex -= mapTiles.Count;

           if( mapTiles[tmpIndex].TryGetComponent(out TileInfo_Star tmpStarTile))
            
                starScore += tmpStarTile.starValue;

        }
    }

    private Vector3 GetTilePosition(int tilelndex)
    {
        return mapTiles[tilelndex].position;
    }
}
