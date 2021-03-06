﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : TileClickHandlerGetter {
    private bool active;
    private TileClickHandler currentTileClickHandler;

    public void click() {
        TileClickHandler tileClickHandler = getTileEventHandler();
        if (tileClickHandler != null) {
            active = true;
            currentTileClickHandler = tileClickHandler;
            currentTileClickHandler.leftHold();
        }
    }

    public void update() {
        if (!active) {
            return;
        }

        if (!Input.GetMouseButton(0)) {
            handleRelease();
        }
        else {
            handleHold();
        }
    }

    private void handleRelease() {
        active = false;
        TileClickHandler tileEventHandler = getTileEventHandler();
        if (tileEventHandler == currentTileClickHandler) {
            if (currentTileClickHandler != null) {
                currentTileClickHandler.leftReleased();
            }
        }
        else {
            if (currentTileClickHandler != null) {
                currentTileClickHandler.leftHoldRemoved();
            }
        }
    }

    private void handleHold() {
        TileClickHandler tileEventHandler = getTileEventHandler();
        if (tileEventHandler != currentTileClickHandler) {
            if (currentTileClickHandler != null) {
                currentTileClickHandler.leftHoldRemoved();
            }
            currentTileClickHandler = tileEventHandler;
            if (currentTileClickHandler != null) {
                currentTileClickHandler.leftHold();
            }
        }
    }
}
