using Assignment2.utils;
using Windows.UI.ViewManagement;

namespace Assignment2.core {

	internal class SystemColor {

		private static UIColorType GetUIColorType() {
			return Settings.Default.DarkMode ? UIColorType.AccentDark2 : UIColorType.AccentLight3;
		}

		public static event OnColorChanged onColorChanged;

		private static readonly UISettings settings = new();
		private static Windows.UI.Color currentColor;

		static SystemColor() {
			currentColor = settings.GetColorValue(GetUIColorType());
			settings.ColorValuesChanged += AccentColorChanged;
		}

		private static void AccentColorChanged(UISettings uiSettings, object args) {
			Windows.UI.Color newColor = uiSettings.GetColorValue(GetUIColorType());
			if (currentColor != newColor) {
				Log.d($"Accent color changed from {currentColor} to {newColor}");
				currentColor = newColor;
				onColorChanged.Invoke(UIColorToColor(currentColor));
			}
		}

		public static void TriggerUpdate() {
			Log.i("Manual update system color triggered");
			AccentColorChanged(new UISettings(), "");
		}

		public static void GetColor(out Color color, UIColorType? type = null) {
			color = UIColorToColor(settings.GetColorValue(type ?? GetUIColorType()));
		}

		private static Color UIColorToColor(Windows.UI.Color color) {
			return Color.FromArgb(color.R, color.G, color.B);
		}

		public delegate void OnColorChanged(Color color);
	}
}