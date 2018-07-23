using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;

	// Use this for initialization
	void Start ()
    {
		foreach (Block block in path)
        {
            print(block.gameObject.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
