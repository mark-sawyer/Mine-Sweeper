using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTileClicker : TileClicker {
    private bool isTilePressing;
    private Tile heldTile;

    public LeftTileClicker() : base() { }

    public override void firstFrame() {
        Collider2D collider = tileColliderAtMousePoint();
        if (collider != null) {
            isTilePressing = true;
            handleOverTile(collider.GetComponent<Tile>());
        }
    }

    public override void laterFrame() {
        if (!isTilePressing) {
            return;
        }

        if (Input.GetMouseButton(0)) {
            Collider2D collider = tileColliderAtMousePoint();
            if (collider != null) {
                handleOverTile(collider.GetComponent<Tile>());
            }
            else {
                ensureNotHoldingTile();
            }
        }
        else {
            // Click released.
            Collider2D collider = tileColliderAtMousePoint();
            if (collider != null) {
                if (collider.GetComponent<Tile>() == heldTile) {
                    finaliseTileInteraction();
                }
                else {
                    ensureNotHoldingTile();
                }
            }

            isTilePressing = false;
        }        
    }

    public override bool released() {
        return Input.GetMouseButtonUp(0);
    }

    private void handleOverTile(Tile tile) {
        if (tile == heldTile) {
            return;
        }
        
        // Tile is new.
        if (heldTile != null) {
            stopInteractingWithOldTile();
        }

        if (!tile.flagged) {
            interactWithNewTile(tile);
        }
        else {
            heldTile = null;
        }
    }

    private void stopInteractingWithOldTile() {
        if (heldTile.uncovered) {
            heldTile.uncompressNeighbours();
        }
        else {
            heldTile.uncompress();
        }
    }

    private void interactWithNewTile(Tile tile) {
        heldTile = tile;
        if (!heldTile.uncovered) {
            heldTile.compress();
        }
        else if (heldTile.hasCorrectNumberOfFlaggedNeighbours()) {
            heldTile.compressNeighbours();
        }
    }

    private void finaliseTileInteraction() {
        if (!heldTile.uncovered) {
            heldTile.GetComponent<Tile>().uncover();
        }
        else if (heldTile.hasCorrectNumberOfFlaggedNeighbours()) {
            heldTile.uncoverNeighbours();
        }

        heldTile = null;
    }

    private void ensureNotHoldingTile() {
        if (heldTile != null) {
            heldTile.uncompress();
            heldTile = null;
        }
    }
}
