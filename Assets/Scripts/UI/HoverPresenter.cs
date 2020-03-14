using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class HoverPresenter : MonoBehaviour
    {
        [SerializeField] Text hoverableText = null;
        [SerializeField] Camera mainCamera;
        [SerializeField] CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }


        void Update()
        {
            if (Game.instance.IsPlaying())
            {
                var hoverable = Game.instance.State().hoverable;

                if (hoverable != null)
                {
                    canvasGroup.alpha = 1;

                    var sprite = hoverable.gameObject.GetComponentInChildren<SpriteRenderer>();

                    var bounds = sprite.bounds;

                    Vector2 pos = mainCamera.WorldToScreenPoint(new Vector3(bounds.center.x, bounds.max.y, 0));
                    transform.position = pos;
                    hoverableText.text = hoverable.title;
                }
                else
                {
                    canvasGroup.alpha = 0;
                }
            }
        }
    }
}