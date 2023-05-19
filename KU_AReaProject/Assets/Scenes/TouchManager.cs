using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TouchManager : MonoBehaviour
{
    // 오리 오브젝트 선언
    public GameObject rubberduck;
    private GameObject placeObject;
    private ARRaycastManager raycastMng;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        /*
        // 인식된 바닥평면에 터치이벤트로 생성할 큐브 할당
        placeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // 큐브 크기 설정
        placeObject.transform.localScale = Vector3.one * 0.05f;
        */
        
        // 생성할 오브젝트에 오리 오브젝트 할당
        placeObject = rubberduck;
        
        // AR Raycast Manager 추출
        raycastMng = GetComponent<ARRaycastManager>();
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began) {
            // 평면 인식된 곳만 Ray로 검출하기
            if (raycastMng.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Instantiate(placeObject, hits[0].pose.position, Quaternion.Euler(-90f, 180f, 0f));
            }
        }
    }
}
