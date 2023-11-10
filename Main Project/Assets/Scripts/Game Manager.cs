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
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameObject readyButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject shipMover;

    private float roundTracker = 0f;
    private float turnTracker = 1f;
    private bool roundOver;
    private bool roundStarted = false;

    List<GameObject> playerShips = new List<GameObject>();
    List<GameObject> enemyShips = new List<GameObject>();
    List<GameObject> activeShips = new List<GameObject>();

    private void Awake()
    {
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
        MyEvents.playerLoses.AddListener(PlayerLoss);
        MyEvents.enemyUnitKilled.AddListener(EnemyDestroyed);
        MyEvents.enemyLoses.AddListener(EnemyLoss);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        roundEndText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        readyButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void RoundStart()
    {
        shipMover.gameObject.SetActive(false);
        roundStarted = true;
        roundTracker++;
        roundTrackerText.text = "Round: " + roundTracker;
        readyButton.gameObject.SetActive(false);
        roundEndText.gameObject.SetActive(false);
        // spawn enemies
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
        StartCoroutine(Turn());
    }

    IEnumerator Turn()
    {
        while (!roundOver) {
            foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship"))
            {
                if (ship != null) 
                {
                    PlayerShip unit = ship.GetComponent<PlayerShip>();
                    unit.Attack();
                    yield return new WaitForSeconds(1);
                }
            }
            turnTracker += 1f;
        }
    }

    private void PlayerLoss()
    {
        StopAllCoroutines();
        gameOverText.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }

    private void EnemyLoss()
    {
        StopAllCoroutines();
        shipMover.gameObject.SetActive(true);
        roundStarted = false;
        turnTracker = 1f;
        roundEndText.gameObject.SetActive(true);
        readyButton.gameObject.SetActive(true);
    }

    private void EnemyDestroyed()
    {
        enemyShips.Clear();
        activeShips.Clear();
        foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship"))
        {
            PlayerShip player = ship.GetComponent<PlayerShip>();
            activeShips.Add(ship);
            if (player.Status())
            {
                enemyShips.Add(ship);
            }
        }
    }

    private void AllyDestroyed()
    {
        playerShips.Clear();
        activeShips.Clear();
        foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship"))
        {
            activeShips.Add(ship);
            PlayerShip player = ship.GetComponent<PlayerShip>();
            if (!player.Status())
            {
                playerShips.Add(ship);
            }
        }
    }
}
