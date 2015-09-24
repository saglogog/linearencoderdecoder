using System;
using Gtk;

namespace LinearEncoderDecoderInterface
{
	public partial class ErrorWindow : Gtk.Window
	{
		public ErrorWindow (string msg) :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			label1.Text = msg;
		}
	}
}