using System;
using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial class Enemy : ViewController
	{
		public float hp = 3;
		public float moveSpeed = 2f;
		private Transform player;
		private Vector3 moveDir;
		void Start()
		{
			if (Player.Instance!=null)
			{
				player = Player.Instance.transform;	
			}
			
		}

		private void Update()
		{
			if (player!=null)
			{
				moveDir = (player.transform.position - transform.position).normalized;
				transform.position += moveDir * Time.deltaTime * moveSpeed;
			}

			if (hp<=0)
			{
				//UIKit.OpenPanel<UIGamePassPanel>();
				this.DestroyGameObjGracefully();
				Global.Exp.Value++;
			}
		}
	}
}
