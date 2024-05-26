using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Vector3 nextPos;

	bool speedUp, spawned;

	private void Update()
	{
		if(PlayerController.instance.ammountCount < 1 && !speedUp) // Điều kiện chỉ được tăng tốc 1 lần
		{
			speedUp = true;
			moveSpeed = 50f; // Tăng tốc gate
		}	

		nextPos = transform.position;
		nextPos.z -= moveSpeed * Time.deltaTime;
		transform.position = nextPos;

		if(transform.position.z < -0.5f && !spawned) // Sinh ra chỉ 1 gameobject mỗi lần
		{
			SpawnManager.instance.spawnedObject++; // Tăng điểm 
			spawned = true;
			SpawnManager.instance.Spawn();
			Destroy(gameObject);
		}
	}
}
