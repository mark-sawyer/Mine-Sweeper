using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineNumberChanging : MonoBehaviour {
    private Text numText;
    private int num;

    private void Awake() {
        numText = GetComponent<Text>();
        GameEvents.flag.AddListener(decrementNumber);
        GameEvents.unflag.AddListener(incrementNumber);
        num = 99;
        numText.text = num.ToString();
    }

    private void incrementNumber() {
        num++;
        numText.text = num.ToString();
    }

    private void decrementNumber() {
        num--;
        numText.text = num.ToString();
    }

    private void resetNum() {
        num = 99;
        numText.text = num.ToString();
    }
}
