using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float health = 3f;
    [SerializeField] float dmg = 2f;
    private bool isEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if collisiion detected, perform Hit()
    }

    public void Status(bool status)
    {
        isEnemy = status;
    }

    private void Hit(float dmg)
    {
        // destroy object on collision
        // subtract damage from health total
        // if health is <= 0, destroy the ship
    }

    private void Move()
    {
        // check if object is infront of ship
        // if not
        //      move forward one square
        // else if object is enemy ship
        //      Attack()
    }

    private void Attack()
    {
        // deal damage to object
    }
}
