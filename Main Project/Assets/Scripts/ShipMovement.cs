using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private GameObject selectedShip;
    private List<GameObject> playerShips = new List<GameObject>();
    private bool approved = true;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship"))
        {
            PlayerShip player = ship.GetComponent<PlayerShip>();
            if (!player.Status())
            {
                playerShips.Add(ship);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship"))
        {
            PlayerShip player = ship.GetComponent<PlayerShip>();
            if (!player.Status())
            {
                playerShips.Add(ship);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShipClick();
        }

        if (Input.GetKeyDown(KeyCode.W) && selectedShip.transform.position.y < -0.5)
        {
            foreach (GameObject ship in playerShips)
            {
                if (ship.transform.position == new Vector3(selectedShip.transform.position.x, selectedShip.transform.position.y + 1.5f, selectedShip.transform.position.z))
                {
                    approved = false;
                }
            }
            if (approved) {
                selectedShip.transform.position = new Vector3(selectedShip.transform.position.x, selectedShip.transform.position.y + 1.5f, selectedShip.transform.position.z);
            }

        }

        if (Input.GetKeyDown(KeyCode.S) && selectedShip.transform.position.y > -3.5)
        {
            foreach (GameObject ship in playerShips)
            {
                if (ship.transform.position == new Vector3(selectedShip.transform.position.x, selectedShip.transform.position.y - 1.5f, selectedShip.transform.position.z))
                {
                    approved = false;
                }
            }
            if (approved) {
                selectedShip.transform.position = new Vector3(selectedShip.transform.position.x, selectedShip.transform.position.y - 1.5f, selectedShip.transform.position.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && selectedShip.transform.position.x > -7.4)
        {
            foreach (GameObject ship in playerShips)
            {
                if (ship.transform.position == new Vector3(selectedShip.transform.position.x - 1.5f, selectedShip.transform.position.y, selectedShip.transform.position.z))
                {
                    approved = false;
                }
            }
            if (approved)
            {
                selectedShip.transform.position = new Vector3(selectedShip.transform.position.x - 1.5f, selectedShip.transform.position.y, selectedShip.transform.position.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && selectedShip.transform.position.x < -2.9)
        {
            foreach (GameObject ship in playerShips)
            {
                if (ship.transform.position == new Vector3(selectedShip.transform.position.x + 1.5f, selectedShip.transform.position.y, selectedShip.transform.position.z))
                {
                    approved = false;
                }
            }
            if (approved)
            {
                selectedShip.transform.position = new Vector3(selectedShip.transform.position.x + 1.5f, selectedShip.transform.position.y, selectedShip.transform.position.z);
            }
        }

        approved = true;
    }

    private void ShipClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            GameObject target = hit.transform.gameObject;
            PlayerShip ship = target.GetComponent<PlayerShip>();
            if (!ship.Status())
            {
                selectedShip = target;
            }
        }
    }
}
