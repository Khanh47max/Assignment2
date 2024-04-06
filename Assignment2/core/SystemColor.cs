using Windows.UI.ViewManagement;

namespace Assignment2.core {

	internal class SystemColor {
		private readonly UIColorType _colorType;
		private readonly UISettings _uiSettings = new();

		public event ColorChanged OnColorChanged = delegate { };

		public SystemColor(UIColorType colorType = UIColorType.Accent) {
			_colorType = colorType;
			_uiSettings.ColorValuesChanged += (sender, args) => {
				OnColorChanged(Converter(sender.GetColorValue(_colorType)));
			};
		}

		public Color GetColor() {
			Windows.UI.Color raw = _uiSettings.GetColorValue(_colorType);
			return Converter(raw);
		}

		private Color Converter(Windows.UI.Color raw) {
			return Color.FromArgb(raw.R, raw.G, raw.B);
		}

		public delegate void ColorChanged(Color color);
	}
}