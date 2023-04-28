using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Lights
{
    Red,
    Green
}
public class GameManager : MonoBehaviour
{
    public Lights eLight;
    public GameObject cars;
    public NavMeshAgent agent;
    public Transform[] SpawnPoints;
    public GameObject[] destObjects;
    public Transform[] destinations;


    public GameObject[] stopGameObjects;


    // Start is called before the first frame update
    void Start()
    {
        stopGameObjects = GameObject.FindGameObjectsWithTag("Stop");
        foreach (GameObject stopGameObject in stopGameObjects)
        {
            stopGameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (eLight)
        {
            case Lights.Red:
                break;
            case Lights.Green:
                break;
            default:
                break;
        }

    }

    public void RedLight()
    {
        eLight = Lights.Red;
        foreach (GameObject stopGameObject in stopGameObjects)
        {
            stopGameObject.SetActive(true);
        }
    } 
    public void GreenLight()
    {
        eLight = Lights.Green;
        foreach (GameObject stopGameObject in stopGameObjects)
        {
            if (agent != null && agent.isStopped)
            {
                agent.isStopped = false;
            }
            stopGameObject.SetActive(false);
        }
    }
public void SpawnCars()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        GameObject carInstance = Instantiate(cars, SpawnPoints[spawnIndex].transform.position, SpawnPoints[spawnIndex].transform.rotation);

        trigger carTrigger = carInstance.GetComponentInChildren<trigger>();

        destObjects = GameObject.FindGameObjectsWithTag("Destination");
        destinations = new Transform[destObjects.Length];
        for (int i = 0; i < destObjects.Length; i++)
        {
            destinations[i] = destObjects[i].transform;
        }

        int destIndex = Random.Range(0, destinations.Length);

        while (destinations[destIndex] == SpawnPoints[spawnIndex])
        {
            destIndex = Random.Range(0, destinations.Length);
        }

        agent = carInstance.GetComponent<NavMeshAgent>();

        agent.SetDestination(destinations[destIndex].position);

    }
    public void StopCar(GameObject carTriggerObject)
    {
        trigger carTrigger = carTriggerObject.GetComponent<trigger>();
        if (carTrigger != null)
        {
            if (agent != null)
            {
                agent.isStopped = true;
            }
        }
    }






}

