using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FoodGame.Cutting
{
    public class CuttingFoodScript : DragDropScript, ITimer
    {
        private bool isCutting = false;
        private bool isTouchingKnife = false;
        [SerializeField] private GameObject healthBar;
        private Image healthBarImage;
        [SerializeField] private float cuttingSpeed;
        [SerializeField] private GameObject cubedFood;
        protected override void Start()
        {
            healthBarImage = healthBar.GetComponent<Image>();
            base.Start();
        }
        protected override void Update()
        {
            base.Update();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                healthBar.SetActive(true);
            }
            else if (collision.gameObject.CompareTag("Knife"))
            {
                isTouchingKnife = true;
                if (!isCutting)
                {
                    StartCoroutine(CuttingFood());
                }
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Knife"))
            {
                isTouchingKnife = false;
            }
        }

        void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag("Knife") && !isCutting)
            {
                isCutting = true;
                StartCoroutine(CuttingFood());
            }
        }
        private IEnumerator CuttingFood()
        {   isCutting = true;
            while (healthBarImage.fillAmount > 0 && isTouchingKnife)
            {
                if (!isTime)
                {
                    isTime = true;
                    StartCoroutine(WaitForTime());
                }
                yield return new WaitForSeconds(1);
                healthBarImage.fillAmount -= cuttingSpeed;
            }
            isTime = false;
            isCutting = false;
            if (healthBarImage.fillAmount <= 0)
            {
                cubedFood.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        private IEnumerator WaitForTime()
        {
            while (isTime)
            {
                yield return new WaitForSeconds(1);
                AffectTime();
            }
        }
        public void AffectTime()
        {
            TimeManagment manager = Object.FindFirstObjectByType<TimeManagment>();
            if (manager != null)
            {
                manager.IncreaseTime(1);
            }
        }
    }
}
