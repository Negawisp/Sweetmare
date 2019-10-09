using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LolypopUpgrade : Upgrade {

    void Awake()
    {
        _name = "Lolypop";
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
                    PlayerPrefs.SetInt("LolypopSweets", 6);
                }
                break;
            case 2:
                {
                    PlayerPrefs.SetInt("LolypopSweets", 8);
                }
                break;
            case 3:
                {
                    PlayerPrefs.SetInt("LolypopSweets", 10);
                }
                break;
            case 4:
                {
                    PlayerPrefs.SetInt("LolypopSweets", 12);
                }
                break;
            case 5:
                {
                    PlayerPrefs.SetInt("LolypopSweets", 14);
                }
                break;
            default:
                {
                    _level = 0;
                    PlayerPrefs.SetInt(Name + "Level", _level);
                    PlayerPrefs.SetInt("LolypopSweets", 4);
                }
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
