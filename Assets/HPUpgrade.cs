using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUpgrade : Upgrade {

    void Awake()
    {
        _name = "HP";
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
                    PlayerPrefs.SetInt("MaxHealth", 4);
                }
                break;
            default:
                {
                    _level = 0;
                    PlayerPrefs.SetInt(Name + "Level", _level);
                    PlayerPrefs.SetInt("MaxHealth", 3);
                }
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
