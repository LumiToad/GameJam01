using UnityEngine;

public class Base : MonoBehaviour
{
    public static Base Instance 
    { get; private set; }

    [SerializeField]
    public int hp = 500;

    private DamageNumbers damageNumbers;

    private void Awake()
    {
        Instance = this;
        damageNumbers = GetComponentInChildren<DamageNumbers>();
    }

    public void TakeDamage(int damage)
    {
        if (damageNumbers != null)
        {
            damageNumbers.PrintDamageNumber(damage, Color.white);
        }

        hp -= damage;

        if (hp <= 0)
        {
            BaseDeath();
        }

        Debug.Log($"Base Damaged: {damage}, current HP: {hp}");
    }

    public void BaseDeath()
    {
        // todo
        Destroy(gameObject);
        Destroy(Instance);
    }
}
