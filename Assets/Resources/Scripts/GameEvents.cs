using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents {
    public static readonly UnityEvent died = new UnityEvent();
    public static readonly UnityEvent uncoveredSafeSpace = new UnityEvent();
    public static readonly UnityEvent win = new UnityEvent();
    public static readonly UnityEvent flag = new UnityEvent();
    public static readonly UnityEvent unflag = new UnityEvent();
}
