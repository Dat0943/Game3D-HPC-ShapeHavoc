using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public static SpawnManager instance;

	[SerializeField] private GameObject[] obstacles;

	public int spawnedObject;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	private void Start()
	{
		Spawn();
	}

	public void Spawn()
	{
		if (spawnedObject < 4)
		{
			Instantiate(obstacles[0], transform.position, Quaternion.identity);
			PlayerController.instance.SpawnPlayer(0);
		}
		else if(spawnedObject >= 4 && spawnedObject < 8)
		{
			Instantiate(obstacles[1], transform.position, Quaternion.identity);
			PlayerController.instance.SpawnPlayer(1);
		}
		else if(spawnedObject >= 8 && spawnedObject < 12)
		{
			Instantiate(obstacles[2], transform.position, Quaternion.identity);
			PlayerController.instance.SpawnPlayer(2);
		}
		else if(spawnedObject >= 12)
		{
			Instantiate(obstacles[3], transform.position, Quaternion.identity);
			PlayerController.instance.SpawnPlayer(3);
		}
	}
}
