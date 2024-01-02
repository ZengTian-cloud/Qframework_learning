
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using QFramework;


namespace ProjectSurvivor
{
	public partial class Player : ViewController
	{
		private static Player instance;
		public static Player Instance {
			get {
				return instance;
			}
		}
		private float horizontal, vertical;
		private Vector2 moveDir;
		public float moveSpeed=5f;

		private void Awake()
		{
			if (instance==null)
				instance = this;
		}

		void Start()
		{
			// Code Here 
			HurtBox.OnTriggerEnter2DEvent(collider2D =>
			{
   this.DestroyGameObjGracefully();
   
   UIKit.OpenPanel<UIGameOverPanel>(); 
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

		}

		private void Update()
		{
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");
			moveDir = new Vector2(horizontal, vertical);
			if (Mathf.Approximately(moveDir.sqrMagnitude, 0))
				moveDir = Vector2.zero;
			else
				moveDir = moveDir.normalized;
			rb.velocity = moveDir  * moveSpeed;
			
		}
	}
}
