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
    [SerializeField] float playerHealth = 10f;
    [SerializeField] float enemyHealth = 10f;
    private float roundTracker = 1f;
    private float turnTracker = 1f;
    List<PlayerShip> savedPlayerShips;
    List<PlayerShip> activeShips;

    // Start is called before the first frame update
    void Start()
    {
        // grab all ships, and put them into activeShips
        /*
        for (int i = 0; i < activeShips.Count; i++)
        {
            PlayerShip ship = activeShips[i];
        
            if (!ship.CheckStatus())
            {
                savedPlayerShips.Add(ship);
            }
        }
        */
        turnTracker = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int i =0; i < activeShips.Length; i++)
        {
            PlayerShip ship = activeShips[i];

            ship.Move();
        }

        // Empty activeShips and then fill it up with all active ships, to keep it updated in case of ship destructions
        activeShips = null;
        // grab all ships, put them into activeShips

        TurnIncrease();

        if (enemyHealth <= 0)
        {
            RoundEnd();
        }
        */

        // Testing RoundIncrease(), TurnIncrease(), RoundEnd() and ResetTurn()
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (roundEndText.IsActive())
            {
                roundEndText.gameObject.SetActive(false);
            }
            TurnIncrease();
            if (turnTracker > 5)
            {
                RoundEnd();
                RoundIncrease();
            }
        }
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

    private void RoundEnd()
    {
        ResetTurn();
        roundEndText.gameObject.SetActive(true);
    }

    private void TurnIncrease()
    {
        turnTracker++;
        Debug.Log("Turn: " + turnTracker);
    }

    private void ResetTurn()
    {
        turnTracker = 1f;
        Debug.Log("Turn: " + turnTracker);
    }
}
