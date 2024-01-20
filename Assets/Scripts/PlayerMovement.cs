// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 1f;
//     private Rigidbody2D rigidbody2D;
//     private bool isMoving;
//     private Vector2 userInput;
//     private SpriteRenderer spriteRenderer;

//     private void FixedUpdate() {
//         Move();
//     }

//     private void ProcessInput() {
//         float moveX = Input.GetAxisRaw("Horizontal");
//         float moveY = Input.GetAxisRaw("Vertical");

//         userInput = new Vector2(moveX, moveY).normalized;
//     }

//     private void Move() {
//         rigidbody2D.velocity = new Vector2(userInput.x * moveSpeed, userInput.y * moveSpeed);
//         if (userInput.x < 0) {
//             spriteRenderer.flipX = true;
//         } else if(userInput.x > 0) {
//             spriteRenderer.flipX = false;
//         }
//     }

//     private void Start() {
//         rigidbody2D = GetComponent<Rigidbody2D>();
//         spriteRenderer = GetComponent<SpriteRenderer>();
//     }
// }
