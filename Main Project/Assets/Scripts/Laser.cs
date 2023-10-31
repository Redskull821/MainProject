using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float laserSpeed = 0.1f;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(laserSpeed, 0, -1) * Time.deltaTime;
    }
}
