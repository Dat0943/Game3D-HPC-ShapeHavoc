using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour 
{
    int firstChildCount; // Lấy ra số lượng thằng con có trong Destroyable
	int countOfChild; // Lấy ra số lượng con sau những lần xóa
	int maxDestroyable, minDestroyable; // Max, min xóa bao nhiêu thằng con
	int destroyable, indexDestroyable;

	private void Start()
	{
		firstChildCount = countOfChild = transform.childCount; // Đưa ra giá trị có bao nhiêu thằng con
		maxDestroyable = (int)(countOfChild - (countOfChild / 2));
		minDestroyable = (int)(countOfChild / 2);

		destroyable = (int)Random.Range(minDestroyable, maxDestroyable + 1);

		PlayerController.instance.ammountCount = firstChildCount - destroyable; // Số lượng có thể xóa của người chơi
	}

	private void Update()
	{
		countOfChild = transform.childCount;

		if(countOfChild > (firstChildCount - destroyable)) // Nếu số hình được xóa lớn hơn 1 nửa thì xóa
		{
			Destroy();
		}
	}

	void Destroy()
	{
		indexDestroyable = Random.Range(0, countOfChild); // Xóa ngẫu nhiên 1 trong các thằng con

		Destroy(transform.GetChild(indexDestroyable).gameObject);
	}
}
