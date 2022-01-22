using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform player;
    
    // Update is called once per frame
    private void Update()
    {

        //Making the camera stay put if the player's z position changes but follows the player nontheless.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

    }
}
