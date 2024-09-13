using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private GameObject _entity;
    public Slider healthSlider;
    public float maxHP = 5f;
    public float health;
    public float attackDamage = 1;
    void Start()
    {
        health = maxHP;
    }

    void Update()
    {
        HealthBarUpdate();
    }

    void HealthBarUpdate()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<StatsManager>();
        if (atm != null)
        {
            atm.TakeDamage(attackDamage);
            atm.DestroyIfDead();
        }
    }

    public void DestroyIfDead()
    {
        if (health <= 0)
        {
            health = maxHP;
            // Destroy(_entity);
        }
    }
}