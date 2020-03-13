using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class AreaPresenter : MonoBehaviour
    {
        [SerializeField] private EnvironmentManager environment = null;
        [SerializeField] Text areaTitle = null;
        [SerializeField] Text areaAir = null;
        [SerializeField] Text areaTemperature = null;
        [SerializeField] Text areaPower = null;

        public void LateUpdate()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            var area = environment.GetFirstCurrentArea();
            if (area == null)
            {
                areaTitle.text = @"Unknown Area";
                areaAir.text = @"?";
                areaTemperature.text = @"?";
                areaPower.text = @"?";
                return;
            }

            areaTitle.text = area.title;
            areaAir.text = Mathf.RoundToInt(area.state.air).ToString();
            areaTemperature.text = Mathf.RoundToInt(area.state.temperature).ToString();
            areaPower.text = Mathf.RoundToInt(area.state.power).ToString();
        }
    }
}
