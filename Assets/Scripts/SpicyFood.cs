using UnityEngine;
using FoodGame;
using System.Collections;
using UnityEngine.UI;
public class SpicyFood : DragDropScript
{
    [SerializeField] private Image healthBarImage;
    [SerializeField] private float spicedSpeed;
    [SerializeField] private GameObject spicedFood;
    private BottleScript bottle;
    protected override void Start()
    {
        healthBarImage = healthBarImage.GetComponent<Image>();
        bottle = GameObject.FindGameObjectWithTag("Bottle").GetComponent<BottleScript>();
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
        if (other.gameObject.CompareTag("SpicedBox"))
        {
            bottle.SpicingAnimation();
            healthBarImage.gameObject.SetActive(true);
            StartCoroutine(SpicingFood());
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
    private IEnumerator SpicingFood()
    {
        while (healthBarImage.fillAmount > 0)
        {
            if (!isTime)
            {
                isTime = true;
                StartCoroutine(WaitForTime());
            }
            yield return new WaitForSeconds(1);
            healthBarImage.fillAmount -= spicedSpeed;
        }
        isTime = false;
        bottle.AnimationStop();
        spicedFood.SetActive(true);
        gameObject.SetActive(false);
    }
}
