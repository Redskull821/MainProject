using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float health = 3f;
    [SerializeField] GameObject laser;
    [SerializeField] bool isEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetInput())
    }

    public bool CheckStatus()
    {
        return isEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            Destroy(collision.gameObject);
            health -= 2f;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Attack()
    {
        Instantiate(laser, transform.position, Quaternion.identity);
    }
}
