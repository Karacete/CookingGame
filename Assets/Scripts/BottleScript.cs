using UnityEngine;

namespace FoodGame
{
    public class BottleScript : MonoBehaviour
    {
        private Animator spicingAnimator;
        private void Start()
        {
            spicingAnimator = GetComponent<Animator>();
        }
        public void SpicingAnimation()
        {
            spicingAnimator.Play("Spicing");
        }
        public void AnimationStop()
        {
            spicingAnimator.Play("Idle");
        }
    }
}