
using System;

namespace TimeLine
{
    //���item������
    [AttributeUsage(AttributeTargets.Class)]
    public class TimelineItemAttribute : Attribute
    {
        private string subCategory; // item�����Ͳ���
        private string label; // item����
        private TrackItemGenre[] genres; // item������

        // �ض��Ĳ������������
        private Type requiredObjectType; 

        /// <summary>
        /// Item attribute.
        /// </summary>
        /// <param name="category">The user friendly name of the category this cutscene item belongs to.</param>
        /// <param name="label">The user friendly name of the cutscene item.</param>
        /// <param name="genres">The genres that this Cutscene Item belongs to.</param>
        public TimelineItemAttribute(string category, string label, params TrackItemGenre[] genres)
        {
            this.subCategory = category;
            this.label = label;
            this.genres = genres;
        }

        /// <summary>
        /// The Cutscene Item attribute.
        /// </summary>
        /// <param name="category">The user friendly name of the category this cutscene item belongs to.</param>
        /// <param name="label">The user friendly name of the cutscene item.</param>
        /// <param name="pairedObject">Optional: required object to be paired with cutscene item.</param>
        /// <param name="genres">The genres that this Cutscene Item belongs to.</param>
        public TimelineItemAttribute(string category, string label, Type pairedObject, params TrackItemGenre[] genres)
        {
            this.subCategory = category;
            this.label = label;
            this.requiredObjectType = pairedObject;
            this.genres = genres;
        }

        /// <summary>
        /// �Ӳ���
        /// </summary>
        public string Category
        {
            get
            {
                return subCategory;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Label
        {
            get
            {
                return label;
            }
        }

        /// <summary>
        /// ���item������
        /// </summary>
        public TrackItemGenre[] Genres
        {
            get
            {
                return genres;
            }
        }

        /// <summary>
        /// �õ��ض��Ķ������� ���� ��Ƶ�����Ŀ ��Ҫaudioclip����
        /// </summary>
        public Type RequiredObjectType
        {
            get
            {
                return requiredObjectType;
            }
        }
    }
}