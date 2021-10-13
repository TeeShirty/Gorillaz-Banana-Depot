using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAiming : MonoBehaviour
{

    public int minPower = 0;
    public int maxPower = 100;

    int _currentPower;
    int _currentAngle;
    public SpriteRenderer aimSprite;
    public Text powerLabel, angleLabel;

    public ShootProjectile shootProjectile;

    public GameObject player1;
    public GameObject player2;

    bool canFire;

    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.player1Turn = true;
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (GameManager.player1Turn == true && CompareTag("PlayerOne"))
            {
                    CalculatePower();
                    CalculateAngle();
            }
            if (GameManager.player1Turn == false && CompareTag("PlayerTwo"))
            {
                    CalculatePower();
                    CalculateAngle();
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (GameManager.player1Turn == true && CompareTag("PlayerOne"))
            {
                if (canFire == true)
                {
                    ShootProjectile();
                    StartCoroutine(WaitandShoot(2f));
                    //GameManager.player1Turn = false;

                    Debug.Log("Player 2 turn true");
                    Debug.Log("Player 1 Turn" + GameManager.player1Turn);
                }
            }
            if (GameManager.player1Turn == false && CompareTag("PlayerTwo"))
            {
                if (canFire == true)
                {
                    ShootProjectile();
                    StartCoroutine(WaitandShoot(2f));
                    //GameManager.player1Turn = true;

                    Debug.Log("Player 1 turn true");
                    Debug.Log("Player 2 Turn" + GameManager.player1Turn);
                }
            }
        }
    }

        public void CalculateAngle()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            Vector3 direction = mousePosition - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            UpdateAngle((int)angle);
        }

        void UpdateAngle(int angle)
        {
            _currentAngle = angle;
            aimSprite.transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.forward);
            if (_currentAngle < 0)
            {
                _currentAngle += 360;
            }
            angleLabel.text = "Angle : " + _currentAngle;

        }

        public void CalculatePower()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            float distance = Vector3.Distance(mousePosition, transform.position);
            UpdatePower((int)distance * 2);
        }

        void UpdatePower(int distance)
        {
            _currentPower = Mathf.Clamp(distance, minPower, maxPower);
            aimSprite.transform.localScale = new Vector3(_currentPower / 12, _currentPower / 12);

            powerLabel.text = "Power : " + _currentPower;
        }

        public void ShootProjectile()
        {
            shootProjectile.Shoot(_currentPower);
        }

        private IEnumerator WaitandShoot(float waitTime)
        {
            canFire = false;
            yield return new WaitForSeconds(waitTime);
            GameManager.player1Turn = !GameManager.player1Turn;
            UpdateAngle(0);
            UpdatePower(0);
            canFire = true;
        }
     
}
