using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Camera))]
    public class Cursor : MonoBehaviour
    {
        [SerializeField] private LayerMask cursorLayerMask;

        private Camera mainCamera = null;
        // Start is called before the first frame update
        void Awake()
        {
            mainCamera = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Game.instance.IsPlaying())
            {

                RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100.0f,cursorLayerMask);

                if (hit.transform != null)
                {
                    var hoverable = hit.collider.gameObject.GetComponent<Hoverable>();

                    if(hoverable != null)
                    {
                        Game.instance.State().hoverable = hoverable;
                    }  
                    else
                    {
                        Game.instance.State().hoverable = null;
                    }
                }
                else
                {
                    Game.instance.State().hoverable = null;
                }
            }
        }
    }
}