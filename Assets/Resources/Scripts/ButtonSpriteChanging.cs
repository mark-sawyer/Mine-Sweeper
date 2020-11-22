using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteChanging : MonoBehaviour {
    private void Awake() {
        GameEvents.died.AddListener(loseSprite);
        GameEvents.win.AddListener(winSprite);
    }

    private void winSprite() {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Smiley Buttons/cool button");
    }

    private void loseSprite() {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Smiley Buttons/dead button");
    }

    private void resetSprite() {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Smiley Buttons/smiley button");
    }
}
