using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float missileSpeed = 25f;

    void Update()
    {
        transform.Translate(Vector3.up * missileSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {  
           
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
            Destroy(gm, 2f);

           // Add gold when missile destroys enemy
         PlayerStats.instance.AddGold(90); // Add 20 gold

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
   

}
