using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagCounter : MonoBehaviour {
    private int count;
    private Text text;

    private void Awake() {
        GameEvents.flagPlaced.AddListener(decrementCount);
        GameEvents.flagRemoved.AddListener(incrementCount);
        count = Constants.EXPERT_NUMBER_OF_MINES;
        text = GetComponent<Text>();
    }

    private void incrementCount() {
        count++;
        text.text = count.ToString();
    }

    private void decrementCount() {
        count--;
        text.text = count.ToString();
    }

    private void resetCount() {
        count = Constants.EXPERT_NUMBER_OF_MINES;
        text.text = count.ToString();
    }
}
