using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private QuestInputLogger _questInputLoggerSx;
    private QuestInputLogger _questInputLoggerDx;
    private GameObject _primaryButtonSxI;
    private GameObject _secondaryButtonSxI;
    private GameObject _primaryButtonDxI;
    private GameObject _secondaryButtonDxI;

    [SerializeField] private float onOffTime = 1f;
    void Start()
    {
        _questInputLoggerSx = GameObject.Find("InputLoggerSX").GetComponent<QuestInputLogger>();
        _questInputLoggerDx = GameObject.Find("InputLoggerDX").GetComponent<QuestInputLogger>();
        
        _primaryButtonSxI = GameObject.Find("PrimaryButtonSxPic");
        if (_primaryButtonSxI == null) {Debug.LogError("No primary button sx image found");}
        _primaryButtonSxI.SetActive(false);
        _secondaryButtonSxI = GameObject.Find("SecondaryButtonSxPic");
        if (_secondaryButtonSxI == null) {Debug.LogError("No secondary button sx image found");}
        _secondaryButtonSxI.SetActive(false);
        _primaryButtonDxI = GameObject.Find("PrimaryButtonDxPic");
        if (_primaryButtonDxI == null) {Debug.LogError("No primary button dx image found");}
        _primaryButtonDxI.SetActive(false);
        _secondaryButtonDxI = GameObject.Find("SecondaryButtonDxPic");
        if (_secondaryButtonDxI == null) {Debug.LogError("No secondary button dx image found");}
        _secondaryButtonDxI.SetActive(false);

    }
    void Update()
    {

        if (_questInputLoggerSx.primaryButtonPressed)
        {
            Debug.Log ("Primary button sx pressed");
            StartCoroutine(ObjectFlicker(_primaryButtonSxI));
        }
        else
        {
            Debug.Log ("Primary button sx not pressed");
            StopCoroutine(ObjectFlicker(_primaryButtonSxI));
        }

        if (_questInputLoggerSx.secondaryButtonPressed)
        {
            Debug.Log ("Secondary button sx pressed");
            StartCoroutine(ObjectFlicker(_secondaryButtonSxI));
        }
        else { StopCoroutine(ObjectFlicker(_secondaryButtonSxI)); }

        if (_questInputLoggerDx.primaryButtonPressed)
        {
            Debug.Log ("Primary button dx pressed");
            StartCoroutine(ObjectFlicker(_primaryButtonDxI));
        }
        else
        {
            Debug.Log ("Primary button dx not pressed");
            StopCoroutine(ObjectFlicker(_primaryButtonDxI));
        }

        if (_questInputLoggerDx.secondaryButtonPressed)
        {
            Debug.Log ("Secondary button dx pressed");
            StartCoroutine(ObjectFlicker(_secondaryButtonDxI));
        }
        else
        {
            StopCoroutine(ObjectFlicker(_secondaryButtonDxI));
            Debug.Log ("Secondary button dx not pressed");
        }
    }
    
    private IEnumerator ObjectFlicker(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(onOffTime);
        obj.SetActive(false);
        yield return new WaitForSeconds(onOffTime);
    }
}
