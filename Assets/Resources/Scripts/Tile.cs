using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private SpriteRenderer sr;
    private LayerMask tileLayer;
    private Sprite compressedSprite;
    private Sprite uncompressedSprite;
    private Sprite flagSprite;
    private Sprite numberSprite;
    private Sprite mineSprite;
    private Sprite falseFlagSprite;
    public bool uncovered { get; private set; }
    public bool hasMine { get; private set; }
    public bool flagged { get; private set; }
    private int number;
    private List<Tile> neighbourTiles;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        tileLayer = LayerMask.GetMask("tile");
        compressedSprite = Resources.Load<Sprite>("Sprites/0");
        uncompressedSprite = Resources.Load<Sprite>("Sprites/uncovered");
        flagSprite = Resources.Load<Sprite>("Sprites/flag");
        mineSprite = Resources.Load<Sprite>("Sprites/mine");
        falseFlagSprite = Resources.Load<Sprite>("Sprites/false flag");
        number = 0;
        neighbourTiles = new List<Tile>(8);
        GameEvents.died.AddListener(respondToGameOver);
        GameEvents.win.AddListener(respondToWin);
    }

    public void compress() {
        sr.sprite = compressedSprite;
    }

    public void uncompress() {
        sr.sprite = uncompressedSprite;
    }

    public void uncover() {
        if (!uncovered) {
            uncovered = true;
            sr.sprite = numberSprite;
            if (hasMine) {
                GameEvents.died.Invoke();
                return;
            }
            GameEvents.uncoveredSafeSpace.Invoke();
            if (number == 0) {
                foreach (Tile neighbourTile in neighbourTiles) {
                    neighbourTile.uncover();
                }
            }
        }
    }

    public void changeFlag() {
        if (flagged) {
            sr.sprite = uncompressedSprite;
            flagged = false;
            GameEvents.unflag.Invoke();
        }
        else {
            sr.sprite = flagSprite;
            flagged = true;
            GameEvents.flag.Invoke();
        }
    }

    public void setMine() {
        hasMine = true;
    }

    public void getNumberAndSprite() {
        if (hasMine) {
            number = -99;
        }
        else {
            for (int x = -1; x < 2; x++) {
                for (int y = -1; y < 2; y++) {
                    if (x != 0 || y != 0) {
                        Vector2 positionChecked = transform.position + new Vector3(x, y);
                        RaycastHit2D ray = Physics2D.Raycast(positionChecked, Vector2.zero, 0, tileLayer);
                        if (ray.collider != null) {
                            Tile neighbourTile = ray.collider.GetComponent<Tile>();
                            neighbourTiles.Add(neighbourTile);
                            if (neighbourTile.hasMine) {
                                number++;
                            }
                        }
                    }
                }
            }
        }

        setNumberSprite();
    }

    public bool hasCorrectNumberOfFlaggedNeighbours() {
        int flaggedNeighbours = 0;
        foreach (Tile neighbourTile in neighbourTiles) {
            if (neighbourTile.flagged) {
                flaggedNeighbours++;
            }
        }
        return flaggedNeighbours == number;
    }

    public void compressNeighbours() {
        foreach (Tile neighbour in neighbourTiles) {
            if (!neighbour.flagged && !neighbour.uncovered) {
                neighbour.compress();
            }
        }
    }

    public void uncompressNeighbours() {
        foreach (Tile neighbour in neighbourTiles) {
            if (!neighbour.flagged && !neighbour.uncovered) {
                neighbour.uncompress();
            }
        }
    }

    public void uncoverNeighbours() {
        foreach (Tile neighbour in neighbourTiles) {
            if (!neighbour.flagged && !neighbour.uncovered) {
                neighbour.uncover();
            }
        }
    }

    private void setNumberSprite() {
        if (!hasMine) {
            numberSprite = Resources.Load<Sprite>("Sprites/" + number);
        }
        else {
            numberSprite = Resources.Load<Sprite>("Sprites/killer");
        }
    }

    private void respondToGameOver() {
        GetComponent<BoxCollider2D>().enabled = false;
        if (!uncovered) {
            if (hasMine && !flagged) {
                sr.sprite = mineSprite;
            }
            if (flagged && !hasMine) {
                sr.sprite = falseFlagSprite;
            }
        }
    }

    private void respondToWin() {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
