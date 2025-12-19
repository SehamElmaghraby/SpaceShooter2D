using UnityEngine;
using System.Collections; 

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    [Header("Missile")]
    public GameObject missile;
    public Transform missileSpawnPosition;
    public float destroyTime = 5f;
    public Transform muzzlespawnposition;

    void Update()
    {
        PlayerMovement();
        PlayerShoot();
    }

    void PlayerMovement()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xPos, yPos, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -8f, 8f); 
        clampedPos.y = Mathf.Clamp(clampedPos.y, -4.5f, 4.5f); 
        transform.position = clampedPos;
    }

    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnMissile();
            SpawnMuzzleFlash();
        }
    }

    void SpawnMissile()
    {
        GameObject gm = Instantiate(missile, missileSpawnPosition.position, Quaternion.identity);
        Destroy(gm, destroyTime);
    }

    void SpawnMuzzleFlash()
    {
        GameObject muzzle = Instantiate(GameManager.instance.muzzleflash, muzzlespawnposition.position, Quaternion.identity);
        Destroy(muzzle, destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        
        GameObject gm = Instantiate(
            GameManager.instance.explosion,
            transform.position,
            transform.rotation
        );
        Destroy(gm, 1f);

        Destroy(collision.gameObject);

        
        GameManager.instance.playerDestroyed = true;
          // Disable player visuals immediately
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // Start Game Over after explosion duration
        StartCoroutine(ShowGameOverAfterDelay(0.5f));
      
        // Destroy(this.gameObject);
    }
}


    private IEnumerator ShowGameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.instance.GameOver();
    }
    

}
