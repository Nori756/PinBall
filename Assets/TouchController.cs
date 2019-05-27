using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
    {
        //HingeJointコンポーネントを入れる
        private HingeJoint myHingeJoint;

        //初期の傾き
        public float defaultAngle = 20;
        //弾いた時の傾き
        public float flickAngle = -20;

        // Use this for initialization
        void Start()
        {
            //HingeJointコンポーネント取得
            this.myHingeJoint = GetComponent<HingeJoint>();

            //フリッパーの傾きを設定
            SetAngle(this.defaultAngle);
        }

    // Update is called once per frame
    void Update()
    {

        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {



            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(i);

                TouchPhase phase = touch.phase;
                switch (touch.phase)
                {

                    case TouchPhase.Began:
                        //画面右半分をタッチしていたら右フリッパーが傾く
                        if (touch.position.x > Screen.width * 0.5f && tag == "RightFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }
                        //画面左半分をタッチしていたら左フリッパーが傾く
                        if (touch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag") {
                            SetAngle(this.flickAngle);
                        }
                        break;
                     case TouchPhase.Ended:
            //離された時フリッパーを元に戻す
            if (touch.position.x > Screen.width * 0.5f && tag == "RightFripperTag")
                        {
                            SetAngle(this.defaultAngle);
                        }
                        //離された時フリッパーを元に戻す
                        if (touch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
                        {
                            SetAngle(this.defaultAngle);
                        }
                        break; }
            }
        }
    }
        //フリッパーの傾きを設定
        public void SetAngle(float angle)
        {
            JointSpring jointSpr = this.myHingeJoint.spring;
            jointSpr.targetPosition = angle;
            this.myHingeJoint.spring = jointSpr;
        }
    }


       