using System;
using Gtk;

namespace LinearEncoderDecoderInterface
{
	public partial class ErrorWindow : Gtk.Window
	{
		public ErrorWindow () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

