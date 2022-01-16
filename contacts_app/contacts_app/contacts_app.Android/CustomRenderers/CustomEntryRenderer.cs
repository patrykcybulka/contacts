using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using contacts_app.CustomControls;
using contacts_app.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace contacts_app.Droid.CustomRenderers
{
    [System.Obsolete]
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.White);
                this.Control.SetBackgroundDrawable(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                this.Control.SetPadding(20, 0, 0, 0);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));
                Control.SetTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));
            }
        }
    }
}