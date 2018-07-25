using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;

    int towerCount = 0;

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerCount < towerLimit)
        {
            Instantiate(tower, baseWaypoint.transform.position, Quaternion.identity);
            towerCount++;
        }
        else
        {
            MoveExistingTower();
        }
    }

    void MoveExistingTower()
    {

    }
}
