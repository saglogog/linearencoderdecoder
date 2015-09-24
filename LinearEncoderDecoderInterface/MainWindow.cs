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

	/// <summary>
	/// What happens when someone presses the "Generate G and H Button".
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void button1_click (object sender, EventArgs e)
	{
		textview4.Buffer.Text = "";
		textview5.Buffer.Text = "";
		ShowGandHBasedOnP s = new ShowGandHBasedOnP ();

		ErrorWindowEventArgs ewea = null;
		ErrorEventClass eec = new ErrorEventClass ();
		Listener l = new Listener ();
		l.Subscribe (eec);

		try{
			if (textview1.Buffer.Text != null) {
				TextBuffer buffer = textview1.Buffer;
				char[] ca = buffer.Text.ToCharArray ();
				foreach (char ch in ca) {
					Console.Write (ch);
				}
			} else {
				throw new ArgumentNullException ();
			}
		}
		catch(ArgumentNullException ex){
			ewea = new ErrorWindowEventArgs ("You probably have not entered the P array..."+ex.Message);
			eec.TriggerEvent(ewea);
		}


		HelperClass hc = new HelperClass ();
		textview4.Buffer.Text = hc.Convert2DIntArrayToString(s.GenerateG (textview1.Buffer.Text),'\n');
		textview5.Buffer.Text = hc.Convert2DIntArrayToString (s.GenerateH (textview1.Buffer.Text),'\n');
	}

	/// <summary>
	/// Decides what happens when someone presses the "Make Codewords Appear" Button.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void button2_click (object sender, EventArgs e)
	{
		ShowCodewordsBasedOnP sc = new ShowCodewordsBasedOnP ();
		HelperClass hc = new HelperClass ();

		ErrorWindowEventArgs ewea = null;
		ErrorEventClass eec = new ErrorEventClass ();
		Listener l = new Listener ();
		l.Subscribe (eec);

		try{
			if(textview1.Buffer.Text!=null){
				textview6.Buffer.Text = hc.Convert2DIntArrayToString (sc.GenerateCodewords (textview1.Buffer.Text), '\n');
			}else {
				throw new ArgumentNullException ();
			}
		}
		catch(ArgumentNullException ex){

			ewea = new ErrorWindowEventArgs ("You probably have not entered the P array..."+ex.Message);
			eec.TriggerEvent (ewea);
		}
	}
	/// <summary>
	/// Decides what happens when someone presses the "Encode" Button.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void button3_click (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}

	/// <summary>
	/// Decides what happens when someone presses the "Decode" Button.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void button4_click (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}
}