using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour {

    private int _avaliableMoney;
    [SerializeField]
    private int _price;

    [SerializeField]
    private Animator[] _indicators;
    [SerializeField]
    private int _upgradeLevel;
    private ShopPanel _shopPanel;

    [SerializeField]
    private Upgrade _upgrade;

	// Use this for initialization
	void Start ()
    {
        _shopPanel = FindObjectOfType<ShopPanel>();

        _avaliableMoney = PlayerPrefs.GetInt("G_AllSweetScore");
        _upgradeLevel = _upgrade.Level;
        

        for (int i = 0; i < _upgradeLevel; i++)
            _indicators[i].SetBool("PowerupPurchased", true);
        if (_upgradeLevel == _indicators.Length)
            gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void TryBuying ()
    {
        _upgradeLevel = _upgrade.Level;
        for (int i = 0; i < _upgradeLevel; i++)
            _indicators[i].SetBool("PowerupPurchased", true);
        _avaliableMoney = PlayerPrefs.GetInt("G_AllSweetScore");

        if (_upgradeLevel < _indicators.Length)
        {
            if (_avaliableMoney > _price)
            {
                _avaliableMoney -= _price;
                PlayerPrefs.SetInt("G_AllSweetScore", _avaliableMoney);
                Debug.Log("Spent" + _price + "money on " + _upgrade.Name);
                _upgrade.PurchaseUpgrade();
                int level = _upgrade.Level;
                _indicators[level - 1].SetBool("PowerupPurchased", true);
            }
        }

        if (_upgrade.Level >= _indicators.Length)
            gameObject.SetActive(false);

        _shopPanel.UpdateSweetCounter();
    }
}
