using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] bullets;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
//gets the animator component
    private void Awake ()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
//lets it know what if the left mouse button is clicked it is to attack, best button to use but might change to a 
//different one if I want to give it a more retro feel
    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        //object pooling is done here as its better for creating lots of objects so that if lots of bullets are needed then it is possible. 
        //I think that the problem with the bullets not working as intended is here somewhere but am unaware of what might be causing it. remember to ask the teacher to see if they can help
        bullets[FindBullet()].transform.position = firepoint.position;
        bullets[FindBullet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindBullet()
    {
        for(int i = 0; i < bullets.Length; i++)
        {
            if(!bullets[i].activeInHierarchy)
            return i;
        }
        return 0;
    }
}
