using System.Collections.Generic;
using FoodGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookedFoodScript : DragDropScript, ITimer
{
    private TimeManagment timeManager;
    private static int counter = 0;
    private Scene scene;
    protected override void Start()
    {
        timeManager = Object.FindFirstObjectByType<TimeManagment>();
        scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == box.name)
        {
            if (AreAllActive())
            {
                AffectTime();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == box.name)
            counter -= 1;
    }
    public static bool AreAllActive()
    {

        counter += 1;

        if (counter != 4)
            return false;
        else
            return true;
    }
    public void AffectTime()
    {
        Debug.Log(scene.buildIndex);
        if (timeManager != null)
        {

            if (scene.buildIndex == 1)
            {
                timeManager.DoubleScore();
            }
            if (scene.buildIndex == 2)
            {
                timeManager.TrippleScore();
            }

        }
    }
}
