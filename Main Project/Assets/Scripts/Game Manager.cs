using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tracker : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI roundTrackerText; 
    private float roundTracker = 0f;
    private float turnTracker = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartGame()
    {
        //??
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
