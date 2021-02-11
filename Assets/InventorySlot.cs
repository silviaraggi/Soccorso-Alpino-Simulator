using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Item item;
    public GameObject cane;
    public GameObject berretto;
    public GameObject zaino;
    public GameObject guanti;
    public GameObject disperso;
    public GameObject maglia;
    public GameObject sceneInfo;
    private int scene;
    private void Start()
    {
        sceneInfo = GameObject.Find("SceneInfo");
        scene = sceneInfo.GetComponent<SceneInfo>().GetScene();
        switch (scene)
        {
            case 2:
                cane = GameObject.Find("CaneUnity2");
                berretto = GameObject.Find("Berretto");
                zaino = GameObject.Find("Zainetto");
                guanti = GameObject.Find("Guanti");
                maglia = GameObject.Find("magliasolida");
                disperso = GameObject.Find("Disperso");
                break;
        }
    }

    private void Update()
    {
        if (item != null)
        {
            icon.sprite = item.icon;
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null&&GameObject.Find("CaneUnity2")&&GameObject.Find("CaneUnity2").GetComponent<CaneBosco>())
        {
            switch (this.item.name)
            {
                case "Maglia":
                    if (berretto.GetComponent<InteractableClue>().GetCollect() == false)
                        cane.GetComponent<CaneBosco>().GetNewClue(berretto);
                    break;
                case "Cappello":
                    if (zaino.GetComponent<InteractableClue>().GetCollect() == false)
                        cane.GetComponent<CaneBosco>().GetNewClue(zaino);
                    break;
                case "Zaino":
                    if (guanti.GetComponent<InteractableClue>().GetCollect() == false)
                        cane.GetComponent<CaneBosco>().GetNewClue(guanti);
                    break;
                case "Guanti":
                    if (disperso.GetComponent<Disperso>().GetDispersoState() == Disperso.DispersoState.Wander)
                        cane.GetComponent<CaneBosco>().GetNewClue(disperso);
                    break;
            }
                    GameObject.Find("Inventory").SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

        }
    }
}
