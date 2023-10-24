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
        // if hit, perform Hit()
    }

    public void Status(bool status)
    {
        isEnemy = status;
    }

    public bool CheckStatus()
    {
        return isEnemy;
    }

    private void Hit()
    {
        health -= 2;
    }

    public void Move()
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
