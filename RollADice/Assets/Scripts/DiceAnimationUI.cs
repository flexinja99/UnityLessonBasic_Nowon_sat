using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiceAnimationUI : MonoBehaviour
{
    public static DiceAnimationUI Instance;

    private void Awake()
    {
        Instance = this;
    }
    public Image diceAnimationImage;
    public float diceAnimationTime;
    private Sprite[] sprites;
    public extern void AnimationFinshedEvent();
    private void Start()
    {
        Resources.LoadAll<Sprite>("DiceVectorDark");
    }
     public IEnumerator E_DiceAnitmation(int diceValue, DicePlayManager manger,AnimationFinshedEvent finshedEvent)
     {
        float elaspesdTime = 0;
        while (elaspesdTime < diceAnimationTime)
        {
            elaspesdTime += diceAnimationTime / 10;
            int tmpIdx = Random.Range(0, sprites.Length);
            diceAnimationImage.sprite=sprites[tmpIdx];
            yield return new WaitForSeconds(diceAnimationTime / 10);
        }
        diceAnimationImage.sprite = sprites[diceValue - 1];

        if (finshedEvent != null)
            finshedEvent();

        manger.animationCoroutine = null;
        yield return null;
     }

}
