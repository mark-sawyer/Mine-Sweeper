using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNeighbourManager {
    List<Tile> neighbourTiles;

    public TileNeighbourManager(int row, int col) {
        neighbourTiles = TileNeighbourGetter.getNeighbours(row, col);
    }

    public int getNumber() {
        int number = 0;
        foreach (Tile neighbourTile in neighbourTiles) {
            if (neighbourTile.hasMine) {
                number++;
            }
        }
        return number;
    }

    public void compressNeighbours() {
        foreach (Tile neighbourTile in neighbourTiles) {
            if (neighbourTile.type == TileType.COVERED) {
                neighbourTile.changeType(TileType.COMPRESSED);
            }
        }
    }

    public void uncompressNeighbours() {
        foreach (Tile neighbourTile in neighbourTiles) {
            if (neighbourTile.type == TileType.COMPRESSED) {
                neighbourTile.changeType(TileType.COVERED);
            }
        }
    }

    public void uncoverNeighbours() {
        foreach (Tile neighbourTile in neighbourTiles) {
            if (neighbourTile.type == TileType.COMPRESSED || neighbourTile.type == TileType.COVERED) {
                neighbourTile.changeType(TileType.UNCOVERED);
            }
        }
    }

    public bool isCorrectFlagNumber(int number) {
        int flagNum = 0;
        foreach (Tile neighbourTile in neighbourTiles) {
            if (neighbourTile.type == TileType.FLAGGED) {
                flagNum++;
            }
        }
        return flagNum == number;
    }
}
