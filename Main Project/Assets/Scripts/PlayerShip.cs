using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float health = 3f;
    [SerializeField] GameObject laser;
    [SerializeField] bool isEnemy;
    private bool selected;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if cursor is over ship and mouse1 is pushed down
        //      select ship
        // if ship is selected and a posiiton is selected
        //      move ship to position
    }

    public bool Status()
    {
        return isEnemy;
    }

    public bool Selected()
    {
        return selected;
    }

    public void Attack()
    {
        GameObject blast = Instantiate(laser, transform.position, transform.rotation);
        blast.transform.Rotate(new Vector3(0, 0, 180));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Destroy(collision.gameObject);
            health -= 2f;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        if (isEnemy)
        {
            MyEvents.enemyUnitKilled.Invoke();
        }
        else
        {
            MyEvents.playerUnitKilled.Invoke();
        }
    }
}
