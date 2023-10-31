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

    List<GameObject> playerShips;
    List<GameObject> enemyShips;
    GameObject[] activeShips;

    // Start is called before the first frame update
    void Start()
    {
        
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
        readyButton.gameObject.SetActive(false);
        // spawn enemies
        activeShips = GameObject.FindGameObjectsWithTag("Ship");
        for (int i = 0; i < activeShips.Length; i++)
        {
            PlayerShip ship = activeShips[i].GetComponent<PlayerShip>();
            if (!ship.CheckStatus())
            {
                playerShips.Add(activeShips[i]);
            }
            else
            {
                enemyShips.Add(activeShips[i]);
            }
        }
        StartCoroutine(Turn());
        if (roundOver)
        {
            StopAllCoroutines();
            RoundEnd();
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
}
