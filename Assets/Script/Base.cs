using UnityEngine;

public class Base : MonoBehaviour
{
    public static Base Instance 
    { get; private set; }

    [SerializeField]
    public int hp = 500;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
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
