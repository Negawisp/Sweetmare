using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarySkinChanger : MonoBehaviour {

	public void SetPumpkinSkin()
    {
        PlayerPrefs.SetInt ("FullBodySkin", (int)CostumeType.ShrekGirl);
    }
}
