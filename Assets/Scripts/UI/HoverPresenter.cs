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


        // Update is called once per frame
        void Update()
        {
            if (Game.instance.IsPlaying())
            {
                var hoverable = Game.instance.State().hoverable;

                


                if (hoverable != null)
                {
                    //gameObject;
                    canvasGroup.alpha = 1;
                    Vector2 pos = mainCamera.WorldToScreenPoint(hoverable.gameObject.transform.position);
                    this.transform.position = pos;
                    hoverableText.text = hoverable.title;
                }
                else
                {
                    canvasGroup.alpha = 0;
                    //gameObject.SetActive(false);
                }
            }
        }
    }
}