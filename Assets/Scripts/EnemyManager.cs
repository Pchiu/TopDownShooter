using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class EnemyManager : MonoBehaviour {

	List<Ship> enemies;
	private static EnemyManager enemyManager;
	public static EnemyManager Instance { get { return enemyManager; } }
	// Use this for initialization

	void Awake()
	{
		enemyManager = this;
	}

	void Start () {
		enemies = new List<Ship> ();
		SpawnEnemy (new Vector2 (3, 0), "Target");
		SpawnEnemy (new Vector2 (-5, 0), "Target");
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SpawnEnemy(Vector2 position, string name)
	{
		Ship enemy = (Ship)Instantiate (Resources.Load ("Prefabs/" + name, typeof(Ship)), new Vector3(position.x, position.y, 0), Quaternion.LookRotation(new Vector3(0,0,1)));		
		enemies.Add (enemy);
	}

	public void RemoveEnemy(Ship enemy)
	{
		enemies.Remove (enemy);
	}

	public Ship FindNearestEnemy(Vector3 source)
	{
		Ship nearestEnemy = null;
		float closestDistanceSqr = Mathf.Infinity;
		foreach(Ship potentialTarget in enemies)
		{
			Vector3 directionToTarget = potentialTarget.transform.position - source;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if(dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				nearestEnemy = potentialTarget;
			}
		}
		
		return nearestEnemy;
	}
}
