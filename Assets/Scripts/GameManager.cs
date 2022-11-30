using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera Main;
    public GameObject Player;
    public GameObject MainMenu;
    
    //Singleton
    public static GameManager Instance;
    
    //Setup singleton
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

    //Enable main menu and handle player soft reset
    public void ToMainMenu()
    {
        if(MainMenu.activeInHierarchy) return;
        MainMenu.SetActive(true);
        SceneManager.UnloadSceneAsync("Level_1");
        Player.transform.position = Vector3.up;
        Player.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX);
    }

    //Check if escape is pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToMainMenu();
        }
    }

    //Button connection to GUI
    public void MainMenuPlay()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Additive);
        MainMenu.SetActive(false);
        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }
    
    //Button connection to GUI
    public void MainMenuExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
     Application.Quit(); 
#endif
    }
}
