using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    private GameManager gameManager;
    public bool isStopping;

    // Start is called before the first frame update
    void Start()
    {
        isStopping = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stop"))
        {
            isStopping = true;
            gameManager.StopCar(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stop"))
        {
            isStopping = false;
        }
    }
}