using UnityEngine;

public class Base : MonoBehaviour
{
    public static Base Instance { get; private set; }

    [SerializeField]
    public int hp = 500;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void BaseDeath()
    {
        // todo
        Destroy(gameObject);
        Destroy(Instance);
    }
}
