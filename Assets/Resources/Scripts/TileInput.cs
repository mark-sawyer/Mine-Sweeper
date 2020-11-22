using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInput : MonoBehaviour {
    private TileClicker tileClicker;
    private LeftTileClicker leftTileClicker;
    private RightTileClicker rightTileClicker;

    private void Awake() {
        leftTileClicker = new LeftTileClicker();
        rightTileClicker = new RightTileClicker();
    }

    void Update() {
        if (tileClicker == null) {
            if (Input.GetMouseButtonDown(0)) {
                tileClicker = leftTileClicker;
                tileClicker.firstFrame();
            }
            else if (Input.GetMouseButtonDown(1)) {
                tileClicker = rightTileClicker;
                tileClicker.firstFrame();
            }
        }
        else {
            tileClicker.laterFrame();
            if (tileClicker.released()) {
                tileClicker = null;
            }
        }
    }
}
