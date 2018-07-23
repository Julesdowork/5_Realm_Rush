using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(FollowPath());
        print("Hey, I'm back at start!");
    }

    IEnumerator FollowPath()
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting block: " + waypoint.gameObject.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol.");
    }
}
