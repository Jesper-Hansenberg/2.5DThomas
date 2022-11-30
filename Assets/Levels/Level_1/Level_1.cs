using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1 : MonoBehaviour
{
    public GameObject Objective_1;
    public GameObject Objective_2;
    
    //Singleton
    public static Level_1 Instance;

    //Setup singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        Objective_2.SetActive(false);
    }

    public void ObjectiveTrigger(Objective ob, Collider col)
    {
        if (ob.gameObject.name == "Objective_1")
        {
            GameManager.Instance.Main.GetComponent<CameraMovement>().ChangePerspective();
            Objective_2.SetActive(true);
        }
        if (ob.gameObject.name == "Objective_2")
        {
            GameManager.Instance.ToMainMenu();
        }
    }
}
