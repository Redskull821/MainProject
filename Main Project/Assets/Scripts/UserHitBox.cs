using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserHitBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI enemyHealthText;
    [SerializeField] float playerHealth = 10f;
    [SerializeField] float enemyHealth = 10f;
    [SerializeField] bool isEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyEvents.newRound.AddListener(HealthReset);
    }

    private void HealthReset()
    {
        enemyHealth = 10f;
        enemyHealthText.text = "Enemy: " + enemyHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (isEnemy)
        {
            enemyHealth -= 2f;
            enemyHealthText.text = "Enemy: " + enemyHealth;
            if (enemyHealth <= 0)
            {
                MyEvents.enemyLoses.Invoke();
            }
        }
        else
        {
            playerHealth -= 2f;
            playerHealthText.text = "Player: " + playerHealth;
            if (playerHealth <= 0)
            {
                MyEvents.playerLoses.Invoke();
            }
        }
    }
}
