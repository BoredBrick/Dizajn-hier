using Unity.VisualScripting;
using UnityEngine;
using static SpawnCollectable;

public class Collector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            switch (collision.gameObject.GetComponent<SpawnCollectable>().Type)
            {
                case CollectableType.gem:
                    PlayerProperties.playerGems++;
                    break;
                case CollectableType.life:
                    PlayerProperties.playerLifes++;
                    break;
                default:
                    Debug.Log("Nieco ine");
                    break;
            }
            collision.gameObject.SetActive(false);
        }
    }
}
