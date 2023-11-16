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
    [SerializeField] TextMeshProUGUI finalRoundText;
    [SerializeField] GameObject readyButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject shipMover;

    [SerializeField] GameObject[] roundOne;
    [SerializeField] GameObject[] roundTwo;
    [SerializeField] GameObject[] roundThree;
    [SerializeField] GameObject[] gameOver;

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
        MyEvents.newRound.Invoke();
        shipMover.gameObject.SetActive(false);
        roundStarted = true;
        roundTracker++;
        roundTrackerText.text = "Round: " + roundTracker;
        readyButton.gameObject.SetActive(false);
        roundEndText.gameObject.SetActive(false);
        NewRound();
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

    private void NewRound()
    {
        if (roundTracker == 1)
        {
            for (int i = 0; i < roundOne.Length; i++)
            {
                roundOne[i].gameObject.SetActive(true);
            }
        }
        else if (roundTracker == 2)
        {
            for (int i = 0; i < roundTwo.Length; i++)
            {
                roundTwo[i].gameObject.SetActive(true);
            }
        }
        else if (roundTracker == 3)
        {
            for (int i = 0; i < roundThree.Length; i++)
            {
                roundThree[i].gameObject.SetActive(true);
            }
        }
        else
        {
            finalRoundText.gameObject.SetActive(true);
            for (int i = 0; i < gameOver.Length; i++)
            {
                gameOver[i].gameObject.SetActive(true);
            }
        }
    }
    
    private void PlayerLoss()
    {
        StopAllCoroutines();
        gameOverText.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        finalRoundText.gameObject.SetActive(false);
    }

    private void EnemyLoss()
    {
        StopAllCoroutines();
        for (int i = 0; i < enemyShips.Count; i++)
        {
            enemyShips[i].gameObject.SetActive(false);
            enemyShips.Remove(enemyShips[i]);
        }
        for (int i =0; i < playerShips.Count; i++)
        {
            playerShips[i].gameObject.SetActive(true);
        }
        MyEvents.roundEnd.Invoke();
        shipMover.gameObject.SetActive(true);
        roundStarted = false;
        turnTracker = 1f;
        roundEndText.gameObject.SetActive(true);
        readyButton.gameObject.SetActive(true);
        finalRoundText.gameObject.SetActive(false);
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
