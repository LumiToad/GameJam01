using UnityEngine;

public class Base : MonoBehaviour
{
    public static Base Instance 
    { get; private set; }

    [SerializeField]
    public int maxHP = 500;
    
    public int hp;

    private DamageNumbers damageNumbers;
    private HPBar hpBar;

    private void Awake()
    {
        Instance = this;
        damageNumbers = GetComponentInChildren<DamageNumbers>();
        hpBar = GetComponentInChildren<HPBar>();
        hp = maxHP;
        hpBar.SetHealthBar(maxHP, hp);
    }

    public void TakeDamage(int damage)
    {
        if (damageNumbers != null)
        {
            damageNumbers.PrintDamageNumber(damage, Color.red);
        }

        hp -= damage;

        if (hp <= 0)
        {
            BaseDeath();
        }

        Debug.Log($"Base Damaged: {damage}, current HP: {hp}");
        hpBar.SetHealthBar(maxHP, hp);
    }

    public void BaseDeath()
    {
        // todo
        Destroy(gameObject);
        Destroy(Instance);
    }
}
