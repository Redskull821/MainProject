using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class MyEvents
{
    public static UnityEvent playerUnitKilled = new UnityEvent();
    // MyEvents.playerUnitKilled.AddListener(???);
    // MyEvents.playerUnitKilled.Invoke();
    public static UnityEvent enemyUnitKilled = new UnityEvent();
    public static UnityEvent playerDamaged = new UnityEvent();
    public static UnityEvent enemyDamaged = new UnityEvent();
}
