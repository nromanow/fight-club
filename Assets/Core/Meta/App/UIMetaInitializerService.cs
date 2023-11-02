using Core.App;
using Core.Meta.Api;
using System;
using System.Linq;
using UnityEngine;

namespace Core.Meta.App {
	public class UIMetaInitializerService : IMetaInitializerService {
		private readonly Settings _settings;
		private readonly AppComponentRegistry _componentRegistry;

		public UIMetaInitializerService (Settings settings, AppComponentRegistry componentRegistry) {
			_settings = settings;
			_componentRegistry = componentRegistry;
		}

		public void Initialize () {
			_componentRegistry
				.Register(_settings.layersPrefabs.Select(x => {
						var instance = UnityEngine.Object.Instantiate(x);
						UnityEngine.Object.DontDestroyOnLoad(instance.gameObject);
						return instance;
					})
					.ToArray());
		}

		[Serializable]
		public class Settings {
			[SerializeField]
			private UI.Data.Layers.GUILayer[] _layersPrefabs;

			public UI.Data.Layers.GUILayer[] layersPrefabs => _layersPrefabs;
		}
	}
}
