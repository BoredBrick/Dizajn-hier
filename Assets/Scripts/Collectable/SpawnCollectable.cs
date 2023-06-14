using UnityEngine;

public class SpawnCollectable : MonoBehaviour
{
    public enum CollectableType { gem, life, boost };
    private CollectableType type;
    public CollectableType Type
    {
        get { return type; }
        set { type = value; }
    }

    void Start()
    {
        int rnd = Random.Range(0, 100);

        if (rnd <= 5)
        {
            transform.Find("Life").gameObject.SetActive(true);
            type = CollectableType.life;            
        }            
        else if (rnd >5 && rnd <= 45)
        {
            transform.Find("QueMark").gameObject.SetActive(true);
            type = CollectableType.boost;
        }
        else if (rnd > 45 && rnd <= 100)
        {
            transform.Find("Gem").gameObject.SetActive(true);
            type = CollectableType.gem;
        } 
    }
}
