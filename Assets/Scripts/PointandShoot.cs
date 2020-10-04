using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointandShoot : MonoBehaviour
{
    public GameObject CrossHair;
    public GameObject Player;
    public GameObject FireBallPrefab;
    public float FireBallSpeed;
    private Vector3 crosshair_point;

    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        crosshair_point = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        CrossHair.transform.position = new Vector2(crosshair_point.x, crosshair_point.y);

        Vector3 difference = crosshair_point - Player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        //Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireProjectile(direction, rotationZ);
        }
    }

    void fireProjectile(Vector2 direction,float rotationZ)
    {
        GameObject FireBall = Instantiate(FireBallPrefab) as GameObject;
        FireBall.transform.position = Player.transform.position;
        FireBall.transform.rotation = Quaternion.Euler(0.0f, 0.0f,rotationZ);
        FireBall.transform.rotation *= Quaternion.Euler(0, 0, 90);
        FireBall.GetComponent<Rigidbody2D>().velocity = direction * FireBallSpeed;
    }
}

