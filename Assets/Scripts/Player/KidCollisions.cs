using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class KidCollisions : MonoBehaviour
{
    private SoundManager _soundManager;
    private ScoreManager _scoreManager;
    private KidAnimatorParameterSetter _animatorParamSetter;
    private KidPhysics _kidPhysics;
    private LivesController _livesController;

    [SerializeField]
    private bool _invincible;

    private void DisableInvincibility()
    {
        _invincible = false;
        gameObject.tag = "Player";
    }


    void Start()
    {
        _animatorParamSetter = GetComponent<KidAnimatorParameterSetter>();
        _kidPhysics          = GetComponent<KidPhysics>();
        _livesController     = GetComponent<LivesController>();

        _scoreManager = FindObjectOfType<ScoreManager>();
        _soundManager = FindObjectOfType<SoundManager>();
        _soundManager.PlayGeneralMelody();

        _invincible = false;
    }
    
    
    private void HitGhost()
    {
        if (!_invincible)
        {
            int health = _livesController.GetHit();
            Debug.Log("After being hit, health is " + health);
            _animatorParamSetter.GetHit(health);
        }
    }

    private void HitSweet()
    {
        if (!_invincible)
            _animatorParamSetter.PickUpSweet();
        _scoreManager.AddSweets(1);
    }


    private void HitChoco()
    {
        _soundManager.PlayBoostSound();
        bool fullHealth = _livesController.RestoreLife();
        _scoreManager.AddBoost(BoostType.chocolate, fullHealth);

        if (!_invincible)
        {
            if (fullHealth)
                _animatorParamSetter.PickUpBoost(BoostType.any);
            else
                _animatorParamSetter.PickUpBoost(BoostType.chocolate);
        }
    }
    
    private void HitLollipop()
    {
        _soundManager.PlayBoostSound();
        if (!_invincible)
            _animatorParamSetter.PickUpBoost(BoostType.lollipop);
        _scoreManager.AddBoost(BoostType.lollipop);
    }

    private void HitCake()
    {
        _soundManager.PlayBoostSound();
        
        _scoreManager.AddBoost(BoostType.cake, _invincible);
        if (!_invincible)
        {
            _soundManager.PlayAccelerationSound();
            _invincible = true;
            gameObject.tag = "Invincible";
            _animatorParamSetter.LaunchInvincibility();
        }
    }


    private void OnTriggerEnter2D(Collider2D victim)
    {
        switch (victim.gameObject.tag)
        {
            case "Hit":         return;
            case "Projectile":  return;

            case "Ghost1":
                {
                    HitGhost();
                    if (gameObject.tag.Equals("Invincible"))
                    {
                        victim.gameObject.tag = "Projectile";
                        return;
                    }
                } break;

            case "Choco":   HitChoco();    break;
            case "Cake":    HitCake();     break;
            case "Sweet":   HitSweet();    break;
            case "Lolypop": HitLollipop(); break;
        }

        ObjectCollisions _victimHitInterface = victim.GetComponent<ObjectCollisions>();
        _victimHitInterface.HitPlayer();
    }
}
