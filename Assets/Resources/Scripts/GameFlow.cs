using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour {
    public static GameBoard gameBoard { get; private set; }
    private bool gameLost;
    private int spacesUncovered;

    private void Awake() {
        GameEvents.uncoveredMine.AddListener(loseGame);
        GameEvents.spaceUncovered.AddListener(incrementSpacesUncovered);
        spacesUncovered = 0;

        gameBoard = new GameBoard(Constants.EXPERT_WIDTH, Constants.EXPERT_HEIGHT);
        gameBoard.generateBoard();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private void loseGame() {
        if (gameLost) {
            return;
        }

        gameLost = true;
        gameBoard.setAsGameOverBoard();
    }

    private void resetGame() {
        gameLost = false;
        spacesUncovered = 0;
        gameBoard.resetBoard();
    }

    private void incrementSpacesUncovered() {
        spacesUncovered++;
        if (spacesUncovered == Constants.TOTAL_SAFE_SPACES) {
            GameEvents.winGame.Invoke();
        }
    }
}
