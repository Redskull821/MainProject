using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tracker : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI roundTrackerText; 
    private float roundTracker;
    private float turnTracker;
    [SerializeField] float playerHealth = 10f;
    [SerializeField] float enemyHealth = 10f;

    // Start is called before the first frame update
    void Start()
    {
        roundTracker = 1f;
        turnTracker = 1f;
    }

    // Update is called once per frame
    void Update()
    {

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
