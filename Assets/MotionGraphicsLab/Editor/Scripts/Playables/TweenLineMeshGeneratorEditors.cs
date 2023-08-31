using AnnulusGames.TweenPlayables.Editor;
using UnityEngine;
using UnityEditor;
using UnityEditor.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx.Editor
{
    [CustomTimelineEditor(typeof(TweenLineMeshGeneratorTrack))]
    public class TweenLineMeshGeneratorTrackEditor : TweenAnimationTrackEditor
    {
        public override Color trackColor => StylingEx.motionGraohicsColor;
        public override Texture2D trackIcon => StylingEx.motionGraphicsIcon;
        public override string defaultTrackName => "Tween Line Mesh Generator Track";
    }

    [CustomTimelineEditor(typeof(TweenLineMeshGeneratorClip))]
    public class TweenLineMeshGeneratorClipEditor : TweenAnimationClipEditor
    {
        public override string defaultClipName => "Tween Line Mesh Generator";
        public override Color clipColor => StylingEx.motionGraohicsColor;
        public override Texture2D clipIcon => StylingEx.motionGraphicsIcon;
    }

    [CustomPropertyDrawer(typeof(TweenLineMeshGeneratorBehaviour))]
    public class TweenLineMeshGeneratorBehaviourDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.y += 7f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("color"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("thickness"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("endCapDivisionCount"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("endCapStretch"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("cornerDivisionCount"));
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = 15f;
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("color"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("thickness"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("endCapDivisionCount"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("endCapStretch"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("cornerDivisionCount"));
            return height;
        }
    }
}