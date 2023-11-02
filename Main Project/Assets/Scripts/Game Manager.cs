using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI roundTrackerText;
    [SerializeField] TextMeshProUGUI roundEndText;
    [SerializeField] GameObject readyButton;
    [SerializeField] float playerHealth = 10f;
    [SerializeField] float enemyHealth = 10f;

    private float roundTracker = 1f;
    private float turnTracker = 1f;
    private bool roundOver;

    List<GameObject> playerShips = new List<GameObject>();
    List<GameObject> enemyShips = new List<GameObject>();
    List<GameObject> activeShips = new List<GameObject>();

    private void Awake()
    {
        GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
        foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship"))
        {
            activeShips.Add(ship);
            PlayerShip player = ship.GetComponent<PlayerShip>();
            if (player.Status())
            {
                enemyShips.Add(ship);
            }
            else
            {
                playerShips.Add(ship);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MyEvents.playerUnitKilled.AddListener(AllyDestroyed);
        MyEvents.enemyUnitKilled.AddListener(EnemyDestroyed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RoundStart()
    {
        //readyButton.gameObject.SetActive(false);
        // spawn enemies
        activeShips = GameObject.FindGameObjectsWithTag("Ship");
        for (int i = 0; i < activeShips.Length; i++)
        {
            PlayerShip ship = activeShips[i].GetComponent<PlayerShip>();
            if (ship.Status())
            {
                enemyShips.Add(activeShips[i]);
            }
            else
            {
                playerShips.Add(activeShips[i]);
            }
        }
        while (!roundOver) {
            StartCoroutine(Turn());
            if (roundOver)
            {
                StopAllCoroutines();
                RoundEnd();
            }
        }
    }

    IEnumerator Turn()
    {
        activeShips = GameObject.FindGameObjectsWithTag("Ship");
        for (int i = 0; i < activeShips.Length; i++)
        {
            PlayerShip ship = activeShips[i].GetComponent<PlayerShip>();
            ship.Attack();
            yield return new WaitForSeconds(3);
        }

        turnTracker += 1f;
        if (enemyShips.Count == 0 || playerShips.Count == 0)
        {
            roundOver = true;
        }
    }

    private void RoundIncrease()
    {
        roundTracker++;
        roundTrackerText.text = "Round: " + roundTracker;
    }

    private void RoundEnd()
    {
        ResetTurn();
        roundEndText.gameObject.SetActive(true);
    }

    private void TurnIncrease()
    {
        turnTracker++;
    }

    private void ResetTurn()
    {
        turnTracker = 1f;
    }

    private void EnemyDestroyed()
    {
        enemyShips.Clear();
        Debug.Log(enemyShips.Count);

        GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
        Debug.Log(ships.Length);

        for (int i = 0; i < activeShips.Length; i++)
        {
            PlayerShip ship = activeShips[i].GetComponent<PlayerShip>();
            if (ship.Status())
            {
                enemyShips.Add(activeShips[i]);
                Debug.Log("Ship added");
            }
        }
        //Debug.Log("Enemy Ships: " + enemyShips.Count);
        //Debug.Log("Active Ships: " + activeShips.Length);
    }

    private void AllyDestroyed()
    {
        playerShips.Clear();
        activeShips = GameObject.FindGameObjectsWithTag("Ship");
        for (int i = 0; i < activeShips.Length; i++)
        {
            PlayerShip ship = activeShips[i].GetComponent<PlayerShip>();
            if (!ship.Status())
            {
                playerShips.Add(activeShips[i]);
            }
        }
        //Debug.Log("Ally Ships: " + playerShips.Count);
        //Debug.Log("Active Ships: " + activeShips.Length);
    }
}
