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
    public GameObject stecca;
    public GameObject bende;
    public GameObject fissaggi;
    public GameObject sceneInfo;
    private int scene;
    private GameObject _stivali;
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

            case 1:
                stecca = GameObject.Find("stecca");
                bende = GameObject.Find("bende");
                fissaggi = GameObject.Find("fissaggi");
                _stivali = GameObject.Find("stivali");
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
        if (item != null && scene == 1)
        {
            switch (this.item.name)
            {
                case "stecca":
                    if (_stivali.GetComponent<SkinnedMeshRenderer>().enabled == false)
                    {
                        stecca.GetComponent<SkinnedMeshRenderer>().enabled = true;
                    }
                    break;
                case "bende":
                    if (stecca.GetComponent<SkinnedMeshRenderer>().enabled == true)
                    {
                        bende.GetComponent<SkinnedMeshRenderer>().enabled = true;
                    }
                    break;
                case "fissaggi":
                    if (bende.GetComponent<SkinnedMeshRenderer>().enabled == true)
                        fissaggi.GetComponent<SkinnedMeshRenderer>().enabled = true;
                    break;
            }
            GameObject.Find("Inventory").SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

            if (item != null&&scene==2)
        {
            if(GameObject.Find("Torcia"))
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
                    case "Torcia":
                        GameObject.Find("Player").GetComponent<FPSInteractionManager>().SetTorchStatus(!GameObject.Find("Player").GetComponent<FPSInteractionManager>().GetTorchStatus());
                        break;
            }
            else
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
