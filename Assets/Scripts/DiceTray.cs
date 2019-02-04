using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DiceValues = new int[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] DiceValues;
    public int Total;

    public bool IsDoneRolling = false;

    public Sprite[] DiceImageOne;
    public Sprite[] DiceImageZero;

    public void NewTurn() {
        IsDoneRolling = false;
    }

    public void rollDice() {
        // roll four 1d4 that have two values, half white half black
        Total = 0;
        for (int i = 0; i < DiceValues.Length; i++){
            int randomNum = Random.Range(0, 2);
            DiceValues[i] = randomNum;
            Total += randomNum;

            if(DiceValues[i] == 0){
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageZero[ Random.Range(0, DiceImageZero.Length) ];
            }else{
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageOne [ Random.Range(0, DiceImageOne.Length) ];
            }

            IsDoneRolling = true;

        }

    }

}
