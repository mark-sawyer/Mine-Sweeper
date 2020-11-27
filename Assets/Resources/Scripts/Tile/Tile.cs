using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
    private TileNeighbourManager neighbourManager;
    public bool hasMine { get; set; }
    public TileType type { get; set; }
    private TileSpriteChanger spriteChanger;
    private int number;
    private BoxCollider2D collider;

    public Tile(SpriteRenderer sr, BoxCollider2D collider) {
        this.collider = collider;
        spriteChanger = new TileSpriteChanger(sr);
        number = Constants.UNKNOWN_NUMBER;
    }

    public void setNeighbourManager(int row, int col) {
        neighbourManager = new TileNeighbourManager(row, col);
    }

    public void resetTile() {
        hasMine = false;
        number = Constants.UNKNOWN_NUMBER;
        changeType(TileType.COVERED);
        collider.enabled = true;
    }

    public void changeType(TileType newType) {
        type = newType;
        switch (type) {
            case TileType.COVERED:
                spriteChanger.showCovered();
                break;
            case TileType.COMPRESSED:
                spriteChanger.showCompressed();
                break;
            case TileType.UNCOVERED:
                uncoverTile();
                break;
            case TileType.FLAGGED:
                spriteChanger.showFlag();
                break;
            case TileType.FALSE_FLAG:
                spriteChanger.showFalseFlag();
                break;
            case TileType.MINE:
                spriteChanger.showMine();
                break;
        }
    }

    private void uncoverTile() {
        if (hasMine) {
            spriteChanger.showKiller();
            GameEvents.uncoveredMine.Invoke();
            return;
        }

        GameEvents.spaceUncovered.Invoke();
        number = neighbourManager.getNumber();
        spriteChanger.showNumber(number);
        if (number == 0) {
            neighbourManager.uncoverNeighbours();
        }
    }

    public void uncoveredHold() {
        neighbourManager.compressNeighbours();
    }

    public void uncoveredHoldRemove() {
        neighbourManager.uncompressNeighbours();
    }

    public void uncoveredRelease() {
        if (neighbourManager.isCorrectFlagNumber(number)) {
            neighbourManager.uncoverNeighbours();
        }
        else {
            neighbourManager.uncompressNeighbours();
        }
    }

    public void turnOffCollider() {
        collider.enabled = false;
    }
}