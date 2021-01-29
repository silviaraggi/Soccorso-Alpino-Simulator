using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeep : MonoBehaviour
{
    GameObject giocatore = null;
    bool canStart = false;
    // Start is called before the first frame update
    void Start()
    {
        giocatore = GameObject.FindGameObjectWithTag("Player");
        giocatore.GetComponent<FirstPersonCharacterController>().SetLocked(false);
        GetComponent<LightUpInteractable>().SetAnimatable(false);
    }

    // Update is called once per frame
    void Update()
    {
        canStart = GameObject.Find("magliasolida").GetComponent<LightUpInteractable>().GetCollect();
        if (canStart)
        {
            GetComponent<LightUpInteractable>().SetAnimatable(true);
            if (GetComponent<LightUpInteractable>().GetInteract())
                Move();
        }
    }
    public void Move()
    {

            giocatore.GetComponent<FirstPersonCharacterController>().SetLocked(true);
            giocatore.GetComponent<FirstPersonCharacterController>().HidePointer();
            Quaternion camera_rot = Quaternion.Euler(new Vector3(0f, -79.05f, 0f));
            GameObject.Find("Cube").GetComponent<BoxCollider>().enabled = false;
            giocatore.transform.SetPositionAndRotation(new Vector3 (277.66f, 4.04f, 248.1f), camera_rot);
            StartCoroutine(MoveJeep());
    }
    IEnumerator MoveJeep()
    {
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DOMove(new Vector3(267.68f, 2.98f, 240.15f), 8f));
        moveSequence.Append(transform.DORotate(new Vector3(-88.645f, -300.3f, -39.208f), 4f));
        moveSequence.OnComplete(() => transform.DOMove(new Vector3(268.4f, 3.18f, 247.41f), 8f).OnComplete(() => transform.DORotate(new Vector3(-88.645f, -333.95f, -39.205f), 4f)));
        moveSequence.Play();
        yield break;
    }
}
