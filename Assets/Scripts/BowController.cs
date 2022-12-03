using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float arrow_speed;

    [SerializeField]
    ArrowDirector arrowDirector;

    [SerializeField]
    GameObject floating_text;

    GameObject arrow;
    bool shoot = false;

    private void Start()
    {
        arrow = arrowDirector.createArrow(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (arrow == null)
        {
            arrow = arrowDirector.createArrow();
            shoot = false;
        }

        if (!shoot)
        {
            arrow.transform.Rotate( new Vector3(speed * Input.GetAxisRaw("Vertical"), 0f, 0f) );

            // setup
            Vector3 arrow_v3 = (arrow.transform.Find("GameObject").transform.position - arrow.transform.position).normalized;
            Vector3 bow_v3 = new Vector3(0, 0, 1);
            // arrow
            Debug.DrawRay(arrow.transform.Find("GameObject").transform.position, arrow_v3, Color.cyan);
            // bow
            Debug.DrawRay(transform.position, bow_v3, Color.red);


            string text = "각도가 적당합니다";

            // 내적
            Vector2 arrow_v = new Vector2(arrow_v3.z, arrow_v3.y);
            Vector2 bow_v = new Vector2(bow_v3.z, bow_v3.y);

            float angle = Mathf.Abs(((arrow_v.x * bow_v.x) + (arrow_v.y * bow_v.y)) / (arrow_v.sqrMagnitude * bow_v.sqrMagnitude));

            if (angle <= 0.75f)
                text = "각도가 이상합니다";

            floating_text.GetComponent<TextMesh>().text = text;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rigidbody rigidbody = arrow.GetComponent<Rigidbody>();

                rigidbody.useGravity = true;
                rigidbody.AddForce(arrow_v3 * arrow_speed);

                shoot = true;
            }
        }

    }
}
