using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private Animator _monsterAnim;

    private float _attackLenght = 0;
    private bool _canAttack = false;

    void Update()
    {
        if (_attackLenght > 0) _attackLenght -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _monsterAnim.SetBool("isAttacking", true);
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_attackLenght <= 0)
            {
                _attackLenght = 0.833f;
                _canAttack = true;
            }

            if (_attackLenght < 0.15 && _canAttack)
            {
                _canAttack = false;
                _statsManager.DealDamage(collision.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _monsterAnim.SetBool("isAttacking", false);
        }
    }


}
