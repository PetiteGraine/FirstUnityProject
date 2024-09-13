using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private GameObject _entity;
    public Slider healthSlider;
    public float MaxHP = 5f;
    public float CurrentHP;
    public float AttackDamage = 1;

    void Start()
    {
        CurrentHP = MaxHP;
    }

    void Update()
    {
        HealthBarUpdate();
    }

    void HealthBarUpdate()
    {
        if (healthSlider.value != CurrentHP)
        {
            healthSlider.value = CurrentHP;
        }
    }

    public void TakeDamage(float dmg)
    {
        CurrentHP -= dmg;
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<StatsManager>();
        if (atm != null)
        {
            atm.TakeDamage(AttackDamage);
            atm.DestroyIfDead();
        }
    }

    public void DestroyIfDead()
    {
        if (CurrentHP <= 0)
        {
            CurrentHP = MaxHP;
            // Destroy(_entity);
        }
    }
}