using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial class SimpleAbility : ViewController
	{
		private float timmer=0f;

		private void Update()
		{
			timmer += Time.deltaTime;
			if (timmer>=1.5f)
			{
				timmer -= 1.5f;
				var enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
				foreach (var enemy in enemies)
				{
					float distance=Vector3.Distance(Player.Instance.transform.position, enemy.transform.position);
					if (distance<5)
					{
						   enemy.Square.color=Color.red;
						var enemyRefCathck = enemy;
						ActionKit.Delay(0.3f,() =>
						{
							enemyRefCathck.hp--;
							enemyRefCathck.Square.color=Color.white;
						}).StartGlobal();
					}
				}
			}
		}
	}
}
