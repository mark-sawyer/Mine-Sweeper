using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpriteChanger {
    private SpriteRenderer sr;
    private static Sprite covered = Resources.Load<Sprite>("Sprites/uncovered");
    private static Sprite compressed = Resources.Load<Sprite>("Sprites/0");
    private static Sprite flag = Resources.Load<Sprite>("Sprites/flag");
    private static Sprite falseFlag = Resources.Load<Sprite>("Sprites/false flag");
    private static Sprite mine = Resources.Load<Sprite>("Sprites/mine");
    private static Sprite killer = Resources.Load<Sprite>("Sprites/killer");

    public TileSpriteChanger(SpriteRenderer sr) {
        this.sr = sr;
    }

    public void showCovered() {
        sr.sprite = covered;
    }

    public void showCompressed() {
        sr.sprite = compressed;
    }

    public void showFlag() {
        sr.sprite = flag;
    }

    public void showFalseFlag() {
        sr.sprite = falseFlag;
    }

    public void showMine() {
        sr.sprite = mine;
    }

    public void showKiller() {
        sr.sprite = killer;
    }

    public void showNumber(int number) {
        sr.sprite = Resources.Load<Sprite>("Sprites/" + number);
    }
}
