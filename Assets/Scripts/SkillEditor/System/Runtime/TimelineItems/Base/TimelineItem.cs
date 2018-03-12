using UnityEngine;

namespace TimeLine
{

    [ExecuteInEditMode]
    public abstract class TimelineItem : MonoBehaviour
    {

        [SerializeField]
        protected float firetime = 0f;
        float FIXTIME = 1f / 15f;
#if UNITY_EDITOR

        [HideInInspector, SerializeField]
        protected int frameCount = 0;
        public int FrameCount
        {
            get { return this.frameCount; }
            set
            {
                frameCount = value;
                firetime = FIXTIME * frameCount;
                if (frameCount < 0f)
                {
                    firetime = 0f;
                    frameCount = 0;
                }
            }
        }
#endif

        //����ʱ��
        public float Firetime
        {
            get { return this.firetime; }
            set
            {
                firetime = value;
#if UNITY_EDITOR
                frameCount = (int)(firetime / FIXTIME);
#endif
                if (firetime < 0f)
                {
                    firetime = 0f;
#if UNITY_EDITOR
                    frameCount = 0;
#endif
                }
            }
        }

       //ʱ���߳�ʼ��
        public virtual void Initialize() { }

        //ʱ����ֹͣ
        public virtual void Stop() { }

        //��ȡ����Ķ��� ���ڶ�̬��װ
        public virtual GameObject[] GetTiedGameObject() { return null; }
        //��������Ķ���
        public virtual void SetTieGameObject(GameObject obj,int index) { }

        //�´���itemʱ���� ��д����Ĭ��ֵ
        public virtual void SetDefaults() { }

        //�´���itemʱ����
        public virtual void SetDefaults(UnityEngine.Object PairedItem) { }

   
        //��ȡʱ����
        public TimelineTrack TimelineTrack
        {
            get
            {
                TimelineTrack track = null;
                if (transform.parent != null)
                {
                    track = base.transform.parent.GetComponentInParent<TimelineTrack>();
                    if (track == null)
                    {
                        Debug.LogError("No TimelineTrack found on parent!", this);
                    }
                }
                else
                {
                    Debug.LogError("Timeline Item has no parent!", this);
                }
                return track;
            }
        }
    }
}