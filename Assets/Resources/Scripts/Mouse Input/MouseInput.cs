using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {
    private bool mouseButtonDown;
    private bool leftButtonDown;
    private LeftButton leftButton;
    private RightButton rightButton;

    private void Awake() {
        leftButton = new LeftButton();
        rightButton = new RightButton();
    }

    private void Update() {
        if (!mouseButtonDown) {
            respondIfButtonPressed();
        }
        else {
            if (leftButtonDown) {
                leftButton.update();
            }
            resetIfBothButtonsReleased();
        }
    }

    private void respondIfButtonPressed() {
        if (Input.GetMouseButtonDown(0)) {
            mouseButtonDown = true;
            leftButtonDown = true;
            leftButton.click();
        }
        else if (Input.GetMouseButtonDown(1)) {
            mouseButtonDown = true;
            rightButton.click();
        }
    }

    private void resetIfBothButtonsReleased() {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1)) {
            mouseButtonDown = false;
            leftButtonDown = false;
        }
    }
}
