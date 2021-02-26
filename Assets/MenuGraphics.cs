using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MenuGraphics : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.names;
        dropdown.AddOptions(QualitySettings.names.ToList());
        dropdown.value = QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    public void SetQuality() {
        QualitySettings.SetQualityLevel(dropdown.value);
    }
}
