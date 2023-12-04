using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial class Player : ViewController
	{
		public float MoveSpeed = 5f;
		void Start()
		{
			
			HurtBox.OnTriggerEnter2DEvent(collider2D=> {

				this.DestroyGameObjGracefully();
			
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}
        private void Update()
        {
			var horizontal = Input.GetAxisRaw("Horizontal");
			var vertical = Input.GetAxisRaw("Vertical");
			var direction = new Vector2(horizontal, vertical).normalized;
			rb.velocity = direction * MoveSpeed;
        }
    }
}
