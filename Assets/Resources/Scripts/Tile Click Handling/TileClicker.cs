using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileClicker {
    private LayerMask tileLayer;

    public TileClicker() {
        tileLayer = LayerMask.GetMask("tile");
    }

    public abstract void firstFrame();

    public abstract void laterFrame();

    public abstract bool released();

    public Collider2D tileColliderAtMousePoint() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D ray = Physics2D.Raycast(mousePosition, Vector2.zero, 0, tileLayer);
        return ray.collider;
    }
}
