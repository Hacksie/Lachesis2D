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

        [Header("Settings")]
        [SerializeField] float baseMovementSpeed = 1.0f;
        [Header("State")]
        [SerializeField] Vector2 direction = Vector2.down;
        [SerializeField] bool moving = false;


        // Start is called before the first frame update
        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void MoveEvent(InputAction.CallbackContext context)
        {
            if (Game.instance.State().gameState != GameStateEnum.Playing)
                return;

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

        public void SuffocateEvent()
        {
            Logger.Log(name, name, " suffocated");
            Game.instance.SetGameState(GameStateEnum.DeadAir);
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
            if (!Game.instance.IsPlaying())
                return;

            UpdatePosition();

        }

        void UpdatePosition()
        {
            if (moving)
            {
                transform.Translate(direction * baseMovementSpeed * Time.deltaTime);
            }

        }
    }
}