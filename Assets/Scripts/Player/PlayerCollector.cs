using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static SpawnCollectable;

public class PlayerCollector : MonoBehaviour
{
    public static bool isSpeedModified = false;
    public static bool isStickModified = false;

    public AudioSource gemSFX;
    public AudioSource pickUpSFX;
    public AudioSource pickDownSFX;
    public AudioSource newLifeSFX;

    [SerializeField] private GameObject powerUpHUD;

    [SerializeField] private Sprite speedBoost;
    [SerializeField] private Sprite speedSlow;
    [SerializeField] private Sprite longStick;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            switch (other.GetComponent<SpawnCollectable>().Type)
            {
                case CollectableType.gem:
                    gemSFX.Play();
                    PlayerProperties.gems++;
                    break;

                case CollectableType.life:
                    newLifeSFX.Play();
                    PlayerProperties.lives++;
                    break;

                case CollectableType.speedBoost:
                    pickUpSFX.Play();
                    StartCoroutine(SetPowerUpHUD("Speed Boost", null));
                    StartCoroutine(ModifySpeed(10, 180));
                    break;

                case CollectableType.speedSlow:
                    pickDownSFX.Play();
                    StartCoroutine(SetPowerUpHUD("Speed Slow", null));
                    StartCoroutine(ModifySpeed(5, 80));
                    break;

                case CollectableType.longStick:
                    pickUpSFX.Play();
                    StartCoroutine(SetPowerUpHUD("Infinite Stick", null));
                    StartCoroutine(ModifyStick(20, 200));
                    break;

                default:
                    Debug.Log("Nieco ine");
                    break;
            }
            other.gameObject.SetActive(false);
        }
    }
    private IEnumerator ModifySpeed(float time, int speed)
    {
        isSpeedModified = true;
        PlayerProperties.speedForce = speed;
        yield return new WaitForSeconds(time);
        isSpeedModified = false;
        PlayerProperties.speedForce = DefaultValues.speedForce;
    }

    private IEnumerator ModifyStick(float time, int stickTime)
    {
        isStickModified = true;
        PlayerProperties.remainingStickTime = stickTime;
        yield return new WaitForSeconds(time);
        isStickModified = false;
        PlayerProperties.remainingStickTime = DefaultValues.remainingStickTime;
    }
    private IEnumerator SetPowerUpHUD(string text, Sprite sprite)
    {
        powerUpHUD.SetActive(true);
        powerUpHUD.GetComponent<Text>().text = text;
        yield return new WaitForSeconds(2);
        //powerUpHUD.transform.Find("PowerUpImg").GetComponent<SpriteRenderer>().sprite = sprite;
        powerUpHUD.SetActive(false);
    }
}
