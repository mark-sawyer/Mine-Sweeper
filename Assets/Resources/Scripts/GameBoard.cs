using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBoard {
    private int width;
    private int height;
    public Tile[,] tiles { get; private set; }

    public GameBoard(int width, int height) {
        this.width = width;
        this.height = height;
        tiles = new Tile[height, width];
    }

    public void generateBoard() {
        createTiles();
        setNeighbours();
        setMines();
    }

    private void createTiles() {
        GameObject tilePrefab = Resources.Load<GameObject>("Prefabs/tile");
        for (int row = 0; row < height; row++) {
            for (int col = 0; col < width; col++) {
                GameObject newTileGameObject = UnityEngine.Object.Instantiate(tilePrefab, new Vector3(col, row), Quaternion.identity);
                Tile newTile = new Tile(newTileGameObject.GetComponent<SpriteRenderer>(), newTileGameObject.GetComponent<BoxCollider2D>());
                tiles[row, col] = newTile;
                newTileGameObject.GetComponent<TileClickHandler>().tile = newTile;
            }
        }
    }

    private void setNeighbours() {
        for (int row = 0; row < height; row++) {
            for (int col = 0; col < width; col++) {
                tiles[row, col].setNeighbourManager(row, col);
            }
        }
    }

    public void resetBoard() {
        for (int row = 0; row < height; row++) {
            for (int col = 0; col < width; col++) {
                tiles[row, col].resetTile();
            }
        }
        setMines();
    }

    private void setMines() {
        int totalSpaces = Constants.EXPERT_WIDTH * Constants.EXPERT_HEIGHT;
        List<int> numbers = new List<int>(totalSpaces);
        for (int i = 0; i < totalSpaces; i++) {
            numbers.Add(i);
        }
        numbers = numbers.OrderBy(x => Guid.NewGuid()).ToList();  // Randomise order
        for (int i = 0; i < Constants.EXPERT_NUMBER_OF_MINES; i++) {
            int tileNumber = numbers[i];
            int row = tileNumber / Constants.EXPERT_WIDTH;
            int col = tileNumber % Constants.EXPERT_WIDTH;
            tiles[row, col].hasMine = true;
        }
    }

    public void setAsGameOverBoard() {
        Tile currentTile;
        for (int row = 0; row < Constants.EXPERT_HEIGHT; row++) {
            for (int col = 0; col < Constants.EXPERT_WIDTH; col++) {
                currentTile = tiles[row, col];
                currentTile.turnOffCollider();
                changeToGameOverTile(currentTile);
            }
        }
    }

    private void changeToGameOverTile(Tile tile) {
        if (tile.type == TileType.COVERED && tile.hasMine) {
            tile.changeType(TileType.MINE);
        }
        else if (tile.type == TileType.FLAGGED && !tile.hasMine) {
            tile.changeType(TileType.FALSE_FLAG);
        }
    }

    public void disableBoard() {
        for (int row = 0; row < Constants.EXPERT_HEIGHT; row++) {
            for (int col = 0; col < Constants.EXPERT_WIDTH; col++) {
                tiles[row, col].turnOffCollider();
            }
        }
    }
}
