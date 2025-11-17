using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UFO : MonoBehaviour
{

    public GameObject enemyLaserPrefab;
    public GameObject enemylaserPos;
    public float fireRate = 1.5f;         // Seconds between shots
    private float fireTimer = 0f;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        if (enemyLaserPrefab == null || enemylaserPos == null)
        {
            Debug.LogError("UFO: Laser prefab or spawn point is NOT assigned!");
            return;
        }

        GameObject laser = Instantiate(enemyLaserPrefab);

        // OPTIONAL: aim at player if the laser supports SetDirection()
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector2 dir = player.transform.position - laser.transform.position;

            // If your laser has EnemyLaser script:
            EnemyLaser el = laser.GetComponent<EnemyLaser>();
            if (el != null)
                el.SetDirection(dir);
        }
    }
}
