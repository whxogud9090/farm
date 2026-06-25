using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;

    public int CurrentHealth { get; private set; }
    public bool IsDead => CurrentHealth <= 0;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead)
        {
            return;
        }

        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);

        if (IsDead)
        {
            SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth = Mathf.Min(maxHealth, CurrentHealth + amount);
    }
}
