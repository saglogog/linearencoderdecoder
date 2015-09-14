using System;
using Gtk;
using LinearEncoderDecoderInterface;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
		
	protected void button1_click (object sender, EventArgs e)
	{
		TextBuffer buffer = textview1.Buffer;
		char[] ca = buffer.Text.ToCharArray ();

		foreach (char ch in ca) {
			Console.Write (ch);
		}
		ShowGandHBasedOnP s = new ShowGandHBasedOnP ();
		textview4.Buffer.Text = s.GenerateG (textview1.Buffer.Text);

	}
}
