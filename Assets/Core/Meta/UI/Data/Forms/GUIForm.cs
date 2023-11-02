using Core.Meta.UI.Data.Layers;
using UnityEngine;

namespace Core.Meta.UI.Data.Forms {
	public class GUIForm : ScriptableObject {
		[SerializeField]
		private GUILayerType _layerType;

		[SerializeField]
		private GameObject _source;
		
		public GUILayerType layerType => _layerType;
		
		public GameObject source => _source;
	}
}
