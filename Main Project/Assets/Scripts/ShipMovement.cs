using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private GameObject selectedShip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShipClick();
        }

        if (Input.GetKeyDown(KeyCode.W) && selectedShip.transform.position.y < -0.5)
        {
            selectedShip.transform.position = new Vector3(selectedShip.transform.position.x, selectedShip.transform.position.y + 1.5f, selectedShip.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.S) && selectedShip.transform.position.y > -3.5)
        {
            selectedShip.transform.position = new Vector3(selectedShip.transform.position.x, selectedShip.transform.position.y - 1.5f, selectedShip.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.A) && selectedShip.transform.position.x > -7.4)
        {
            selectedShip.transform.position = new Vector3(selectedShip.transform.position.x - 1.5f, selectedShip.transform.position.y, selectedShip.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.D) && selectedShip.transform.position.x < -2.9)
        {
            selectedShip.transform.position = new Vector3(selectedShip.transform.position.x + 1.5f, selectedShip.transform.position.y, selectedShip.transform.position.z);
        }
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
