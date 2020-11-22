using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTileClicker : TileClicker {

    public RightTileClicker() : base() { }

    public override void firstFrame() {
        Collider2D collider = tileColliderAtMousePoint();
        if (collider != null) {
            Tile tile = collider.GetComponent<Tile>();
            if (!tile.uncovered) {
                tile.changeFlag();
            }
        }
    }

    public override void laterFrame() {
        return;
    }

    public override bool released() {
        return Input.GetMouseButtonUp(1);
    }
}
