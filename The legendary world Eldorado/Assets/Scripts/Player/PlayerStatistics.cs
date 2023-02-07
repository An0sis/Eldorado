using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public int money;
    public int level = 1;
    public LvlNumber lvl;
    
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    
    public int maxMana = 200;
    public int currentMana;
    public ManaBar manaBar;
    
    public int maxXp = 200;
    public int currentXp;
    public XpBar xpBar;

    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth,0);
        
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana,0);
        
        xpBar.SetMaxXp(maxXp,0);

        lvl.ChangeSprite(level);
    }
 
    // Update is called once per frame
    void Update()
    {
        lvl.ChangeSprite(level);
        healthBar.SetHealth(currentHealth);
        xpBar.SetXp(currentXp);
        manaBar.SetMana(currentMana);
        if(Input.GetKey(KeyCode.W))
            addXp(50);
    }

    public void addXp(int amount)
    {
        if (currentXp + amount >= maxXp)
        {
            level += 1;
            damage = (int) (level * 1.05);
            amount -= maxXp - currentXp;
            currentXp = 0;
            currentXp += amount;
            maxXp += maxXp / 2;
            currentHealth += 10;
            maxHealth += 10;
            xpBar.SetMaxXp(maxXp,0);
            healthBar.SetMaxHealth(maxHealth,0);
        }
        else
        {
            currentXp += amount;
        }
    }

    public void TakeDamage(int degat)
    {
        currentHealth -= degat;
    }

    public void addMana(int amount)
    {
        if (currentMana + amount >= maxMana)
            currentMana = maxMana;
        else
            currentMana += amount;
    }

    public void addHealth(int amount)
    {
        if (currentHealth + amount >= maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += amount;
    }
}
