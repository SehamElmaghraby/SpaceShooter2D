using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    [Header("Missile")]
    public GameObject missile;
    public Transform missileSpawnPosition;
    public float destroyTime = 5f;
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
           GameObject gm = Instantiate(missile,missileSpawnPosition);
           gm.transform.SetParent(null);
           Destroy(gm,destroyTime);
        }
        
    }
}
