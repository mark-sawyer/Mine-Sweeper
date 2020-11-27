using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileClickHandlerGetter {
    public TileClickHandler getTileEventHandler() {
        TileClickHandler tileEventHandler = null;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D ray = Physics2D.Raycast(mousePosition, Vector2.zero, 0);
        if (ray.collider != null) {
            tileEventHandler = ray.collider.GetComponent<TileClickHandler>();
        }

        return tileEventHandler;
    }
}
