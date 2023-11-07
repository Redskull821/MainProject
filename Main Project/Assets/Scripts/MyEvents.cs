using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class MyEvents
{
    public static UnityEvent playerUnitKilled = new UnityEvent();
    public static UnityEvent enemyUnitKilled = new UnityEvent();
    public static UnityEvent playerLoses = new UnityEvent();
    public static UnityEvent enemyLoses = new UnityEvent();
    public static UnityEvent shipSelected = new UnityEvent();
}
