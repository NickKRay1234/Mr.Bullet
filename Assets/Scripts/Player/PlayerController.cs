using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _rotateSpeed = 100, _bulletSpeed = 100;
    private Transform handPos;
    private Transform firePos1, firePos2;

    private LineRenderer _lineRenderer;
    public GameObject bullet;

    private void Awake()
    {
        handPos = GameObject.Find("LeftHand").transform;
        firePos1 = GameObject.Find("FirePosition 1").transform;
        firePos2 = GameObject.Find("FirePosition 2").transform;
        _lineRenderer = GameObject.Find("Gun").GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Aim();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }

    private void Aim()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - handPos.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        handPos.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotateSpeed * Time.deltaTime);

        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, firePos1.position);
        _lineRenderer.SetPosition(1, firePos2.position);
    }

    private void Shoot()
    {
        _lineRenderer.enabled = false;

        GameObject currentBullet = Instantiate(bullet, firePos1.position, Quaternion.identity);

        if (transform.localScale.x > 0)
            currentBullet.GetComponent<Rigidbody2D>().AddForce(firePos1.right * _bulletSpeed, ForceMode2D.Impulse);
        else
            currentBullet.GetComponent<Rigidbody2D>().AddForce(-firePos1.right * _bulletSpeed, ForceMode2D.Impulse);

        Destroy(currentBullet, 2);

    }






}
