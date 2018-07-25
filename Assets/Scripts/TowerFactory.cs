using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform towerParent;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            Tower newTower = Instantiate(tower, baseWaypoint.transform.position, Quaternion.identity, towerParent);
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
        Tower tower = towers.Dequeue();
        tower.currentWaypoint.hasTower = false;
        newWaypoint.hasTower = true;
        tower.currentWaypoint = newWaypoint;
        tower.transform.position = newWaypoint.transform.position;
        towers.Enqueue(tower);
    }
}
