using System.Collections;
using UnityEngine;
using Photon.Pun;

public enum PlayerState
{
    walk,
    attack
}

public class PlayerMovement : MonoBehaviourPun
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    private PhotonView view;
    public bool block = false;
    public bool blockMarket = false;
    public bool blockInventory = false;
    public Bar bar;
    public PlayerStatistics stats;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        block = blockInventory || blockMarket;
        if(Input.GetKey(KeyCode.P))
            Application.Quit();
        if (view.IsMine && !block)
        {
            change = Vector3.zero;
            change.x = Input.GetAxis("Horizontal");
            change.y = Input.GetAxis("Vertical");
            if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && !block)
            {
                if (bar.Items[bar.active].type == "Potion")
                {
                    switch (bar.Items[bar.active].type)
                    {
                        case ("Health"):
                            stats.addHealth(bar.Items[bar.active].potionAmount);
                            bar.inventory.RemoveItem(bar.Items[bar.active], 1);
                            break;
                        case ("Mana"):
                            stats.addMana(bar.Items[bar.active].potionAmount);
                            bar.inventory.RemoveItem(bar.Items[bar.active], 1);
                            break;
                        default:
                            stats.addXp(bar.Items[bar.active].potionAmount);
                            bar.inventory.RemoveItem(bar.Items[bar.active], 1);
                            break;
                    }
                }
                else
                {
                    if (bar.Items[bar.active].type == "Sword")
                    {
                        stats.damage += bar.Items[bar.active].damage;
                        StartCoroutine(AttackCo());
                        stats.damage -= bar.Items[bar.active].damage;
                        
                    }
                    StartCoroutine(AttackCo());
                }
            }
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if(change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
    
    private void SetAnimFloat(Vector2 setVector)
    {
        animator.SetFloat("moveX", setVector.x);
        animator.SetFloat("moveY", setVector.y);
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
