using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pinbattlers.Menus
{
    public class ResolutionsDropdownController : MonoBehaviour
    {
        private void Start()
        {
            TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
            List<string> resolutions = new List<string>();

            foreach (Resolution r in Screen.resolutions)
            {
                resolutions.Add(r.width.ToString() + "x" + r.height.ToString() + "Hz" + r.refreshRate.ToString());

                if (r.height == Screen.height && r.width == Screen.width)
                    dropdown.value = resolutions.IndexOf(r.width.ToString() + "x" + r.height.ToString() + "Hz" + r.refreshRate.ToString());
            }

            dropdown.AddOptions(resolutions);
            dropdown.RefreshShownValue();
        }

        public void ChangeResolutionValue(int resolutionIndex) =>
            Screen.SetResolution(Screen.resolutions[resolutionIndex].width, Screen.resolutions[resolutionIndex].height, Screen.fullScreen);
    }
}