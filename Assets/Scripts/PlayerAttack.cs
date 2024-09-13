using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private StatsManager _statsManager;
    private float _attackCooldown = 0;

    void Update()
    {
        if (_attackCooldown > 0) _attackCooldown -= Time.deltaTime;
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Monster") && Input.GetKeyDown(KeyCode.Q))
        {
            if (_attackCooldown <= 0)
            {
                _statsManager.DealDamage(collision.gameObject);
                _attackCooldown = 0.01f;
            }
        }
    }
}