using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public int ammountCount = 0; // Số lượng có thể xóa đi được

	[SerializeField] private GameObject[] playerPrefabs;

	private void Awake()
	{
		if(instance == null)
			instance = this;
	}

	public void SpawnPlayer(int index)
	{
		if (SpawnManager.instance.spawnedObject != 0) // Khi mà đã sinh ra obstacle thì
		{
			Destroy(GameObject.FindGameObjectWithTag("Player"), 0.45f);
		}

		Instantiate(playerPrefabs[index], transform.position, Quaternion.identity);
	}
}
