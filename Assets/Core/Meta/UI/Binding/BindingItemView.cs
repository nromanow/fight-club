using System;
using UniRx;
using UnityEngine;

namespace Core.Meta.UI.Binding {
	public class BindingItemView<T> : MonoBehaviour {
		private Action _onDataChanged;
		public T target { get; private set; }

		private readonly CompositeDisposable _disposable = new();

		private void OnDestroy () {
			OnDeinitialize();

			_disposable.Dispose();
		}

		protected virtual void OnInitialize () {}

		protected virtual void OnDeinitialize () {}

		public Action GetOnDataChangedEvent () {
			return _onDataChanged;
		}

		public void SetTarget (T itemTarget) {
			target = itemTarget;

			OnInitialize();
		}

		public void AddDisposable (IDisposable disposable) {
			_disposable.Add(disposable);
		}
	}

	public static class BindingItemViewExtensions {
		public static void Subscribe<TItem, TObservable> (this BindingItemView<TItem> bindingItemView, IObservable<TObservable> source) {
			var action = bindingItemView.GetOnDataChangedEvent();
			bindingItemView.AddDisposable(source.Subscribe(_ => action()));
		}
	}
}
