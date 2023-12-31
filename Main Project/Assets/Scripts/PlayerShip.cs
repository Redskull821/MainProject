using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float health = 3f;
    [SerializeField] GameObject laser;
    [SerializeField] bool isEnemy;
    public GameObject selectedShip;

    // Start is called before the first frame update
    void Start()
    {
        MyEvents.newRound.AddListener(Reset);
        MyEvents.roundEnd.AddListener(Deactivate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Deactivate()
    {
        if (isEnemy)
        {
            gameObject.SetActive(false);
            Debug.Log("Ship decactivated...");
        }
    }
    
    public void Reset()
    {
        health = 3f;
    }

    public bool Status()
    {
        return isEnemy;
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
                if (isEnemy) { 
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
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
