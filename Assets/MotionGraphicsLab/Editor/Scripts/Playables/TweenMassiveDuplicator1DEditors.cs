using AnnulusGames.TweenPlayables.Editor;
using UnityEngine;
using UnityEditor;
using UnityEditor.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx.Editor
{
    [CustomTimelineEditor(typeof(TweenMassiveDuplicator1DTrack))]
    public class TweenMassiveDuplicator1DTrackEditor : TweenAnimationTrackEditor
    {
        public override Color trackColor => Styling.transformColor;
        public override Texture2D trackIcon => Styling.transformIcon;
        public override string defaultTrackName => "Tween Massive Duplicator 1D Track";
    }

    [CustomTimelineEditor(typeof(TweenMassiveDuplicator1DClip))]
    public class TweenMassiveDuplicator1DClipEditor : TweenAnimationClipEditor
    {
        public override string defaultClipName => "Tween Massive Duplicator 1D";
        public override Color clipColor => Styling.transformColor;
        public override Texture2D clipIcon => Styling.transformIcon;
    }

    [CustomPropertyDrawer(typeof(TweenMassiveDuplicator1DBehaviour))]
    public class TweenMassiveDuplicator1DBehaviourDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.y += 7f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("loopCount"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("positionMultiplier"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("positionOffset"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("eulerMultiplier"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("eulerOffset"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("scaleMultiplier"));
            position.y += 2f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("scaleOffset"));
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = 19f;
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("loopCount"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("positionMultiplier"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("positionOffset"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("eulerMultiplier"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("eulerOffset"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("scaleMultiplier"));
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("scaleOffset"));
            return height;
        }
    }
}