using UnityEngine;
namespace FoodGame
{
    public class KnifeScript : DragDropScript
    {
        private Animator animator;
        protected override void Start()
        {
            animator = GetComponent<Animator>();
            base.Start();
        }
        protected override void Update()
        {
            base.Update();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Box"))
            {
                animator.Play("Cutting");
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Box"))
            {
                animator.Play("Idle");
            }
        }
    }
}