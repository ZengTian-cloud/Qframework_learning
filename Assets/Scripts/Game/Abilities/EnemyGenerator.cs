using System;
using UnityEngine;
using QFramework;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace ProjectSurvivor
{
	public partial class EnemyGenerator : ViewController
	{
		private float timmer=0f;

		private void Update()
		{
			timmer += Time.deltaTime;
			if (timmer>=1f)
			{
				timmer -= 1f;
				var player = Player.Instance.transform.position;
				var radangle=Random.Range(0, 360f);
				var radRadius = radangle * Mathf.Deg2Rad;
				var dir = new Vector3(Mathf.Cos(radRadius), math.sin(radRadius));
				var generatePos = player + dir * 10f;
				Enemy.Instantiate()
					.Position(generatePos)
					.Show();
			}
		}
	}
}
