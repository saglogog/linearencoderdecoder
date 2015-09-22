using System;
using Gtk;
using LinearEncoderDecoderInterface;
using LinearEncoderDecoderLibrary;

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
		textview4.Buffer.Text = "";
		textview5.Buffer.Text = "";
		TextBuffer buffer = textview1.Buffer;
		char[] ca = buffer.Text.ToCharArray ();

		foreach (char ch in ca) {
			Console.Write (ch);
		}
		ShowGandHBasedOnP s = new ShowGandHBasedOnP ();
		HelperClass hc = new HelperClass ();
		//textview4.Buffer.Text = s.ReturnPArray (textview1.Buffer.Text);
		textview4.Buffer.Text = hc.Convert2DIntArrayToString(s.GenerateG (textview1.Buffer.Text),'\n');
		textview5.Buffer.Text = hc.Convert2DIntArrayToString (s.GenerateH (textview1.Buffer.Text),'\n');
	}

	protected void button2_click (object sender, EventArgs e)
	{
		ShowCodewordsBasedOnP sc = new ShowCodewordsBasedOnP ();
		HelperClass hc = new HelperClass ();
		textview6.Buffer.Text = hc.Convert2DIntArrayToString (sc.GenerateCodewords (textview1.Buffer.Text), '\n');
	}
}