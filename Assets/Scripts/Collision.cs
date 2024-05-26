using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
	[SerializeField] private GameObject cubeDestroyPS;

	private void OnMouseDown()
	{
		if(PlayerController.instance.ammountCount > 0)
		{
			Destroy(Instantiate(cubeDestroyPS, transform.position, Quaternion.identity), 1f);
			Destroy(gameObject);
			PlayerController.instance.ammountCount--; // Xóa 1 cái thì giảm đi đến khi nào giới hạn lượt xóa
		}	
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Obstacle"))
		{
			GameManager.instance.EndGame();
		}
	}
}
