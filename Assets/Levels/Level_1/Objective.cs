using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Level_1.Instance.ObjectiveTrigger(this, other);
    }
}
