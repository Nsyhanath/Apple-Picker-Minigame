using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    private ApplePopup applePopup;

    void Start() {
        GameObject scoreGO = GameObject.Find( "ScoreCounter" );
        if ( scoreGO == null ) {
            Debug.LogError( "Basket could not find a GameObject named 'ScoreCounter' in the Hierarchy." );
            return;
        }
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        if ( scoreCounter == null ) {
            Debug.LogError( "Found a GameObject named 'ScoreCounter', but it doesn't have a ScoreCounter script attached." );
        }

        GameObject popupGO = GameObject.Find( "pogchamp" );
        if ( popupGO != null ) {
            applePopup = popupGO.GetComponent<ApplePopup>();
        }
    }

    void Update() {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter( Collision coll ){
        GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Apple") ){
            Destroy( collidedWith );
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );

            if ( applePopup != null ) {
                applePopup.Show();
            }
        }
    }
}