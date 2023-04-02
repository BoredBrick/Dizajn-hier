using System.Collections.Generic;
using UnityEngine;

public class SectionGenerator : MonoBehaviour
{
    [SerializeField] private SectionBank bank;
    [SerializeField] private Transform lastSectionPosition;
    [SerializeField] private GameObject nextSectionsTrigger;

    [SerializeField] private Vector3 newPosition;
    private int section = 1, lvl = 0;

    List<Section> sectionsPool;
    List<Section> sectionsMedium;
    List<Section> sectionsHard;

    private void Start()
    {
        newPosition = lastSectionPosition.position;
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
            if (lastSectionPosition.GetComponent<Section>().getEndsOnLvl() > 0)
            {
                lvl += 100;
            }
            GameObject nextSectionGenerator = null;
            for (int i = 0; i <= 5; i++)
            {
                Section nextSection = sectionsPool[Random.Range(0, sectionsPool.Count)];
                newPosition = lastSectionPosition.position + new Vector3(300 * section, lvl, 0);

                Transform tr = Instantiate(nextSection, newPosition, Quaternion.identity).transform;

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

                if (i == 5 && section > 1)
                    nextSectionGenerator.GetComponent<SectionGenerator>().SetLastSectionPosition(tr);
            }
            Destroy(gameObject);
        }
    }

    public void SetLastSectionPosition(Transform lastSection)
    {
        this.lastSectionPosition = lastSection;
    }
}
