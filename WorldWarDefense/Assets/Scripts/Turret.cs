using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour{
    
    private Transform target;
    
    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start(){
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }else{
            target = null;
        }
    }

    void Update(){
        if(target == null){
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        //partToRotate.rotation = Quaternion.AngleAxis (0f, rotation.y);

        if(fireCountdown <= 0f){
            Shoot();
            Debug.Log("chamou o shoot aqui");
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }

    void Shoot(){
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null){
            bullet.Seek(target);

        }
    }

    void onDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
