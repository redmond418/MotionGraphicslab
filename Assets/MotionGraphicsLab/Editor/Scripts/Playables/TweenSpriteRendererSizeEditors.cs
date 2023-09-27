using AnnulusGames.TweenPlayables.Editor;
using UnityEngine;
using UnityEditor;
using UnityEditor.Timeline;

namespace Redmond.MotionGraphicsLab.TweenPlayablesEx.Editor
{
    [CustomTimelineEditor(typeof(TweenSpriteRendererSizeTrack))]
    public class TweenSpriteRendererSizeTrackEditor : TweenAnimationTrackEditor
    {
        public override Color trackColor => Styling.rendererColor;
        public override Texture2D trackIcon => Styling.spriteRendererIcon;
        public override string defaultTrackName => "Tween Sprite Renderer Size Track";
    }

    [CustomTimelineEditor(typeof(TweenSpriteRendererSizeClip))]
    public class TweenSpriteRendererSizeClipEditor : TweenAnimationClipEditor
    {
        public override string defaultClipName => "Tween Sprite Renderer Size";
        public override Color clipColor => Styling.rendererColor;
        public override Texture2D clipIcon => Styling.spriteRendererIcon;
    }

    [CustomPropertyDrawer(typeof(TweenSpriteRendererSizeBehaviour))]
    public class TweenSpriteRendererSizeBehaviourDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.y += 7f;
            GUIHelper.Field(ref position, property.FindPropertyRelative("size"));
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = 7f;
            height += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("size"));
            return height;
        }
    }
}