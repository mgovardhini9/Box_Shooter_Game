using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    public GameObject robots;
    private bool robotsInstantiated = false;
    private int scoreAmount = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.score >= scoreAmount && !robotsInstantiated)
        {
            robotsInstantiated = true;
            GameObject spawnedRobots = Instantiate(robots, transform.position, transform.rotation) as GameObject;
        }
    }
}
