using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tracker : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI roundTrackerText;
    [SerializeField] float playerHealth = 10f;
    [SerializeField] float enemyHealth = 10f;
    private float roundTracker = 0f;
    private float turnTracker = 0f;
    GameObject[] savedPlayerShips;
    GameObject[] activeShips;

    // Start is called before the first frame update
    void Start()
    {
        RoundIncrease();
        TurnIncrease();
        // grab all player ships and store them in savedPlayerShips
        // grab all ships, and put them into activeShips
    }

    // Update is called once per frame
    void Update()
    {
        // run through activeShips
        //      perform Move() for each ship
        // clear activeShips
        // grab all ships, put them into activeShips
        for (int i =0; i < activeShips.Length; i++)
        {
            PlayerShip ship = activeShips[i];
            ship.Move();
        }
        TurnIncrease();
        if (enemyHealth <= 0)
        {
            // initiate RoundEnd
        }
    }

    private void RoundEnd()
    {
        ResetTurn();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void RoundIncrease()
    {
        roundTracker++;
        roundTrackerText.text = "Round: " + roundTracker;
    }

    private void TurnIncrease()
    {
        turnTracker++;
    }

    private void ResetTurn()
    {
        turnTracker = 0f;
    }
}
