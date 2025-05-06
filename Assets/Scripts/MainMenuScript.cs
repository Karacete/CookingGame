using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject processPanel;
    public void SceneOne()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneTwo()
    {
        SceneManager.LoadScene(2);
    }
    public void SceneZero()
    {
        SceneManager.LoadScene(0);
    }
    public void ProcessTimeOpen()
    {
        processPanel.SetActive(true);
    }
    public void ProcessTimeClose()
    {
        processPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
