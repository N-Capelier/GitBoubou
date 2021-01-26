using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Range(0, 1000)]
        [SerializeField] float speed = 0;

        [SerializeField] Animator animator = null;
        [SerializeField] SpriteRenderer sr = null;

        Rigidbody2D rb = null;

        [HideInInspector] public Vector2 inputDirection;
        bool isGoingRight = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        Vector2 GetInputDirection()
        {
            Vector2 _dir = Vector2.zero;

            if(Input.GetKey(KeyCode.Z))
            {
                _dir.SetY(_dir.y++);
            }
            if(Input.GetKey(KeyCode.S))
            {
                _dir.SetY(_dir.y--);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                _dir.SetY(_dir.x--);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _dir.SetY(_dir.x++);
            }

            if(_dir.magnitude != 0)
            {
                return _dir.normalized;
            }
            else
            {
                return Vector2.zero;
            }
        }

        private void Update()
        {
            inputDirection = GetInputDirection();
            AnimateCharacter();
        }

        private void FixedUpdate()
        {
            rb.velocity = inputDirection * speed;
        }

        void AnimateCharacter()
        {
            if (inputDirection == Vector2.zero)
            {
                animator.SetBool("isMoving", false);
                animator.SetBool("isUpside", false);
            }
            else if (inputDirection.y == 1)
            {
                animator.SetBool("isMoving", true);
                animator.SetBool("isUpside", true);
            }
            else
            {
                animator.SetBool("isMoving", true);
                animator.SetBool("isUpside", false);
            }

            if(isGoingRight)
            {
                if(inputDirection.x < 0)
                {
                    isGoingRight = false;
                    sr.flipX = false;
                }
            }
            else
            {
                if (inputDirection.x > 0)
                {
                    isGoingRight = true;
                    sr.flipX = true;
                }
            }
        }

    }
}