using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour {
    private Image buttonImage;
    private Sprite deadSprite;
    private Sprite smileySprite;
    private Sprite coolSprite;

    private void Awake() {
        buttonImage = GetComponent<Image>();
        deadSprite = Resources.Load<Sprite>("Sprites/Smiley Buttons/dead button");
        smileySprite = Resources.Load<Sprite>("Sprites/Smiley Buttons/smiley button");
        coolSprite = Resources.Load<Sprite>("Sprites/Smiley Buttons/cool button");

        GameEvents.uncoveredMine.AddListener(changeToDeadSprite);
        GameEvents.winGame.AddListener(changeToCoolSprite);
    }

    private void changeToDeadSprite() {
        buttonImage.sprite = deadSprite;
    }

    public void changeToSmileySprite() {
        buttonImage.sprite = smileySprite;
    }

    public void changeToCoolSprite() {
        buttonImage.sprite = coolSprite;
    }
}
