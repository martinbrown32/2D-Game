using UnityEngine;
//this is all to make sure that the bullet works as intended, triggeres when hitting an object and also returns when done
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;
    private BoxCollider2D boxCollider;
    //keep the anim at the bottom as I think one of the issues might have been caused by it being at the top
    private Animator anim;
    
    //this will make sure it dosent keep flying away forever
    //it dosent seem to work so aditional testing is needed. ask teacher for opinion on it as cant seem to find problem and 
    //wary about googling too much or using chatgbt to ask for what the possible error is
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
        lifetime += Time.deltaTime;
        if (lifetime > 10) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("bullethit");
    }
    //keep it as _direction as that makes sure that it is not equal to the local variable. it is not a mistake!
        public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        hit = false;
        gameObject.SetActive(true);
        boxCollider.enabled = true;
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;
            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    //deactivates the bullet after the hit animation has finished so that it dosent keep going
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}
