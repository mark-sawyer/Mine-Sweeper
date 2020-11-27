using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileNeighbourGetter {
    public static List<Tile> getNeighbours(int row, int col) {
        GameBoard gameBoard = GameFlow.gameBoard;
        List<Tile> neighbours = new List<Tile>(8);
        for (int i = row - 1; i < row + 2; i++) {
            for (int j = col - 1; j < col + 2; j++) {
                if (validSpace(i, j) && notCentre(row, col, i, j)) {
                    Tile neighbourTile = gameBoard.tiles[i, j];
                    neighbours.Add(neighbourTile);
                }
            }
        }
        return neighbours;
    }

    private static bool validSpace(int row, int col) {
        return row >= 0 && row <= Constants.EXPERT_HEIGHT - 1 && col >= 0 && col <= Constants.EXPERT_WIDTH - 1;
    }

    private static bool notCentre(int row, int col, int rowCheck, int colCheck) {
        return !(row == rowCheck && col == colCheck);
    }
}
