using UnityEngine;

public class log : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    public Item loot;
    public Item loot2;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;
        CheckDistance();
        Death();

    }

    void Death()
    {
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
            target.gameObject.GetComponentInChildren<InventoryManager>().AddItem(loot,1);
            target.gameObject.GetComponentInChildren<InventoryManager>().AddItem(loot2,1);
        }
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            changeAnim(temp - transform.position);
            myRigidbody.MovePosition(temp);
            anim.SetBool("wakeUp", true);
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStatistics playerHealth = collision.transform.GetComponent<PlayerStatistics>();
            playerHealth.TakeDamage(1);
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }else if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        } else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }else if(direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
}
