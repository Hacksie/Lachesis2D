using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Camera))]
    public class Cursor : MonoBehaviour
    {
        [SerializeField] private LayerMask cursorLayerMask;
        [SerializeField] private LayerMask floorLayerMask;
        [SerializeField] private Transform selectBox = null;

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
                    if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
                    {
                        selectBox.gameObject.SetActive(true);
                        Game.instance.State().currentSelectable = null;
                        selectBox.position = new Vector2(Mathf.Floor(hit.point.x), Mathf.Floor(hit.point.y));
                    }
                    else
                    {
                        selectBox.gameObject.SetActive(false);
                        var selectable = hit.collider.gameObject.GetComponent<Selectable>();

                        if (selectable != null)
                        {
                            
                            Game.instance.State().currentSelectable = selectable;
                        }
                        else
                        {
                            Game.instance.State().currentSelectable = null;
                        }
                    }
                }
                else
                {
                    Game.instance.State().currentSelectable = null;
                }
            }
        }
    }
}