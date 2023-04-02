using System.Collections.Generic;
using UnityEngine;

public class SectionGenerator : MonoBehaviour
{
    [SerializeField] private SectionBank bank;
    [SerializeField] private Transform lastSection;
    [SerializeField] private GameObject nextSectionsTrigger;

    [SerializeField] private Vector3 newPosition = new(0, 0, 0);
    private int section = 1, lvl = 0;

    List<Section> sectionsPool;
    List<Section> sectionsMedium;
    List<Section> sectionsHard;

    private void Start()
    {
        SectionBank localBank = bank.GetComponent<SectionBank>();
        sectionsPool = localBank.GetSectionsEasy();
        sectionsMedium = localBank.GetSectionsMedium();
        sectionsHard = localBank.GetSectionsHard();
    }
    private void Update()
    {
        //Distance sa vezme z pocitadla skore
        int distance = 0;
            
        if (distance >= 1000 && distance < 2000)
            sectionsPool.AddRange(sectionsMedium);
        else if (distance >= 2000)
            sectionsPool.AddRange(sectionsHard);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject nextSectionGenerator = null;
            for (int i = 0; i <= 5; i++)
            {
                Section nextSection = sectionsPool[Random.Range(0, sectionsPool.Count)];
                newPosition = lastSection.position + new Vector3(300 * section, lvl, 0);

                Instantiate(nextSection, newPosition, Quaternion.identity);

                if (i == 3)
                    nextSectionGenerator = Instantiate(nextSectionsTrigger, newPosition + new Vector3(-150, 30, 0), Quaternion.identity);

                switch (nextSection.GetComponent<Section>().getEndsOnLvl())
                {
                    case -3:
                        lvl -= 300;
                        break;
                    case -2:
                        lvl -= 200;
                        break;
                    case -1:
                        lvl -= 100;
                        break;

                    case 1:
                        lvl += 100;
                        break;
                    case 2:
                        lvl += 200;
                        break;
                    case 3:
                        lvl += 300;
                        break;

                    default:
                        lvl += 0;
                        break;
                }
                section++;
            }
            nextSectionGenerator.GetComponent<SectionGenerator>().setNextPosition(newPosition);
            Destroy(gameObject, 0.1f);
        }
    }

    public Vector3 getNextPosition() { return newPosition; }
    public void setNextPosition(Vector3 newPosition)
    {
        this.newPosition = newPosition;
    }
}
