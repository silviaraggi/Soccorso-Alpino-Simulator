using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Item item;
    public GameObject text;
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

    public GameObject artva;
    public GameObject sonda;
    public GameObject pala;
    private Inventory inventario;
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

            case 3:
                artva = GameObject.Find("ARTVA");
                pala = GameObject.Find("Pala");
                sonda = GameObject.Find("Sonda_aperta");
                break;
        }
    }

    private void Update()
    {
        inventario = GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory();
        if (item != null)
        {
            icon.sprite = item.icon;
            if (text.GetComponent<Text>())
                text.GetComponent<Text>().text = item.name;
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        if(text.GetComponent<Text>())
        text.GetComponent<Text>().text = item.name;
        icon.enabled = true;
        if (text.GetComponent<Text>())
            text.GetComponent<Text>().enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        if (text.GetComponent<Text>())
            text.GetComponent<Text>().enabled = false;

    }

    public void UseItem()
    {
        if (item != null && scene == 1)
        {
            switch (this.item.name)
            {
                case "Stecca":
                    if (_stivali.GetComponent<SkinnedMeshRenderer>().enabled == false)
                    {
                        stecca.GetComponent<SkinnedMeshRenderer>().enabled = true;
                        inventario.Remove(this.item);
                    }
                    break;
                case "Bende":
                    if (stecca.GetComponent<SkinnedMeshRenderer>().enabled == true)
                    {
                        bende.GetComponent<SkinnedMeshRenderer>().enabled = true;
                        
                        inventario.Remove(this.item);
                        
                    }
                    break;
                case "Fissaggi":
                    if (bende.GetComponent<SkinnedMeshRenderer>().enabled == true)
                    {
                        fissaggi.GetComponent<SkinnedMeshRenderer>().enabled = true;
                        inventario.Remove(this.item);
                    }
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
                    if (gameObject.scene.name=="BoscoCane"&&berretto.GetComponent<InteractableClue>().GetCollect() == false)
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
                        if (GameObject.Find("Player").GetComponent<FPSInteractionManager>().GetTorchStatus())
                        {
                            GameObject.Find("button_torcia").GetComponent<Image>().color = Color.green;
                        }
                        if (!GameObject.Find("Player").GetComponent<FPSInteractionManager>().GetTorchStatus())
                        {
                            GameObject.Find("button_torcia").GetComponent<Image>().color = Color.white;
                        }
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
        if(item!=null && scene == 3)
        {
            switch (this.item.name)
            {
                case "ARTVA":
                    GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().SetArtvaActive(!GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().GetArtvaActive());
                    if (GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().GetArtvaActive())
                    {
                        GameObject.Find("artva").GetComponent<Image>().color = Color.green;
                    }
                    if (!GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().GetArtvaActive())
                    {
                        GameObject.Find("artva").GetComponent<Image>().color = Color.white;
                    }


                    //inventario.Remove(artva.GetComponent<InteractableClue>().GetItem());
                    break;
                
                case "Pala":
                    if (sonda.GetComponent<Renderer>().enabled)
                    {
                        GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().SetIsUsingPala(!GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().GetisUsingPala());
                        if (GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().GetisUsingPala())
                        {
                            GameObject.Find("button_pala").GetComponent<Image>().color = Color.green;
                        }
                        if (!GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().GetisUsingPala())
                        {
                            GameObject.Find("button_pala").GetComponent<Image>().color = Color.white;
                        }
                    }
                    break;

                case "Sonda":
                    if (GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().GetCanUseSonda())
                    {
                        sonda.GetComponent<Renderer>().enabled = true;
                        inventario.Remove(sonda.GetComponent<InteractableClue>().GetItem());
                        GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().SetArtvaActive(false);
                    }
                    break;
            }
            GameObject.Find("Inventory").SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
