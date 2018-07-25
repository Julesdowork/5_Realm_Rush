using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            Tower newTower = Instantiate(tower, baseWaypoint.transform.position, Quaternion.identity);
            towers.Enqueue(newTower);
            baseWaypoint.hasTower = true;
            newTower.currentWaypoint = baseWaypoint;
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    void MoveExistingTower(Waypoint newWaypoint)
    {
        //Tower tower = towers.Dequeue();
    }
}
