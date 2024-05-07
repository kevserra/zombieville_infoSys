using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Just code to have the camera follow the player's character
public class CamFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, 2.5f, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
