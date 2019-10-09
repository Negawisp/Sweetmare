using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeUpgrade : Upgrade {

    void Awake()
    {
        _name = "Cake";
        Debug.Log("_name: " + _name + ", Name: " + Name);
        _level = PlayerPrefs.GetInt(Name + "Level");
    }


    public override void PurchaseUpgrade()
    {
        Debug.Log("Entered Cake Purchase Upgrade.");

        if (++_level > MaxLevel)
        {
            _level = MaxLevel;
            Debug.LogError("Too big level for upgrade \"" + Name + "\"");
        }

        PlayerPrefs.SetInt(Name + "Level", _level);
        switch (_level)
        {
            case 1:
                {
                    PlayerPrefs.SetInt("SpeedUpDuration", 2);
                }
                break;
            case 2:
                {
                    PlayerPrefs.SetInt("SpeedUpDuration", 3);
                }
                break;
            case 3:
                {
                    PlayerPrefs.SetInt("SpeedUpDuration", 4);
                }
                break;
            case 4:
                {
                    PlayerPrefs.SetInt("SpeedUpDuration", 6);
                }
                break;
            case 5:
                {
                    PlayerPrefs.SetInt("SpeedUpDuration", 8);
                }
                break;
            default:
                {
                    _level = 0;
                    PlayerPrefs.SetInt(Name + "Level", _level);
                    PlayerPrefs.SetInt("SpeedUpDuration", 1);
                }
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
