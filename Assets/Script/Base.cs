using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    public static Base Instance 
    { get; private set; }

    [SerializeField]
    public int hp = 500;

    public ParticleSystem VFX;
    public Canvas GameOverScreen;

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
        VFX.gameObject.SetActive(true);
        GameOverScreen.gameObject.SetActive(true);
        //Destroy(gameObject);
        //Destroy(Instance);
    }

    public void Looser()
    {
        SceneManager.LoadScene(0);
    }
}
