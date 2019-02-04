using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTotal : MonoBehaviour
{


    DiceTray theDiceTray;

    // Start is called before the first frame update
    void Start()
    {
        theDiceTray = GameObject.FindObjectOfType<DiceTray>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "= " + theDiceTray.Total;
    }
}
