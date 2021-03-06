/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System.Collections;
using UnityEngine.Events;

namespace UnityEngine.UI.Tweens
{
	public struct Vector3Tween : ITweenValue
	{
		public class Vector3TweenCallback : UnityEvent<Vector3> {}
		public class Vector3TweenFinishCallback : UnityEvent {}
		
		private Vector3 m_StartVector3;
		private Vector3 m_TargetVector3;
		private float m_Duration;
		private bool m_IgnoreTimeScale;
		private TweenEasing m_Easing;
		private Vector3TweenCallback m_Target;
		private Vector3TweenFinishCallback m_Finish;
		
		/// <summary>
		/// Gets or sets the starting Vector3.
		/// </summary>
		/// <value>The start color.</value>
		public Vector3 startVector3
		{
			get { return m_StartVector3; }
			set { m_StartVector3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the target Vector3.
		/// </summary>
		/// <value>The color of the target.</value>
		public Vector3 targetVector3
		{
			get { return m_TargetVector3; }
			set { m_TargetVector3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the duration of the tween.
		/// </summary>
		/// <value>The duration.</value>
		public float duration
		{
			get { return m_Duration; }
			set { m_Duration = value; }
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="UnityEngine.UI.Tweens.ColorTween"/> should ignore time scale.
		/// </summary>
		/// <value><c>true</c> if ignore time scale; otherwise, <c>false</c>.</value>
		public bool ignoreTimeScale
		{
			get { return m_IgnoreTimeScale; }
			set { m_IgnoreTimeScale = value; }
		}
		
		/// <summary>
		/// Gets or sets the tween easing.
		/// </summary>
		/// <value>The easing.</value>
		public TweenEasing easing
		{
			get { return m_Easing; }
			set { m_Easing = value; }
		}

		/// <summary>
		/// Tweens the color based on percentage.
		/// </summary>
		/// <param name="floatPercentage">Float percentage.</param>
		public void TweenValue(float floatPercentage)
		{
			if (!this.ValidTarget())
				return;
			
			this.m_Target.Invoke( Vector3.Lerp (this.m_StartVector3, this.m_TargetVector3, floatPercentage) );
		}
		
		/// <summary>
		/// Adds a on changed callback.
		/// </summary>
		/// <param name="callback">Callback.</param>
		public void AddOnChangedCallback(UnityAction<Vector3> callback)
		{
			if (m_Target == null)
				m_Target = new Vector3TweenCallback();
			
			m_Target.AddListener(callback);
		}
		
		/// <summary>
		/// Adds a on finish callback.
		/// </summary>
		/// <param name="callback">Callback.</param>
		public void AddOnFinishCallback(UnityAction callback)
		{
			if (m_Finish == null)
				m_Finish = new Vector3TweenFinishCallback();
			
			m_Finish.AddListener(callback);
		}
		
		public bool GetIgnoreTimescale()
		{
			return m_IgnoreTimeScale;
		}
		
		public float GetDuration()
		{
			return m_Duration;
		}
		
		public bool ValidTarget()
		{
			return m_Target != null;
		}
		
		/// <summary>
		/// Invokes the on finish callback.
		/// </summary>
		public void Finished()
		{
			if (m_Finish != null)
				m_Finish.Invoke();
		}
	}
}
