using UnityEditor;
using UnityEngine;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx.Editor
{
    public static class StylingEx
    {
        public static Color motionGraohicsColor
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return new Color(0.5f, 0.6f, 1f);
                else return new Color(0.3f, 0.32f, 0.67f);
            }
        }

        public static Texture2D motionGraphicsIcon
        {
            get
            {
                return (Texture2D)EditorGUIUtility.IconContent("cs Script Icon").image;
            }
        }
    }
}