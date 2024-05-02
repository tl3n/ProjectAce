using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Collisions : MonoBehaviour
{
    /// <summary>
    /// Rigidbody of the player
    /// </summary>
    private Rigidbody2D PlayerRigidbody;

    /// <summary>
    /// Rigid body initialization of the player sprite for the movement realization convenience
    /// </summary>
    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Response to keystrokes
    /// </summary>
    private void Update()
    {
        // left and right joysticklike movement
        float dirX = Input.GetAxis("Horizontal");
        PlayerRigidbody.velocity = new Vector2(dirX * 7f, PlayerRigidbody.velocity.y);

        // up and down joysticklike movement
        float dirY = Input.GetAxis("Vertical");
        PlayerRigidbody.velocity = new Vector2(PlayerRigidbody.velocity.x, dirY * 7f);
    }
}
