using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSpotLight : MonoBehaviour
{
    public Transform player;
    public float height;
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + height, player.position.z);
    }
}
