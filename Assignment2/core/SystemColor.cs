using Assignment2.utils;
using Windows.UI.ViewManagement;

namespace Assignment2.core {

	internal class SystemColor {
		public static event OnColorChanged colorChanged;
		private static readonly UISettings settings = new();
		private static Windows.UI.Color currentColor;

		static SystemColor() {
			currentColor = settings.GetColorValue(UIColorType.Accent);
			settings.ColorValuesChanged += ColorChanged;
		}

		private static void ColorChanged(UISettings uiSettings, object args) {
			Windows.UI.Color newColor = uiSettings.GetColorValue(UIColorType.Accent);
			if (currentColor != newColor) {
				Log.d($"Color changed from {currentColor} to {newColor}");
				currentColor = newColor;
				colorChanged.Invoke(UIColorToColor(currentColor));
			}
		}

		public static void GetAccentColor(out Color color) {
			color = UIColorToColor(currentColor);
		}

		private static Color UIColorToColor(Windows.UI.Color color) {
			return Color.FromArgb(color.R, color.G, color.B);
		}

		public delegate void OnColorChanged(Color color);
	}
}