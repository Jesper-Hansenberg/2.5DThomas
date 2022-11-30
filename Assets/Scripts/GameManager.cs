using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainMenu;

    public static GameManager Instance;
    public Camera Main;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        Main = Camera.main;
        DontDestroyOnLoad(gameObject);
    }

    public void ToMainMenu()
    {
        if(MainMenu.activeInHierarchy) return;
        MainMenu.SetActive(true);
        SceneManager.UnloadSceneAsync("Level_1");
        Player.transform.position = Vector3.up;
        Player.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToMainMenu();
        }
    }

    public void MainMenuPlay()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Additive);
        MainMenu.SetActive(false);
        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }

    public void MainMenuExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
     Application.Quit(); 
#endif
    }
}
