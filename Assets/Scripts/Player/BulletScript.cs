using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    AudioController audioController;
    void Start()
    {
        audioController = GameObject.FindObjectOfType<AudioController>();

        Destroy(gameObject, 3);
    }

    private void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "BulletP1" && gameObject.tag == "BulletP2" || collision.gameObject.tag == "BulletP2" && gameObject.tag == "BulletP1")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "BulletP1" || collision.gameObject.tag == "Enemy" && gameObject.tag == "BulletP2")
        {
            audioController.gameSounds[7].Play();
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(15f);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(15f);
        }
        else if (collision.gameObject.tag == "EnemyGreen" || collision.gameObject.tag == "EnemyPurple" || collision.gameObject.tag == "EnemyBlue" || collision.gameObject.tag == "EnemyGreen")
        {
            Destroy(gameObject);
        }

    }
}




//bool touching = collision.gameObject.CompareTag("BulletP1") && collision.gameObject.CompareTag("BulletP2");
/* TODO2       if (timer >= 0)
{
	if (hitObjectList[0].gameObject.tag == "BulletP1" && hitObjectList[1].gameObject.tag == "BulletP2" || hitObjectList[0].gameObject.tag == "BulletP2" && hitObjectList[1].gameObject.tag == "BulletP1")
	{
		collision.gameObject.GetComponent<SequenceEnemyHealth>().EnemyDied();
	}
}*/

/*		if (touching)
{
	collision.gameObject.GetComponent<SequenceEnemyHealth>().EnemyDied();
}
*/


//collision.GetContact(index);
//collision.GetContacts(contacts[]);

/*TODO2
 timer -= Time.deltaTime;
if(timer <= 0)
{
	hitObjectList.Clear();
}


 */

//TODO List met colliders, timer gaat af vanaf 0,5 seconden, daarna reset de timer en de list
/*TODO2
 * float timer = 0,5f;
 */