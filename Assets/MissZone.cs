using UnityEngine;

public class MissZone : MonoBehaviour
{
    private ApplePicker applePicker;

    void Start() {
        GameObject pickerGO = GameObject.Find( "ApplePicker" );
        if ( pickerGO == null ) {
            Debug.LogError( "MissZone could not find a GameObject named 'ApplePicker' in the Hierarchy." );
            return;
        }
        applePicker = pickerGO.GetComponent<ApplePicker>();
        if ( applePicker == null ) {
            Debug.LogError( "Found 'ApplePicker' GameObject, but it doesn't have an ApplePicker script attached." );
        }
    }

    void OnTriggerEnter( Collider other ) {
        if ( other.CompareTag( "Apple" ) ) {
            Destroy( other.gameObject );
            if ( applePicker != null ) {
                applePicker.AppleMissed();
            }
        }
    }
}