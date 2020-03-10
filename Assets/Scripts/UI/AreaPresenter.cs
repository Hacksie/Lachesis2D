using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class AreaPresenter : MonoBehaviour
    {
        [SerializeField] private EnvironmentManager environment;
        [SerializeField] Text areaTitle;
        [SerializeField] Text areaOxygen;

        public void LateUpdate()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            var area = environment.GetFirstCurrentArea();
            if (area != null)
            {
                areaTitle.text = area.title;
                areaOxygen.text = area.state.oxygen.ToString();
            }
            else
            {
                areaTitle.text = @"Unknown Area";
            }


        }

    }
}
