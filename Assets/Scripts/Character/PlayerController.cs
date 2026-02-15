using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        [Range(0.1f, 10f)]
        private float Speed;

        [SerializeField]
        [Range(0.1f, 10f)]
        private float CameraSpeed;

        //private MainControls PlayerControls;

        [SerializeField]
        private Camera PlayerCamera;

        [SerializeField]
        [Range(5f, 50f)]
        private float CameraZoom;
        
        private static float CameraDistance = -10;

        private Animator PlayerAnimator;

        private Rigidbody2D rb;

        private void Awake()
        {
            //PlayerControls = new MainControls();

            PlayerAnimator = GetComponent<Animator>();

            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector2 Movement = PlayerInput.Instance.mainControls.PlayerControls.Movement.ReadValue<Vector2>();

            PlayerAnimator.SetFloat("Vertical", Movement.y);
            PlayerAnimator.SetFloat("Horizontal", Movement.x);

            if(Movement.x != 0 || Movement.y != 0)
            {
                PlayerAnimator.SetBool("IsWalking", true);
            }
            else
            {
                PlayerAnimator.SetBool("IsWalking", false);
            }

            rb.MovePosition(transform.position += new Vector3(Movement.x, Movement.y, 0) * Speed * Time.deltaTime);

            PlayerCamera.transform.position = Vector3.Lerp(PlayerCamera.transform.position, transform.position + new Vector3(0, 0, CameraDistance), CameraSpeed * Time.deltaTime);

            PlayerCamera.orthographicSize = CameraZoom;
        }
    }
}