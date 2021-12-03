using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{

    public GameObject mainLayout;

    public GameObject levelSelectLayout;

    public void StartGameBtn()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LevelSelect()
    {
        mainLayout.SetActive(false);
        levelSelectLayout.SetActive(true);
    }

    public void startLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void startLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void startLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void startLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void startLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }
    public void startLevel6()
    {
        SceneManager.LoadScene("Level 6");
    }
}
