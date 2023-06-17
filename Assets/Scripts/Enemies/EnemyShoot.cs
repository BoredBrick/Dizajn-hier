using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject colorIndicator;
    public List<GameObject> stringsProjectiles = new List<GameObject>();
    private float fireForce = 100f;
    private float remainingShootingTime;
    private float colorIndicatorTime;
    private Color randomColor;
    private bool wasColorChose = false;
    private int numberOfShots;
    private bool stringsWereDestroyed = true;

    private void Start()
    {
        numberOfShots = stringsProjectiles.Count;
        remainingShootingTime = Random.Range(1f, 2.5f);
        colorIndicatorTime = Random.Range(0.5f, remainingShootingTime);
    }

    void Update()
    {
        if (EnemyMove.isPlayerClose && numberOfShots > 0)
        {

            if (remainingShootingTime >= 0)
            {
                if (!wasColorChose)
                {
                    wasColorChose = true;
                    randomColor = Colors.GetRandomColor();
                }

                if (colorIndicatorTime >= 0)
                {
                    colorIndicatorTime -= Time.deltaTime;
                }

                if (colorIndicatorTime <= 0)
                {
                    colorIndicator.GetComponent<SpriteRenderer>().color = randomColor;
                    colorIndicatorTime = Random.Range(0.5f, remainingShootingTime);
                }

                remainingShootingTime -= Time.deltaTime;
            }

            if (remainingShootingTime <= 0 && (stringsProjectiles.Count - 1) >= 0 && stringsWereDestroyed)
            {
                colorIndicator.GetComponent<SpriteRenderer>().color = Color.white;
                wasColorChose = false;
                stringsWereDestroyed = false;             
                stringsProjectiles[stringsProjectiles.Count - 1].GetComponent<SpriteRenderer>().color = randomColor;
                stringsProjectiles[stringsProjectiles.Count - 1].SetActive(true);
                stringsProjectiles[stringsProjectiles.Count - 1].GetComponent<Rigidbody2D>().gravityScale = 1;
                stringsProjectiles[stringsProjectiles.Count - 1].GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
                stringsProjectiles[stringsProjectiles.Count - 1].transform.SetParent(null);
                StartCoroutine(DestroyStrings());               
                remainingShootingTime = Random.Range(1f, 2.5f);
                colorIndicatorTime = Random.Range(0.5f, remainingShootingTime);
                numberOfShots--;
            }
        }
        else
        {
            colorIndicator.GetComponent<SpriteRenderer>().color = Color.white;
            wasColorChose = false;
            remainingShootingTime = Random.Range(1f, 2.5f);
            colorIndicatorTime = Random.Range(0.5f, remainingShootingTime);
        }
    }

    IEnumerator DestroyStrings()
    {
        yield return new WaitForSeconds(3f);
        Destroy(stringsProjectiles[stringsProjectiles.Count - 1]);
        stringsProjectiles.RemoveAt(stringsProjectiles.Count - 1);
        stringsWereDestroyed = true;
    }
}
