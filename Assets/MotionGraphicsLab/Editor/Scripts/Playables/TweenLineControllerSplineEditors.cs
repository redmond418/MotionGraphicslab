using AnnulusGames.TweenPlayables.Editor;
using UnityEngine;
using UnityEditor;
using UnityEditor.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx.Editor
{
    [CustomTimelineEditor(typeof(TweenLineControllerSplineTrack))]
    public class TweenLineControllerSplineTrackEditor : TweenAnimationTrackEditor
    {
        public override Color trackColor => StylingEx.motionGraohicsColor;
        public override Texture2D trackIcon => StylingEx.motionGraphicsIcon;
        public override string defaultTrackName => "Tween Line Controller Spline Track";
    }

    [CustomTimelineEditor(typeof(TweenLineControllerSplineClip))]
    public class TweenLineControllerSplineClipEditor : TweenAnimationClipEditor
    {
        public override string defaultClipName => "Tween Line Controller Spline";
        public override Color clipColor => StylingEx.motionGraohicsColor;
        public override Texture2D clipIcon => StylingEx.motionGraphicsIcon;
    }

    [CustomPropertyDrawer(typeof(TweenLineControllerSplineBehaviour))]
    public class TweenLineControllerSplineBehaviourDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.y += 7f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("endA"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("endB"));
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = 9f;
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("endA"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("endB"));
            return height;
        }
    }
}