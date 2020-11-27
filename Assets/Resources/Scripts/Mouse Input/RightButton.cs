using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : TileClickHandlerGetter {
    public void click() {
        TileClickHandler tileClickHandler = getTileEventHandler();
        if (tileClickHandler != null) {
            tileClickHandler.rightClicked();
        }
    }
}
