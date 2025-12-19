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
        Destroy(gm, 2f);

        Destroy(collision.gameObject);

        
        GameManager.instance.playerDestroyed = true;

      
        Destroy(this.gameObject);
    }
}


    private IEnumerator ShowGameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.instance.GameOver();
    }
    

}
