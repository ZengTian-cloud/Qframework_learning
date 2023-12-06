using UnityEngine;
using QFramework;

namespace ProjectSurvivor
{
	public partial class Enemy : ViewController
	{
        public float MovementSpeed = 2f;
        
        private void Start()
        {
            
        }
        private void Update()
        {                        
            var dir = (Player.Instance.transform.position - transform.position).normalized;
            transform.Translate(dir*Time.deltaTime*MovementSpeed);
        }
   
    }
}
