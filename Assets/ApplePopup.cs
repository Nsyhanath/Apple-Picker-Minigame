using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApplePopup : MonoBehaviour
{
    [Header("Inscribed")]
    public float displayDuration = 0.75f;

    private Image img;

    void Awake() {
        img = GetComponent<Image>();
        if ( img != null ) {
            img.enabled = false;
        }
    }

    public void Show() {
        StopAllCoroutines();
        StartCoroutine( ShowThenHide() );
    }

    private IEnumerator ShowThenHide() {
        if ( img != null ) img.enabled = true;
        yield return new WaitForSeconds( displayDuration );
        if ( img != null ) img.enabled = false;
    }
}