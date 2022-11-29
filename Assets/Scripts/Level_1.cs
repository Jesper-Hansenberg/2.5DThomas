using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1 : MonoBehaviour
{
    public GameObject Objective_1;
    public GameObject Objective_2;
    public static Level_1 Instance;

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
            Objective_2.SetActive(true);
        }
        if (ob.gameObject.name == "Objective_2")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
     Application.Quit(); 
#endif
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
