using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public float ZDistance = -10f;
    
    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, ZDistance);
    }

    public void ChangePerspective(){
        Camera.main.orthographic = !Camera.main.orthographic;
    }
}
