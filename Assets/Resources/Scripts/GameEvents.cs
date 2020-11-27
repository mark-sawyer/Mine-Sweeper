using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents {
    public static readonly UnityEvent uncoveredMine = new UnityEvent();
    public static readonly UnityEvent flagPlaced = new UnityEvent();
    public static readonly UnityEvent flagRemoved = new UnityEvent();
    public static readonly UnityEvent spaceUncovered = new UnityEvent();
    public static readonly UnityEvent winGame = new UnityEvent();
}
