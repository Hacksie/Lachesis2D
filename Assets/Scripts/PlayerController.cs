using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        Animator animator;
        [SerializeField] Vector2 direction = Vector2.down;
        [SerializeField] bool moving = false;
        [SerializeField] float baseMovementSpeed = 1.0f;


        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void MoveEvent(InputAction.CallbackContext context)
        {
            var dir = context.ReadValue<Vector2>();

            if (dir.sqrMagnitude > Vector2.kEpsilon)
            {
                direction = dir;
                moving = true;
            }
            else
            {
                moving = false;
            }

        }

        private void LateUpdate()
        {
            animator.SetBool("moving", moving);
            animator.SetFloat("directionX", direction.x);
            animator.SetFloat("directionY", direction.y);

        }

        // Update is called once per frame
        void Update()
        {
            UpdatePosition();
        }

        void UpdatePosition()
        {
            if(moving)
            {
                transform.Translate(direction * baseMovementSpeed * Time.fixedDeltaTime);
            }
            
        }
    }
}