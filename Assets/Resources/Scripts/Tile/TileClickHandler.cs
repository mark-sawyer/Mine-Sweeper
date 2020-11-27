using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClickHandler : MonoBehaviour {
    public Tile tile { get; set; }

    public void rightClicked() {
        if (tile.type == TileType.COVERED) {
            tile.changeType(TileType.FLAGGED);
            GameEvents.flagPlaced.Invoke();
        }
        else if (tile.type == TileType.FLAGGED) {
            tile.changeType(TileType.COVERED);
            GameEvents.flagRemoved.Invoke();
        }
    }

    public void leftHold() {
        if (tile.type == TileType.COVERED) {
            tile.changeType(TileType.COMPRESSED);
        }
        else if (tile.type == TileType.UNCOVERED) {
            tile.uncoveredHold();
        }
    }

    public void leftHoldRemoved() {
        if (tile.type == TileType.COMPRESSED) {
            tile.changeType(TileType.COVERED);
        }
        else if (tile.type == TileType.UNCOVERED) {
            tile.uncoveredHoldRemove();
        }
    }

    public void leftReleased() {
        if (tile.type == TileType.COMPRESSED) {
            tile.changeType(TileType.UNCOVERED);
        }
        else if (tile.type == TileType.UNCOVERED) {
            tile.uncoveredRelease();
        }
    }
}
