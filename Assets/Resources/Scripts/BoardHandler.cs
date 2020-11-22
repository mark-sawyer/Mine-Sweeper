using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardHandler : MonoBehaviour {
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int mineNumber;
    private GameObject tile;
    private List<GameObject> tileList;
    private int uncoveredTiles;
    private int totalSafeSpaces;

    private void Awake() {
        GameEvents.uncoveredSafeSpace.AddListener(countUncoveredSpaces);
        uncoveredTiles = 0;
        totalSafeSpaces = (width * height) - mineNumber;
        tile = Resources.Load<GameObject>("Prefabs/tile");
        tileList = new List<GameObject>(width * height);
        generateBoard();
        setMines();
        getTileNumbers();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private void generateBoard() {
        GameObject tiles = GameObject.Find("tiles");
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                GameObject newTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                newTile.transform.parent = tiles.transform;
                tileList.Add(newTile);
            }
        }
    }

    private void setMines() {
        tileList = tileList.OrderBy(x => Guid.NewGuid()).ToList();
        for (int i = 0; i < mineNumber; i++) {
            tileList[i].GetComponent<Tile>().setMine();
        }
    }

    private void getTileNumbers() {
        foreach (GameObject tile in tileList) {
            tile.GetComponent<Tile>().getNumberAndSprite();
        }
    }

    private void generateNewBoard() {
        uncoveredTiles = 0;
        GameObject tiles = GameObject.Find("tiles");
        foreach (Transform child in tiles.transform) {
            Destroy(child.gameObject);
        }

        tileList = new List<GameObject>(width * height);
        generateBoard();
        setMines();
        getTileNumbers();
    }

    private void countUncoveredSpaces() {
        uncoveredTiles++;
        if (uncoveredTiles == totalSafeSpaces) {
            GameEvents.win.Invoke();
        }
    }
}
