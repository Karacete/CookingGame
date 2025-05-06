using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace FoodGame.Cooking
{
    public class CookingFoodScript : DragDropScript, ITimer
    {
        [SerializeField] private GameObject fire;
        private GameObject pan;
        [SerializeField] private GameObject healthBar;
        private Image healthBarImage;
        [SerializeField] private float cookingSpeed;
        [SerializeField] private GameObject cookedFood;
        private TimeManagment timeManager;
        protected override void Start()
        {
            pan = GameObject.FindGameObjectWithTag("Pan");
            healthBarImage = healthBar.GetComponent<Image>();
            timeManager = Object.FindFirstObjectByType<TimeManagment>();
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("CubedBox"))
            {
                box.SetActive(false);
            }
            if (other.gameObject.CompareTag("Pan"))
            {
                fire.SetActive(true);
                healthBar.SetActive(true);
                StartCoroutine(CookingFood());
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Pan"))
            {
                fire.SetActive(false);
            }
        }
        private IEnumerator CookingFood()
        {
            while (healthBarImage.fillAmount > 0)
            {
                if (!isTime)
                {
                    isTime = true;
                    StartCoroutine(WaitForTime());
                }
                yield return new WaitForSeconds(1);
                healthBarImage.fillAmount -= cookingSpeed;
            }
            isTime = false;
            cookedFood.SetActive(true);
            gameObject.SetActive(false);
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
            if (timeManager != null)
            {
                timeManager.IncreaseTime(1);
            }
        }
    }
}
