using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial  class Player : ViewController
	{
		public float MoveSpeed = 5f;
		 static Player instance;
		public static Player Instance
		{
			get {return instance;}
		}
        private void Awake()
        {
			if (instance == null)
				instance = this;
        }
        void Start()
		{
			
			HurtBox.OnTriggerEnter2DEvent(collider2D=> {

				this.DestroyGameObjGracefully();
				ResKit.Init();
				UIKit.OpenPanel<UIGameOverPanel>();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			
		}
        private void Update()
        {
			float horizontal = Input.GetAxisRaw("Horizontal");
			float vertical = Input.GetAxisRaw("Vertical");
			Vector2 direction = new Vector2(horizontal, vertical).normalized;
			rb.velocity = direction * MoveSpeed;
        }
        private void OnDestroy()
        {
			instance = null;
        }
    }
}
