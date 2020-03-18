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
        [Header("Game Objects")]
        [SerializeField] Camera mainCamera = null;
        [SerializeField] private Transform selectBox = null;
        [Header("Settings")]
        [SerializeField] float baseMovementSpeed = 1.0f;
        [SerializeField] private LayerMask cursorLayerMask;
        [SerializeField] private LayerMask floorLayerMask;
        [Header("State")]
        [SerializeField] Vector2 direction = Vector2.down;
        [SerializeField] bool moving = false;
        [SerializeField] Vector2 mousePosition;



        // Start is called before the first frame update
        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void MoveEvent(InputAction.CallbackContext context)
        {
            if (!Game.instance.IsPlaying())
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

        public void MouseMove(InputAction.CallbackContext context)
        {
            if (!Game.instance.IsPlaying())
                return;

            mousePosition = context.ReadValue<Vector2>();

            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(mousePosition), Vector2.zero, mainCamera.farClipPlane, cursorLayerMask);

            if (hit.transform != null)
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
                {
                    Game.instance.State().currentSelectable = null;
                }
                else
                {
                    Game.instance.State().currentSelectable = hit.collider.gameObject.GetComponent<Selectable>();
                }
            }
            else
            {
                Game.instance.State().currentSelectable = null;
            }

            RaycastHit2D hitFloor = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(mousePosition), Vector2.zero, mainCamera.farClipPlane, floorLayerMask);

            if (hitFloor.transform != null)
            {
                selectBox.gameObject.SetActive(true);
                selectBox.position = new Vector2(Mathf.Floor(hitFloor.point.x), Mathf.Floor(hitFloor.point.y));
            }
            else
            {
                selectBox.gameObject.SetActive(false);
            }
        }

        public void Select(InputAction.CallbackContext context)
        {
            if (!Game.instance.IsPlaying())
                return;

            if (context.performed)
            {
                if (Game.instance.State().currentSelectable != null)
                {
                    Game.instance.State().currentSelectable.Select();
                }
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

            //animator.SetBool("isMoving", moving);
            //animator.SetFloat("moveX", direction.x);
            //animator.SetFloat("moveY", direction.y);

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