using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    [Header("Missile")]
    public GameObject missile;
    public Transform missileSpawnPosition;
    public float destroyTime = 5f;
    public Transform muzzlespawnposition ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();
        PlayerShoot();
    }
    void PlayerMovement()
    {
         float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (xPos,yPos,0) * speed * Time.deltaTime;
        transform.Translate(movement);
 
    }

    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         SpawnMissile();
         SpawnMuzzleFlash ();
        }
        
    }
    void SpawnMissile()
    {
        GameObject gm = Instantiate(missile,missileSpawnPosition);
           gm.transform.SetParent(null);
           Destroy(gm,destroyTime); 
    }
    void SpawnMuzzleFlash ()
    {
        GameObject muzzle = Instantiate (GameManager.instance.muzzleflash,muzzlespawnposition);
         muzzle.transform.SetParent(null);
           Destroy(muzzle,destroyTime); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
             GameObject gm =Instantiate( GameManager.instance.explosion,transform.position,transform.rotation);
            Destroy(gm,2f);
            Destroy(this.gameObject);
            Debug.Log("Game Over");
            //Game Over Screen Will Appear Here
            
        }
    }
}
